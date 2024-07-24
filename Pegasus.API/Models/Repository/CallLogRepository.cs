using Microsoft.EntityFrameworkCore;
using Pegasus.API.Extensions;
using Pegasus.API.Models.Data;
using Pegasus.API.Models.Enums;
using Pegasus.API.Models.Local;

namespace Pegasus.API.Models.Repository;

public class CallLogRepository : ICallLogRepository
{
    private readonly AppDbContext _context;

    public CallLogRepository(AppDbContext context) => _context = context;

    public async Task<Result<CallLog>> AddAsync(CallLogRequest callLogRequest)
    {
        try
        {
            var phoneNumber = callLogRequest.Number?.SanitizePhoneNumber();
            var contactName = callLogRequest.Contact?.Sanitize();

            var contactPhoneNumber = await _context.ContactPhoneNumbers!
                .Include(cpn => cpn.Contact)
                .FirstOrDefaultAsync(cpn => cpn.PhoneNumber == phoneNumber);

            Contact? contact = null;

            if (contactPhoneNumber != null)
            {
                contact = contactPhoneNumber.Contact;
            }
            else
            {
                contact = await _context.Contacts!
                    .Include(c => c.PhoneNumbers)
                    .FirstOrDefaultAsync(c => c.Name == contactName);

                if (contact != null)
                {
                    if (!contact.PhoneNumbers.Any(pn => pn.PhoneNumber == phoneNumber))
                    {
                        contact.PhoneNumbers.Add(new ContactPhoneNumber
                        {
                            PhoneNumber = phoneNumber
                        });
                    }
                }
                else
                {
                    contact = new Contact
                    {
                        Name = contactName,
                        PhoneNumbers = new List<ContactPhoneNumber>
                    {
                        new()
                        {
                            PhoneNumber = phoneNumber
                        }
                    }
                    };

                    await _context.Contacts!.AddAsync(contact);
                }
            }

            var callLog = new CallLog
            {
                Contact = contact,
                Type = (CallType)callLogRequest.Direction,
                CallDate = callLogRequest.Date.ToDateTime(),
                Duration = callLogRequest.Duration,
                Notes = callLogRequest.Notes?.Sanitize()
            };

            await _context.CallLogs!.AddAsync(callLog);
            await _context.SaveChangesAsync();

            return new Result<CallLog>(callLog.RemoveCycles()!);
        }
        catch (Exception ex)
        {
            return new Result<CallLog>(false, $"An error occurred: {ex.Message}");
        }
    }


    public async Task<Result<string>> AddBulkAsync(List<UnformattedCallLogRequest> request)
    {
        try
        {
            var callLogRequests = request.SanitizeData();

            foreach (var callLogRequest in callLogRequests)
            {
                var contactPhoneNumber = await _context.ContactPhoneNumbers!
                    .Include(cpn => cpn.Contact)
                    .FirstOrDefaultAsync(cpn => cpn.PhoneNumber == callLogRequest.Number);

                Contact? contact = null;

                if (contactPhoneNumber != null)
                {
                    contact = contactPhoneNumber.Contact;
                }
                else
                {
                    contact = await _context.Contacts!
                        .Include(c => c.PhoneNumbers)
                        .FirstOrDefaultAsync(c => c.Name == callLogRequest.Contact);

                    if (contact != null)
                    {
                        if (!contact.PhoneNumbers.Any(pn => pn.PhoneNumber == callLogRequest.Number))
                        {
                            contact.PhoneNumbers.Add(new ContactPhoneNumber
                            {
                                PhoneNumber = callLogRequest.Number
                            });
                        }
                    }
                    else
                    {
                        contact = new Contact
                        {
                            Name = callLogRequest.Contact,
                            PhoneNumbers = new List<ContactPhoneNumber>
                            {
                                new()
                                {
                                    PhoneNumber = callLogRequest.Number
                                }
                            }
                        };

                        await _context.Contacts!.AddAsync(contact);
                        await _context.SaveChangesAsync();
                    }
                }

                var callLog = new CallLog
                {
                    Contact = contact,
                    Type = (CallType)callLogRequest.Direction,
                    CallDate = callLogRequest.Date.ToDateTime(),
                    Duration = callLogRequest.Duration,
                    Notes = callLogRequest.Notes?.Sanitize()
                };

                await _context.CallLogs!.AddAsync(callLog);
                await _context.SaveChangesAsync();
            }

            return new Result<string>("Successfully saved!");
        }
        catch (Exception ex)
        {
            // Log the exception here
            return new Result<string>(false, $"An error occurred: {ex.Message}");
        }
    }


    public Task<Result<IEnumerable<CallLog>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Result<CallLog>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }
}
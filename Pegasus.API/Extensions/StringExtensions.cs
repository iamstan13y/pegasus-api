namespace Pegasus.API.Extensions;

public static class StringExtensions
{
    public static string SanitizePhoneNumber(this string encodedPhoneNumber)
    {
        string decodedPhoneNumber = Uri.UnescapeDataString(encodedPhoneNumber);
        decodedPhoneNumber = decodedPhoneNumber.Replace("+", string.Empty);
        return decodedPhoneNumber.Replace(" ", string.Empty);
    }

    public static string Sanitize(this string encodedText)
    {
        var decodedText = Uri.UnescapeDataString(encodedText);
        return decodedText.Replace("+", " ");
    }

}
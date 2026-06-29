
namespace Application.Tools;

public static class TextFixed
{
    public static string FixedEmail(string email)
    {
        return email.Trim().ToLower(); 
    }
}
namespace Twitterly_API.Services
{
    public interface IAuthService
    {
        string HashPassword(string password);
        bool ValidatePassword(string password, string hash);
        string CreateToken(string id);
    }
}

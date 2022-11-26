using Twitterly_API.Dtos;
using Twitterly_API.Entities;

namespace Twitterly_API.Services
{
    public interface IUserService
    {
        Task<bool> IsExistingUserAsync(string username);
        Task<string> CreateUserAsync(UserSignupDto user, string passwordHash);
        Task<User> GetUser(string filterName, string filterValue);
    }
}

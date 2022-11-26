using Twitterly_API.Entities;

namespace Twitterly_API.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetUserAsync(string filterName, string filterValue);
        Task CreateUserAsync(User user);
    }
}

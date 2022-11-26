using Twitterly_API.Dtos;
using Twitterly_API.Entities;
using Twitterly_API.Repositories;

namespace Twitterly_API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> GetUser(string filterName, string filterValue) => await _userRepository.GetUserAsync(filterName, filterValue);
        public async Task<bool> IsExistingUserAsync(string username)
        {
            var user = await GetUser("Username", username);
            return user is not null;
        }
        public async Task<string> CreateUserAsync(UserSignupDto user, string passwordHash)
        {
            User newUser = new()
            {
                Password = passwordHash,
                Username = user.Username,
                DateOfBirth = new Entities.DateOfBirth
                {
                    Day = user.DateOfBirth.Day,
                    Month = user.DateOfBirth.Month,
                    Year = user.DateOfBirth.Year,
                }
            };
            //TODO: Add Country based on IP address and handle write error with custom error
            await _userRepository.CreateUserAsync(newUser);
            return newUser.Id;
        }
    }
}

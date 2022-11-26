using MongoDB.Bson;
using MongoDB.Driver;
using Twitterly_API.Entities;

//TODO: Col name and db name should come from appsettings

namespace Twitterly_API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string _collectionName = "users";
        private readonly string _databaseName = "Twitterly";

        private readonly IMongoCollection<User> _users;
        public UserRepository(IMongoClient client)
        {
            var db = client.GetDatabase(_databaseName);
            _users = db.GetCollection<User>(_collectionName);
        }
        public async Task<User> GetUserAsync(string filterName, string filterValue)
        {
            var user = await _users.Find(Builders<User>.Filter.Eq(filterName, filterValue)).FirstOrDefaultAsync();
            return user;
        }
        public async Task CreateUserAsync(User user)
        {
            await _users.InsertOneAsync(user);
        }
    }
}

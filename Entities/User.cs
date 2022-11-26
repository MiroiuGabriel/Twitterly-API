using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Twitterly_API.Entities
{
    public class DateOfBirth
    {
        public int Month { get; set; }
        public int Day { get; set; }
        public int Year { get; set; }
    }
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("username")]
        public string Username { get; set; } = string.Empty;
        [BsonElement("name")]
        public string? Name { get; set; } = string.Empty;
        [BsonElement("email")]
        public string? Email { get; set; }
        [BsonElement("phone")]
        public string? Phone { get; set; }
        [BsonElement("password")]
        public string Password { get; set; } = string.Empty;
        [BsonElement("passwordSalt")]
        public string ProfilePicture { get; set; } = "https://abs.twimg.com/sticky/default_profile_images/default_profile_400x400.png";
        [BsonElement("dateOfBirth")]
        public DateOfBirth DateOfBirth { get; set; } = new();
        [BsonElement("country")]
        public string Country { get; set; } = "RO";

    }
}

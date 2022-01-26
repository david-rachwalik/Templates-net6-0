namespace Templates_net6_0.Console.MongoDB.Models;
using global::MongoDB.Bson.Serialization.Attributes;

class NameModel
{
    [BsonId]
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

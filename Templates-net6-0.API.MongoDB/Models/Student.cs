namespace Templates_net6_0.API.MongoDB.Models;
using global::MongoDB.Bson;
using global::MongoDB.Bson.Serialization.Attributes;

[BsonIgnoreExtraElements]
public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = "";
    [BsonElement("name")]
    public string Name { get; set; } = "";
    [BsonElement("graduated")]
    public bool IsGraduated { get; set; }
    [BsonElement("courses")]
    public string[]? Courses { get; set; }
    [BsonElement("gender")]
    public string Gender { get; set; } = "";
    [BsonElement("age")]
    public int Age { get; set; }
}

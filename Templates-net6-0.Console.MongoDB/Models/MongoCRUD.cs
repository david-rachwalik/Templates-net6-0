namespace Templates_net6_0.Console.MongoDB.Models;
using global::MongoDB.Bson;
using global::MongoDB.Driver;

// Connection to database
class MongoCRUD
{
    private IMongoDatabase db;
    private readonly CreateIndexOptions _UniqueIndexOption;

    public MongoCRUD(string database)
    {
        var client = new MongoClient();
        db = client.GetDatabase(database);
        _UniqueIndexOption = new CreateIndexOptions { Unique = true };
    }

    public void InsertRecord<T>(string table, T record)
    {
        var collection = db.GetCollection<T>(table);
        collection.InsertOne(record);
    }

    public List<T> LoadRecords<T>(string table)
    {
        var collection = db.GetCollection<T>(table);
        // SELECT * equivalent
        return collection.Find(new BsonDocument()).ToList();
    }

    // Query filter operators: eq (=), ne (!=), gt (>), gte (>=), lt (<), lte (<=), in, nin (not in)

    public T LoadRecordById<T>(string table, Guid id)
    {
        var collection = db.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("Id", id);
        // Find first record to match Id
        return collection.Find(filter).First();
    }

    // Merge statement: update or create
    public void UpsertRecord<T>(string table, Guid id, T record)
    {
        var collection = db.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("Id", id);
        var replaceOptions = new ReplaceOptions { IsUpsert = true };
        // https://docs.mongodb.com/v5.2/reference/method/db.collection.replaceOne
        collection.ReplaceOne(filter, record, replaceOptions);
    }

    public void DeleteRecord<T>(string table, Guid id)
    {
        var collection = db.GetCollection<T>(table);
        var filter = Builders<T>.Filter.Eq("Id", id);
        collection.DeleteOne(filter);
    }

    public void InsertRecords<T>(string table, List<T> records)
    {
        var collection = db.GetCollection<T>(table);
        collection.InsertMany(records);
    }

    // --- Table Methods ---

    public void AddIndex<T>(string table, T record)
    {
        var collection = db.GetCollection<T>(table);
        // Attach unique index to the field 'title'
        var options = new CreateIndexOptions { Unique = true };
        collection.Indexes.CreateOne("{ title : 1 }", options);
    }
}

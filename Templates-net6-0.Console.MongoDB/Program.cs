using Templates_net6_0.Console.MongoDB.Models;

// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

// https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app
// https://www.youtube.com/watch?v=69WBy4MHYUw
// https://www.youtube.com/watch?v=iWTdJ1IYGtg&ab_channel=kudvenkat

MongoCRUD db = new MongoCRUD("AddressBook");

PersonModel person = new PersonModel
{
    FirstName = "Joe",
    LastName = "Smith",
    PrimaryAddress = new AddressModel
    {
        Street = "101 Oak Street",
        City = "Scranton",
        State = "PA",
        ZipCode = "18512",
    }
};
//db.InsertRecord("Users", person);

var recs = db.LoadRecords<PersonModel>("Users");
//foreach (var rec in recs)
for (int index = 0; index < recs.Count; index++)
{
    var rec = recs[index];
    Console.WriteLine($"{rec.Id}: {rec.FirstName} {rec.LastName}");
    if (rec.PrimaryAddress != null) { Console.WriteLine(rec.PrimaryAddress.City); }
    Console.WriteLine();

    if (index == 0)
    {
        //PersonModel personModel = db.LoadRecordById<PersonModel>("Users", new Guid(rec.Id.ToString()));
        var personModel = db.LoadRecordById<PersonModel>("Users", rec.Id);
        Console.WriteLine($"{personModel.Id}: {personModel.FirstName} {personModel.LastName}");

        personModel.DateOfBirth = new DateTime(1982, 10, 31, 0, 0, 0, DateTimeKind.Utc);

        db.UpsertRecord("Users", personModel.Id, personModel);
    }
}

Console.ReadLine();

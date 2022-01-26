namespace Templates_net6_0.API.MongoDB.Data;

public interface IStudentStoreDatabaseSettings
{
    string StudentCoursesCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}

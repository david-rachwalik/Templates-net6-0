namespace Templates_net6_0.API.MongoDB.Data;

public class StudentStoreDatabaseSettings : IStudentStoreDatabaseSettings
{
    public string StudentCoursesCollectionName { get; set; } = "";
    public string ConnectionString { get; set; } = "";
    public string DatabaseName { get; set; } = "";
}

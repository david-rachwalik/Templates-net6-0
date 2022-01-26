namespace Templates_net6_0.API.MongoDB.Services;
using Templates_net6_0.API.MongoDB.Models;

public interface IStudentService
{
    List<Student> Get();
    Student Get(string id);
    Student Create(Student student);
    void Update(string id, Student student);
    void Remove(string id);
}

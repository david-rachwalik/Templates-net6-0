using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Templates_net6_0.WebApp.SqlDb.Models;

public class CourseBase
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Display(Name = "Number")]
    public int CourseID { get; set; }

    [StringLength(50, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [Range(0, 5)]
    public int Credits { get; set; }
}

public class CourseDTO : CourseBase
{
}

public class Course : CourseBase
{
    public int? DepartmentID { get; set; }

    public Department? Department { get; set; }
    public ICollection<Enrollment>? Enrollments { get; set; }
    public ICollection<Instructor>? Instructors { get; set; }
}
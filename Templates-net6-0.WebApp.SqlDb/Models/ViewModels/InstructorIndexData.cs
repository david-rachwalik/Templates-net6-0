using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Templates_net6_0.WebApp.SqlDb.Models.ViewModels
{
    public class InstructorIndexData
    {
        public IEnumerable<Instructor> Instructors { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
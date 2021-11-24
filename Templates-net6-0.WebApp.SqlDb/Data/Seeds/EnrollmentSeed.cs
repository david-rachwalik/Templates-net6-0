using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;
using System;
using System.Linq;

namespace Templates_net6_0.WebApp.SqlDb.Data.Seeds
{
    public static class EnrollmentSeed
    {
        public static void Initialize(MainContext context)
        {
            // Look for any enrollments
            if (context.Enrollments.Any())
            {
                return;   // DB has been seeded
            }

            var enrollments = new Enrollment[]
            {
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID,
                    Grade = Grade.A
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Microeconomics" ).CourseID,
                    Grade = Grade.C
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alexander").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Calculus" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Trigonometry" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Alonso").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Composition" ).CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Anand").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Chemistry" ).CourseID
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Anand").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Microeconomics").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Barzdukas").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Chemistry").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Li").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Composition").CourseID,
                    Grade = Grade.B
                },
                new Enrollment {
                    StudentID = context.Students.Single(s => s.LastName == "Justice").ID,
                    CourseID = context.Courses.Single(c => c.Title == "Literature").CourseID,
                    Grade = Grade.B
                }
            };

            foreach (Enrollment e in enrollments)
            {
                var enrollmentInDataBase = context.Enrollments.Where(
                    s =>
                        s.Student.ID == e.StudentID &&
                        s.Course.CourseID == e.CourseID).SingleOrDefault();
                if (enrollmentInDataBase == null)
                {
                    context.Enrollments.Add(e);
                }
            }
            context.SaveChanges();
        }
    }
}
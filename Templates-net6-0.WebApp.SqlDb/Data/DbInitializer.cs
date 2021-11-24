using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Templates_net6_0.WebApp.SqlDb.Data.Seeds;
using Templates_net6_0.WebApp.SqlDb.Models;

namespace Templates_net6_0.WebApp.SqlDb.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MainContext context)
        {
            Seed(context);
        }

        public static void Seed(MainContext context)
        {
            MovieSeed.Initialize(context);
            StudentSeed.Initialize(context);
            InstructorSeed.Initialize(context);
            DepartmentSeed.Initialize(context);
            CourseSeed.Initialize(context);
            OfficeAssignmentSeed.Initialize(context);
            EnrollmentSeed.Initialize(context);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Templates_net6_0.WebApp.SqlDb.Data;
using Templates_net6_0.WebApp.SqlDb.Models;

namespace Templates_net6_0.WebApp.SqlDb.Data.Seeds;

public static class InstructorSeed
{
    public static void Initialize(MainContext context)
    {
        // Look for any instructors
        if (context.Instructors.Any())
        {
            return;   // DB has been seeded
        }

        var instructors = new Instructor[]
        {
            new Instructor { FirstMidName = "Kim",     LastName = "Abercrombie",
                HireDate = DateTime.Parse("1995-03-11") },
            new Instructor { FirstMidName = "Fadi",    LastName = "Fakhouri",
                HireDate = DateTime.Parse("2002-07-06") },
            new Instructor { FirstMidName = "Roger",   LastName = "Harui",
                HireDate = DateTime.Parse("1998-07-01") },
            new Instructor { FirstMidName = "Candace", LastName = "Kapoor",
                HireDate = DateTime.Parse("2001-01-15") },
            new Instructor { FirstMidName = "Roger",   LastName = "Zheng",
                HireDate = DateTime.Parse("2004-02-12") }
        };

        context.Instructors.AddRange(instructors);
        context.SaveChanges();
    }
}
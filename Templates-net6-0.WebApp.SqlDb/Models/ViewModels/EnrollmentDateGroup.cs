using System.ComponentModel.DataAnnotations;

namespace Templates_net6_0.WebApp.SqlDb.Models.ViewModels;

public class EnrollmentDateGroup
{
    [DataType(DataType.Date)]
    public DateTime? EnrollmentDate { get; set; }

    public int StudentCount { get; set; }
}
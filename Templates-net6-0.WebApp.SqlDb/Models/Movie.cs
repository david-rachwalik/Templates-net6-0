using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Templates_net6_0.WebApp.SqlDb.Models;

public class Movie
{
    public int ID { get; set; }

    [Required]
    [StringLength(60, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Range(1, 100)]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [Required]
    [StringLength(30)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
    public string Genre { get; set; } = string.Empty;

    [Required]
    [StringLength(5)]
    [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
    public string Rating { get; set; } = string.Empty;
}
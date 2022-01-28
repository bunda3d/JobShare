using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobShare.Models
{
  public class Job
  {
    public int Id { get; set; }

    [Display(Name = "Job Code")]
    [Column(TypeName = "varchar(20)")]
    public string? Code { get; set; }

    [Display(Name = "Job Title")]
    [Column(TypeName = "varchar(200)")]
    public string? Title { get; set; }

    [Display(Name = "Share Headline")]
    [Column(TypeName = "varchar(200)")]
    public string? SocialTitle { get; set; }

    [Display(Name = "Share Description")]
    [Column(TypeName = "varchar(1200)")]
    public string? SocialDescription { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Release Date")]
    public DateTime ReleaseDate { get; set; }

    [Column(TypeName = "varchar(50)")]
    public string? Department { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? HourlyPayBase { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? HourlyPayMax { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalaryBase { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? SalaryMax { get; set; }
  }
}
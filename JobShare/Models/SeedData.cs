using JobShare.Data;
using Microsoft.EntityFrameworkCore;

namespace JobShare.Models
{
  public class SeedData
  {
    public static void Initialize(IServiceProvider serviceProvider)
    {
      using (var context = new JobShareContext(
          serviceProvider.GetRequiredService<
              DbContextOptions<JobShareContext>>()))
      {
        // Look for any Jobs.
        //if (context.Job.Any())
        //{
        //  return;   // DB has been seeded
        //}

        context.Job.AddRange(
            new Job
            {
              Code = "123",
              Title = "Applications Developer",
              SocialTitle = ".NET App Developer",
              SocialDescription = "Excellent opportunity with established transportation company. More sentences and information here. ",
              ReleaseDate = DateTime.Parse("2022-1-31"),
              Department = "Information Systems",
              HourlyPayBase = 10.00M,
              HourlyPayMax = 15.00M,
              SalaryBase = null,
              SalaryMax = null
            },
            new Job
            {
              Code = "678",
              Title = "Administrative Assistant",
              SocialTitle = "Administrative Assistant - Full Time",
              SocialDescription = "Join a great company where you can apply your skillset among professionals like you. Competitive benefits and pay packages ",
              ReleaseDate = DateTime.Parse("2022-2-13"),
              Department = "Executive",
              HourlyPayBase = null,
              HourlyPayMax = null,
              SalaryBase = 20000.00M,
              SalaryMax = 60000.00M
            },

            new Job
            {
              Code = "345",
              Title = "DBA II",
              SocialTitle = "DataBase Administrator (DBA) - Full Time",
              SocialDescription = "An excellent Information Systems Professional opportunity with a long-established transportation leader! ",
              ReleaseDate = DateTime.Parse("2022-3-13"),
              Department = "Information Systems",
              HourlyPayBase = 19.00M,
              HourlyPayMax = 149.00M
            },

            new Job
            {
              Code = "159",
              Title = "Assistant",
              SocialTitle = "Assistant - Full Time",
              SocialDescription = "Join a long-established company. Competitive benefits and pay packages ",
              ReleaseDate = DateTime.Parse("2022-1-13"),
              Department = "Information Systems",
              HourlyPayBase = null,
              HourlyPayMax = null,
              SalaryBase = 20000.00M,
              SalaryMax = 45000.00M
            }
        );
        context.SaveChanges();
      }
    }
  }
}
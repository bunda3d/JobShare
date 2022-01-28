using Microsoft.AspNetCore.Mvc.Rendering;

namespace JobShare.Models.ViewModels
{
  public class JobDepartmentViewModel
  {
    public List<Job>? Jobs { get; set; }
    public SelectList? Departments { get; set; }
    public string? JobDepartment { get; set; }
    public string? SearchString { get; set; }
  }
}
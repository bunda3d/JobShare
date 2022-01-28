#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JobShare.Data;
using JobShare.Models;
using JobShare.Models.ViewModels;

namespace JobShare.Controllers
{
  public class JobsController : Controller
  {
    private readonly JobShareContext _context;

    public JobsController(JobShareContext context)
    {
      _context = context;
    }

    // GET: Jobs
    public async Task<IActionResult> Index(string jobDepartment, string searchString)
    {
      //use LINQ to get list of genres
      IQueryable<string> deptQuery = from d in _context.Job
                                     orderby d.Department
                                     select d.Department;
      var jobs = from d in _context.Job
                 select d;

      if (!string.IsNullOrEmpty(searchString))
      {
        jobs = jobs.Where(s => s.Title!.Contains(searchString));
      }

      if (!string.IsNullOrEmpty(jobDepartment))
      {
        jobs = jobs.Where(x => x.Department == jobDepartment);
      }

      var jobDeptVM = new JobDepartmentViewModel
      {
        Departments = new SelectList(await deptQuery.Distinct().ToListAsync()),
        Jobs = await jobs.ToListAsync()
      };

      return View(jobDeptVM);
    }

    //// GET: Jobs
    //public async Task<IActionResult> Index(string searchString)
    //{
    //  var jobs = from j in _context.Job select j;

    //  if (!String.IsNullOrEmpty(searchString))
    //  {
    //    jobs = jobs.Where(s => s.Title!.Contains(searchString));
    //  }

    //  //return View(await _context.Job.ToListAsync());

    //  return View(await jobs.ToListAsync());
    //}

    // GET: Jobs/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.Job
          .FirstOrDefaultAsync(m => m.Id == id);
      if (job == null)
      {
        return NotFound();
      }

      return View(job);
    }

    // GET: Jobs/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Jobs/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Code,Title,SocialTitle,SocialDescription,ReleaseDate,Department,HourlyPayBase,HourlyPayMax,SalaryBase,SalaryMax")] Job job)
    {
      if (ModelState.IsValid)
      {
        _context.Add(job);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(job);
    }

    // GET: Jobs/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.Job.FindAsync(id);
      if (job == null)
      {
        return NotFound();
      }
      return View(job);
    }

    // POST: Jobs/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Code,Title,SocialTitle,SocialDescription,ReleaseDate,Department,HourlyPayBase,HourlyPayMax,SalaryBase,SalaryMax")] Job job)
    {
      if (id != job.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(job);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!JobExists(job.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return View(job);
    }

    // GET: Jobs/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var job = await _context.Job
          .FirstOrDefaultAsync(m => m.Id == id);
      if (job == null)
      {
        return NotFound();
      }

      return View(job);
    }

    // POST: Jobs/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var job = await _context.Job.FindAsync(id);
      _context.Job.Remove(job);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool JobExists(int id)
    {
      return _context.Job.Any(e => e.Id == id);
    }
  }
}
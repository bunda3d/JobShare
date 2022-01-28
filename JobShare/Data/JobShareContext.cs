#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobShare.Models;

namespace JobShare.Data
{
    public class JobShareContext : DbContext
    {
        public JobShareContext (DbContextOptions<JobShareContext> options)
            : base(options)
        {
        }

        public DbSet<JobShare.Models.Job> Job { get; set; }
    }
}

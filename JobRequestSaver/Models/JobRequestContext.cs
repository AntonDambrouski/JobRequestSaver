using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AboutFindingJob.Models
{
    public class JobRequestContext : DbContext
    {
        public DbSet<JobRequest> jobRequests { get; set; }
        public JobRequestContext(IConfiguration configuration, DbContextOptions<JobRequestContext> options) : base(options) 
        {
        }
    }
}

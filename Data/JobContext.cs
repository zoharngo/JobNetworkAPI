using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobNetworkAPI.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobNetworkAPI.Data
{
    public class JobContext: DbContext
    {
        public JobContext(DbContextOptions<JobContext> options) : base(options)
        {}
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }

    }
}

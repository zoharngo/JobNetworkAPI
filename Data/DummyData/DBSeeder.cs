using JobNetworkAPI.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JobNetworkAPI.Data
{
    public class DBSeeder
    {
        private readonly JobContext _ctx;

        public DBSeeder(JobContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.JobTitles.Any())
            {
                // Getting Dummy Data for JobTitles
                var filepath = Path.Combine("Data/DummyData/JobTitles.json");
                var json = File.ReadAllText(filepath);
               
                var JobTitles = JsonConvert.DeserializeObject<IEnumerable<JobTitle>>(json);
                _ctx.JobTitles.AddRange(JobTitles);

                if (!_ctx.Jobs.Any())
                {
                    filepath = Path.Combine("Data/DummyData/Jobs.json");
                    json = File.ReadAllText(filepath);

                    var Jobs = JsonConvert.DeserializeObject<IEnumerable<Job>>(json);
                   
                    _ctx.Jobs.AddRange(Jobs);
                }
         
                _ctx.SaveChanges();
            }
        }
    }
}

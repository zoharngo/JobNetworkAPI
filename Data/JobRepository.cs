using JobNetworkAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JobNetworkAPI.Data
{

    public class JobRepository : IJobRepository
    {
        private readonly JobContext _ctx;
        private readonly ILogger<JobRepository> _logger;

        public JobRepository(JobContext ctx, ILogger<JobRepository> logger)
        {
            _logger = logger;
            _ctx = ctx;
        }

        public async Task<ActionResult<IEnumerable<JobTitle>>> GetJobTitles()
        {
            try
            {
                var jobTitles = await _ctx.JobTitles.ToListAsync();
                _logger.LogInformation(message: "{Count} Job titles Found: {jobTitles}", jobTitles.Count, JsonConvert.SerializeObject(jobTitles));
                return jobTitles;
            }
            catch (Exception e)
            {
                _logger.LogError(message: "Failed to retrieve Job Titles with error: {e}",e.Message);
                throw e;
            }
        }

        public async Task<ActionResult<IEnumerable<Job>>> GetJobsByJobTitleID(string q, int top)
        {
            try
            {
                var JobTitleTextSearch = q != null? q.Trim().ToLower(): "";
                var r = new Regex("^[A-Za-z\\s]+");
                if (r.IsMatch(JobTitleTextSearch))
                {
                    var JobTitlesIds = await _ctx.JobTitles.Where(jobTitle => jobTitle.JobTitleText.ToLower().Contains(JobTitleTextSearch)).
                        Select(jobTitle => jobTitle.JobTitleId).ToListAsync();
                    var jobs = await _ctx.Jobs.Where(job => JobTitlesIds.Contains(job.JobTitleId)).Take(top).ToListAsync();

                    _logger.LogInformation(message: "{Count} Jobs Found: {jobTitles}", jobs.Count, JsonConvert.SerializeObject(jobs));
                   
                    return jobs;
                }
                else
                {
                    throw new Exception($"Invalid Search Input Query '{q}'");
                }
            
            }
            catch (Exception e)
            {
                _logger.LogError(message: "Search failed with error: {e}",e.Message);
                throw e;
            }
        }
    }
}

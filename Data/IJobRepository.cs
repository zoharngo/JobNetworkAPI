using System.Collections.Generic;
using System.Threading.Tasks;
using JobNetworkAPI.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JobNetworkAPI.Data
{
    public interface IJobRepository
    {
        Task<ActionResult<IEnumerable<Job>>> GetJobsByJobTitleID(string q, int limit);
        Task<ActionResult<IEnumerable<JobTitle>>> GetJobTitles();
    }
}
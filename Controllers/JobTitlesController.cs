using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using JobNetworkAPI.Data;
using JobNetworkAPI.Data.Entities;
using Microsoft.Extensions.Logging;

namespace JobNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JobTitlesController : ControllerBase
    {
        private readonly IJobRepository _repository;
        private readonly ILogger<JobTitlesController> _logger;

        public JobTitlesController(IJobRepository repository, ILogger<JobTitlesController> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        // GET: api/JobTitles
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<JobTitle>>> GetJobTitles()
        {
            try
            {
                return await _repository.GetJobTitles();
            }
            catch (Exception e)
            {
                _logger.LogError($"API Get Job Titles Failed : {e}");
                return BadRequest();
            }
        }
    }
}

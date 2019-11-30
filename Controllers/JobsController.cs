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
    public class JobsController : ControllerBase
    {
        private readonly IJobRepository _repository;
        private readonly ILogger<JobsController> _logger;

        public JobsController(IJobRepository repository, ILogger<JobsController> logger)
        {
            _repository = repository;
            _logger = logger;
        }


        // GET: search?JobTitleId=[:JobTitleId]
        [HttpGet("search")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Job>>> Get([FromQuery(Name = "q")] string q,
            [FromQuery(Name = "top")] int top)
        {
            try
            {
                return await _repository.GetJobsByJobTitleID(q, top);
            }
            catch (Exception e)
            {
                _logger.LogError($"API Search query Failed : {e}");
                return BadRequest();
            }
        }

    }
}

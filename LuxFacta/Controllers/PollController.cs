using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LuxFacta.Entities;
using LuxFacta.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LuxFacta.Controllers
{
    [Produces("application/json")]
    [Route("api/")]
    public class PollController : Controller
    {
        private readonly IPollService _luxFactaService;

        public PollController(IPollService luxFactaService)
        {
            _luxFactaService = luxFactaService;
        }

        [Route("poll/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetPollAsync(int id)
        {
            var result = await _luxFactaService.GetSurveyAsync(id);

            if (String.IsNullOrEmpty(result.poll_description))
                return NotFound("Enquete não encontrada");

            return Ok(result);
        }

        [Route("poll")]
        [HttpPost]
        public async Task<IActionResult> PostPollAsync([FromBody]SurveyResponse _survey)
        {
            return Ok(await _luxFactaService.PostSurveyAsync(_survey));
        }

        [Route("poll/{id}/vote")]
        [HttpPost]
        public async Task<IActionResult> PostVoteAsync([FromBody]Request_Option_id request, int id)
        {
            if (await _luxFactaService.PostVoteAsync(request.option_id, id) == 0)
                return NotFound("Enquete não encontrada");

            return Ok();
        }

        [Route("poll/{id}/stats")]
        [HttpGet]
        public async Task<IActionResult> GetStatsAsync(int id)
        {            
            return Ok(await _luxFactaService.GetStatsAsync(id));
        }


    }
}
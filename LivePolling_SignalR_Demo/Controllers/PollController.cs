using LivePolling_SignalR_Demo.Models;
using LivePolling_SignalR_Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace LivePolling_SignalR_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollController : ControllerBase
    {
        private readonly IPollService _pollService;

        // Constructor Injection to get our Service
        public PollController(IPollService pollService)
        {
            _pollService = pollService;
        }

        [HttpPost("create")]
        public IActionResult Create(string question, [FromBody] List<string> options)
        {
            _pollService.CreatePoll(question, options);
            return Ok("Poll created successfully!");
        }

        [HttpPost("vote")]
        public IActionResult Vote(int id, string option)
        {
            _pollService.Vote(id, option);
            return Ok("Vote recorded!");
        }

        [HttpGet("{id}")]
        public IActionResult GetResults(int id)
        {
            var poll = _pollService.GetPoll(id);
            if (poll == null) return NotFound("Poll not found.");
            return Ok(poll);
        }
    }
}
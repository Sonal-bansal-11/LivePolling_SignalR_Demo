using LivePolling_SignalR_Demo.Models;
using LivePolling_SignalR_Demo.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace LivePolling_SignalR_Demo.Services
{
    public class PollService : IPollService
    {
        private readonly List<Poll> _polls = new();
        private readonly IHubContext<PollHub> _hubContext;

        public PollService(IHubContext<PollHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void CreatePoll(string question, List<string> options)
        {
            var poll = new Poll { Id = _polls.Count + 1, Question = question };
            options.ForEach(opt => poll.Options[opt] = 0);
            _polls.Add(poll);
        }

        public void Vote(int pollId, string option)
        {
            var poll = _polls.FirstOrDefault(p => p.Id == pollId);
            if (poll != null && poll.Options.ContainsKey(option))
            {
                poll.Options[option]++;
                // 🔥 THE MAGIC STEP: Push update to ALL users instantly!
                _hubContext.Clients.All.SendAsync("ReceiveVoteUpdate", pollId, option, poll.Options[option]);
            }
        }

        public Models.Poll? GetPoll(int id) => _polls.FirstOrDefault(p => p.Id == id);
    }
}

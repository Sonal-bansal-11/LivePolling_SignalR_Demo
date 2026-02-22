using Microsoft.AspNetCore.SignalR;

namespace LivePolling_SignalR_Demo.Hubs
{
    public class PollHub : Hub
    {
        // This is like a chat room. When a vote happens, 
        // the server calls "UpdateVotes" on every connected user's screen.
        public async Task SendVoteUpdate(int pollId, string option, int count)
        {
            await Clients.All.SendAsync("ReceiveVoteUpdate", pollId, option, count);
        }
    }
}

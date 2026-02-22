namespace LivePolling_SignalR_Demo.Services
{
    public interface IPollService
    {
        void CreatePoll(string question, List<string> options);
        void Vote(int pollId, string option);
        Models.Poll? GetPoll(int id);
    }
}

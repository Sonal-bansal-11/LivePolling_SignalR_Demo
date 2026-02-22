namespace LivePolling_SignalR_Demo.Models
{
    public class Poll
    {
        public int Id { get; set; }
        public string Question { get; set; } = string.Empty;
        // Dictionary to store Option Name and its Vote Count
        public Dictionary<string, int> Options { get; set; } = new();
    }
}
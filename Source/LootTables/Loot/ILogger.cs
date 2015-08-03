namespace Loot
{
    public interface ILogger //TODO: Could use Common.Logging
    {
        void LogItemReceived(string player, string item);
    }
}
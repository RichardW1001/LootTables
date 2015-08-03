using System.Diagnostics;

namespace Loot
{
    public class DebugLogger : ILogger
    {
        public void LogItemReceived(string player, string item)
        {
            Debug.WriteLine("LOOT SERVICE: {0} received {1}", player, item);
        }
    }
}
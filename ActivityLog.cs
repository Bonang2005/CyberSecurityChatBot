namespace CybersecurityChatbot_Part3
{
    // This class records all actions the bot has taken
    public static class ActivityLog
    {
        // List to store all log entries
        private static List<string> logs = new List<string>();

        // Add a log entry
        public static void Log(string action)
        {
            string entry = DateTime.Now.ToString("HH:mm:ss") + " - " + action;
            logs.Add(entry);
        }

        // Get all log entries
        public static List<string> GetLogs()
        {
            return logs;
        }

        // Get logs as a single string
        public static string GetLogsAsString()
        {
            if (logs.Count == 0)
                return "No activity recorded yet.";

            string result = "";
            foreach (string log in logs)
            {
                result += log + "\n";
            }
            return result;
        }
    }
}
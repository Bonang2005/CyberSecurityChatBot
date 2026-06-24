namespace CybersecurityChatbot_Part3
{
    // This class stores information about a single task
    public class TaskItem
    {
        // Automatic properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Reminder { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime DateAdded { get; set; }

        // Constructor
        public TaskItem(string title, string description, string reminder)
        {
            Title = title;
            Description = description;
            Reminder = reminder;
            IsCompleted = false;
            DateAdded = DateTime.Now;
        }
    }
}

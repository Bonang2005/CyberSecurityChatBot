namespace ChatSecurityChatBot_2
{
    
    public class UserProfile
    {
        // Automatic properties
        public string Name { get; set; }
        public int MessageCount { get; set; }
        public string FavouriteTopic { get; set; }
        public string Sentiment { get; set; }

        // Constructor
        public UserProfile(string name)
        {
            Name = name;
            MessageCount = 0;
            FavouriteTopic = "None";
            Sentiment = "neutral";
        }
    }
}

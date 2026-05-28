namespace ChatSecurityChatBot_2
{
    // This class stores information about the user during the chat session
    public class UserProfile
    {
        // Automatic properties
        public string Name { get; set; }
        public int MessageCount { get; set; }
        public string FavouriteTopic { get; set; }
        public string Sentiment { get; set; }

        // Constructor - runs when a new UserProfile is created
        public UserProfile(string name)
        {
            Name = name;
            MessageCount = 0;
            FavouriteTopic = "None";
            Sentiment = "neutral";
        }
    }
}

namespace CybersecurityChatbot_Part3
{
    // This class handles all the chatbot responses
    public static class ChatBot
    {
        // Random object for picking random responses
        private static Random random = new Random();

        // Lists of random responses for each topic
        private static List<string> passwordResponses = new List<string>
        {
            "Use at least 12 characters with letters, numbers and symbols.",
            "Never reuse the same password on different websites.",
            "Use a password manager like Bitwarden or 1Password.",
            "Enable Two Factor Authentication wherever possible."
        };

        private static List<string> phishingResponses = new List<string>
        {
            "Always check the sender's full email address before clicking anything.",
            "Hover over links to see the real URL before clicking.",
            "Legitimate companies never ask for your password by email.",
            "Be suspicious of urgent or threatening messages."
        };

        private static List<string> browsingResponses = new List<string>
        {
            "Always look for HTTPS and the padlock in the address bar.",
            "Use a VPN on public Wi-Fi networks.",
            "Keep your browser and software updated at all times.",
            "Do not download software from unknown websites."
        };

        private static List<string> privacyResponses = new List<string>
        {
            "Limit the personal information you share on social media.",
            "Check what permissions your apps have and remove unnecessary ones.",
            "Use a separate email address for sign ups and newsletters.",
            "Read cookie settings and opt out of tracking where possible."
        };

        // Main method that processes user input and returns a response
        public static string GetResponse(string input, UserProfile user)
        {
            // String manipulation - convert to lowercase
            string lowerInput = input.ToLower().Trim();

            // Count the message
            user.MessageCount++;

            // Log the message
            ActivityLog.Log("User said: " + input);

            // Sentiment detection
            if (lowerInput.Contains("worried") || lowerInput.Contains("scared") || lowerInput.Contains("anxious"))
            {
                user.Sentiment = "worried";
                return "It is completely understandable to feel that way. Cybersecurity can feel overwhelming but I am here to help. " + GetRandomResponse(passwordResponses);
            }

            if (lowerInput.Contains("frustrated") || lowerInput.Contains("angry") || lowerInput.Contains("annoyed"))
            {
                user.Sentiment = "frustrated";
                return "I understand your frustration. Let me help make things clearer for you. " + GetRandomResponse(phishingResponses);
            }

            if (lowerInput.Contains("curious") || lowerInput.Contains("interested") || lowerInput.Contains("want to know"))
            {
                user.Sentiment = "curious";
                return "I love your curiosity! Here is something interesting: " + GetRandomResponse(browsingResponses);
            }

            // Memory and recall - follow up questions
            if (lowerInput.Contains("tell me more") || lowerInput.Contains("give me another tip") || lowerInput.Contains("more"))
            {
                if (user.FavouriteTopic == "Passwords")
                    return "Here is another password tip: " + GetRandomResponse(passwordResponses);
                else if (user.FavouriteTopic == "Phishing")
                    return "Here is another phishing tip: " + GetRandomResponse(phishingResponses);
                else if (user.FavouriteTopic == "Safe Browsing")
                    return "Here is another browsing tip: " + GetRandomResponse(browsingResponses);
                else if (user.FavouriteTopic == "Privacy")
                    return "Here is another privacy tip: " + GetRandomResponse(privacyResponses);
                else
                    return "What topic would you like more tips on? Type password, phishing, browsing or privacy.";
            }

            // Goodbye
            if (lowerInput == "exit" || lowerInput == "bye")
                return "Goodbye " + user.Name + "! Stay safe online!";

            // Greeting
            if (lowerInput == "hello" || lowerInput == "hi" || lowerInput == "hey")
                return "Hey " + user.Name + "! How can I help you stay secure today?";

            // How are you
            if (lowerInput.Contains("how are you"))
                return "I am running at full security capacity! How can I help you, " + user.Name + "?";

            // Purpose
            if (lowerInput.Contains("purpose") || lowerInput.Contains("what do you do"))
                return "I am a Cybersecurity Awareness Chatbot! I help you learn about password safety, phishing, safe browsing and privacy.";

            // Help menu
            if (lowerInput.Contains("help") || lowerInput.Contains("what can i ask"))
                return "Here are the topics I can help with, " + user.Name + ":\n\n" +
                       "  password  - Strong passwords and 2FA\n" +
                       "  phishing  - Spotting fake emails\n" +
                       "  browsing  - Safe browsing and VPNs\n" +
                       "  privacy   - Protecting your personal data\n" +
                       "  add task  - Add a cybersecurity task\n" +
                       "  view tasks - View all your tasks\n" +
                       "  activity log - View all bot activity\n\n" +
                       "You can also type 'tell me more' for another tip!";

            // Password
            if (lowerInput.Contains("password") || lowerInput.Contains("2fa"))
            {
                user.FavouriteTopic = "Passwords";
                return "Password Tip: " + GetRandomResponse(passwordResponses);
            }

            // Phishing
            if (lowerInput.Contains("phish") || lowerInput.Contains("scam") || lowerInput.Contains("spam"))
            {
                user.FavouriteTopic = "Phishing";
                return "Phishing Tip: " + GetRandomResponse(phishingResponses);
            }

            // Safe browsing
            if (lowerInput.Contains("brows") || lowerInput.Contains("vpn") || lowerInput.Contains("virus"))
            {
                user.FavouriteTopic = "Safe Browsing";
                return "Safe Browsing Tip: " + GetRandomResponse(browsingResponses);
            }

            // Privacy
            if (lowerInput.Contains("privacy") || lowerInput.Contains("personal data"))
            {
                user.FavouriteTopic = "Privacy";
                return "Privacy Tip: " + GetRandomResponse(privacyResponses);
            }

            // Remember user name
            if (lowerInput.Contains(user.Name.ToLower()))
            {
                return "Yes " + user.Name + "? How can I help you?";
            }

            // Memory recall
            if (lowerInput.Contains("what do you remember") || lowerInput.Contains("what do you know about me"))
            {
                return "I remember that your name is " + user.Name +
                       " and your favourite topic is " + user.FavouriteTopic + "!";
            }

            // Fallback
            return "I didn't quite understand that, " + user.Name + ". Could you rephrase? Type 'help' to see available topics.";
        }

        // This method picks a random response from a list
        private static string GetRandomResponse(List<string> responses)
        {
            int index = random.Next(responses.Count);
            return responses[index];
        }
    }
}

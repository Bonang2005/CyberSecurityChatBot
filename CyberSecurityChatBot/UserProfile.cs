using System;
using System.Collections.Generic;
using System.Text;

namespace CyberSecurityChatBot
{
    public class UserProfile
    {
        public string Name { get; set; }//Automatic properties
        public int MessageCount {  get; set; }
        public string Topic { get; set; }

        public UserProfile(string name)// Contructor
        {
            Name = name;
            MessageCount = 0;
            Topic = string.Empty;

        }
    }
}

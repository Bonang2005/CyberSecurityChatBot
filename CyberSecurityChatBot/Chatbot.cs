using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using static System.Console;

namespace CyberSecurityChatBot
{
    public static class Chatbot
    {
        public static void Start(string name)
        {
            UserProfile user = new UserProfile(name);
            bool running = true;

            while (running) {
                Display.ShowDivider();
                ForegroundColor = ConsoleColor.Cyan;
                WriteLine(user.Name);
                ResetColor();
                string input = ReadLine();

                if (string.IsNullOrEmpty(input)) // vlidation
                {
                    Display.ShowError("Please enter a message.");
                    continue;
                }
                if (input.Trim().Length > 200)
                {
                    Display.ShowError("Message is too long. Please keep it under 200 Charecters.");
                    continue;
                }
                user.MessageCount++;
                string lowerInput = input.ToLower();
                if (lowerInput == "exit")
                {
                    Display.Chat("Goodbye," + user.Name + ". Stay Safe Online.", ConsoleColor.Yellow);
                    Display.ShowExit(user);
                    running = false;
                }
                else if (lowerInput.Contains("how are you"))
                {
                    Display.Chat(" I am running at peak capacity! How can i help you ?", ConsoleColor.White);
                }
                else if (lowerInput.Contains("what is your purpose") || lowerInput.Contains("what do you do"))
                {
                    Display.Chat("I am a Cyber Awareness Bot! I help you learn about password safety, phishing and safe browsing ");

                    //  the help menu
                }
                else if (lowerInput.Contains("help") || lowerInput.Contains("what can i ask"))
                {
                    Display.Chat("Here are the topics I can help with:\n\n  password  - Strong passwords and 2FA\n  phishing  - Spotting fake emails\n  browsing  - Safe browsing and VPNs\n  privacy   - Protecting your personal data", ConsoleColor.Cyan);
                }
                else if (lowerInput.Contains("password"))
                {
                    user.Topic = "Passwords";
                    Display.Chat("Password tips:\n\n- Use at least 12 characters.\n\n- Never reuse passwords.", ConsoleColor.Blue);
                }
                else if (lowerInput.Contains("phishing"))
                {
                    user.Topic = "Phishing";
                    Display.Chat("Phishing Tips: \n\n - Check the sender email address.\n\n - Hover your mouse before you click.\n\n - Do not open attachments.", ConsoleColor.Cyan);
                }
                else if (lowerInput.Contains("browsing"))
                {
                    user.Topic = "Safe Browsing";
                    Display.Chat("Safe Browsing Tips:\n\n - Always keep software and browser updated.\n\n - Use a password manager.\n\n - Verify URLs and Website Legitimacy.");
                }
                else
                {
                    Display.Chat("I didn't understand that. Could You please rephrase? Type 'help' to see available topics.", ConsoleColor.DarkRed);
                }

                    }
                }
            }
        }
    
    


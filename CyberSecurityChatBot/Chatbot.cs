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
                ForegroundColor = ConsoleColor.Yellow;
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
                    Display.Chat("Goodbye," + user.Name + ". Stay Safe Online.", ConsoleColor.DarkYellow);
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
                }
                else if (lowerInput.Contains("password"))
                {
                    user.Topic = "Passwords";
                    Display.Chat("Password tips: Use at least 12 characters.\n Never reuse passwords.", ConsoleColor.DarkBlue);
                }
                else if (lowerInput.Contains("phishing"))
                {
                    user.Topic = "Phishing";
                    Display.Chat("Phishing Tips: Check the sender email address.\n Hover your mouse before you click.\n Do not open attachments.", ConsoleColor.DarkBlue);
                }
                else if (lowerInput.Contains("browsing"))
                {
                    user.Topic = "Safe Browsing";
                    Display.Chat("Safe Browsing Tips: Always keep software and browser updated.\n Use a password manager.\n Verify URLs and Website Legitimacy.");
                }
                else
                {
                    Display.Chat("I didn't understand that. Could You please rephrase? Type 'help' to see available topics.", ConsoleColor.DarkRed);
                        }

                    }
                }
            }
        }
    
    


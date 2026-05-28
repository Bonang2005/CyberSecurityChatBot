using CyberSecurityChatBot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Speech.Synthesis;

AudioPlayer.playgreeting();
Display.ShowLogo();
WriteLine("Enter your name:");
string name = ReadLine();
ForegroundColor = ConsoleColor.Cyan;

while (string.IsNullOrEmpty(name))
{
    ForegroundColor = ConsoleColor.Red;
    WriteLine("please enter your name.");
    ResetColor();
    Write("Enter your name:");
    name = ReadLine();
}
name = char.ToUpper(name[0]) + name.Substring(1). ToLower();
Display.ShowWelcome(name);
Chatbot.Start(name);//To start the chatbot

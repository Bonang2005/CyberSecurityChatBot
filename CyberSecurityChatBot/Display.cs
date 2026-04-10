using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using static System.Console;

namespace CyberSecurityChatBot
{
    public static class Display
    {
        public static void ShowLogo()
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;

            WriteLine("  ____                   ____      _               ____        _   \r\n | __ )  ___  ___       / ___|   _| |__   ___ _ __| __ )  ___ | |_ \r\n |  _ \\ / _ \\/ _ \\_____| |  | | | | '_ \\ / _ \\ '__|  _ \\ / _ \\| __|\r\n | |_) |  __/  __/_____| |__| |_| | |_) |  __/ |  | |_) | (_) | |_ \r\n |____/ \\___|\\___|      \\____\\__, |_.__/ \\___|_|  |____/ \\___/ \\__|\r\n                             |___/                                 ");
            WriteLine("              Keeping you safe online           ");
            WriteLine("               Cybersecurity Awareness Bot      ");
            ResetColor();
        }
        public static void ShowWelcome(string name)
        {
            WriteLine();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("==============================================================");
            WriteLine(" Welcome," + name + "!");
            WriteLine("I am your Cybersecurity Awareness bot.");
            WriteLine("Type 'help' to see what i can help you with.");
            WriteLine("Type 'exit' to exit.");
            WriteLine("==============================================================");
            ResetColor();
        }
        public static void Chat(string message, ConsoleColor colour = ConsoleColor.White)
        {
            ForegroundColor = ConsoleColor.Magenta;
            WriteLine("[CyberBot]");
            ForegroundColor = colour;
            foreach (char c in message)  // for the typing effect
            {
                Write(c);
                Thread.Sleep(16);
            }
            ResetColor();
        }
        public static void ShowDivider()
        {
            ForegroundColor = ConsoleColor.Yellow;
            WriteLine("");
            ResetColor();

        }
        public static void ShowError(string message)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Error: {message}");
            ResetColor();
        }
        public static void ShowExit(UserProfile user)
        {
            WriteLine();
            ForegroundColor = ConsoleColor.DarkYellow;
           
            WriteLine("=======================================================");
            WriteLine(" REMEMBER! ALWAYS BE CAUTIUS ONLINE !!");
            WriteLine("=======================================================");
            ResetColor();



        }
    }
}

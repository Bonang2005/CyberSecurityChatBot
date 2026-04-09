using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Text;
using static System.Console;

namespace CyberSecurityChatBot
{
    
}
public static class AudioPlayer
{
    public static void playgreeting()
    {
        try
        {

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 100;//For the volume
            synthesizer.Speak("Hello, welcome to the Cybersecurity Awareness Bot. I am her to help you saty safe online.");
        }
        catch (Exception ex) 
        {
            ForegroundColor = ConsoleColor.White;
            WriteLine("Audio could not play the welcoming " + ex.Message);
            ResetColor();
            
    }
}

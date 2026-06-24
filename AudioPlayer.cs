using System.Speech.Synthesis;

namespace CybersecurityChatbot_Part3
{
    // This class plays the voice greeting when the app starts
    public static class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                // Create a speech synthesizer
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();

                // Set the volume and speed
                synthesizer.Volume = 100;
                synthesizer.Rate = 0;

                // Speak the greeting
                synthesizer.Speak("Hello! Welcome to the Cybersecurity Awareness Chatbot. I am here to help you stay safe online.");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Could not play greeting: " + ex.Message);
            }
        }
    }
}
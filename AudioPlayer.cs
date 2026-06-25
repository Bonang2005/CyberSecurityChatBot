using System.Media;

namespace CybersecurityChatbot_Part3
{
    
    public static class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                //  WAV file
                string wavFile = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                
                if (!System.IO.File.Exists(wavFile))
                    return;

                // Play the WAV file
                SoundPlayer player = new SoundPlayer(wavFile);
                player.Play();
            }
            catch
            {
                
                return;
            }
        }
    }
}
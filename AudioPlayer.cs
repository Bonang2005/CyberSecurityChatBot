using System.Media;
using System.Windows;

namespace ChatSecurityChatBot_2
{
    // This class plays the voice greeting when the app starts
    public static class AudioPlayer
    {
        public static void PlayGreeting()
        {
            try
            {
                //  the path of the WAV file
                string wavFile = System.IO.Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory, "greeting.wav");

                
                if (!System.IO.File.Exists(wavFile))
                {
                    MessageBox.Show("greeting.wav not found!");
                    return;
                }

                // Plays the WAV file
                SoundPlayer player = new SoundPlayer(wavFile);
                player.Play();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not play greeting: " + ex.Message);
            }
        }
    }
}
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ChatSecurityChatBot_2
{
    public partial class MainWindow : Window
    {
        // User profile to track session info
        private UserProfile user;

        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting
            AudioPlayer.PlayGreeting();

            // Ask for the user's name
            string name = Microsoft.VisualBasic.Interaction.InputBox(
                "Welcome! What is your name?",
                "Cybersecurity Chatbot",
                "");

            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                name = "User";

            // String manipulation - capitalise first letter
            name = char.ToUpper(name[0]) + name.Substring(1).ToLower();

            
            user = new UserProfile(name);

            AddBotMessage("Welcome, " + user.Name + "!");
            AddBotMessage("Type 'help' to see what I can do.");
            AddBotMessage("Type 'bye' to exit.");
        }

       
        private void sendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        
        private void userInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendMessage();
            }
        }

        // This method sends the message and displays the response
        private void SendMessage()
        {
            string input = userInput.Text.Trim();

            // Validation
            if (string.IsNullOrWhiteSpace(input))
            {
                MessageBox.Show("Please type a message first!");
                return;
            }

            // Show user message
            AddUserMessage(user.Name + ": " + input);

            // Get response from chatbot
            string response = ChatBot.GetResponse(input, user);

            // Show bot response
            AddBotMessage("[BOT]: " + response);

            // Clear input box
            userInput.Text = "";

            // Check if user said bye
            if (input.ToLower() == "bye" || input.ToLower() == "exit")
            {
                MessageBox.Show("Session Summary:\n\nName: " + user.Name +
                              "\nMessages Sent: " + user.MessageCount +
                              "\nFavourite Topic: " + user.FavouriteTopic);
                Application.Current.Shutdown();
            }

           
            chatScroller.ScrollToBottom();
        }

        // For timestamp
        private void AddUserMessage(string message)
        {
            TextBlock text = new TextBlock();
            text.Text = DateTime.Now.ToString("HH:mm") + "  " + message;
            text.Foreground = Brushes.Yellow;
            text.FontSize = 14;
            text.Margin = new Thickness(5);
            text.TextWrapping = TextWrapping.Wrap;
            ChatPanel.Children.Add(text);
        }

        // This method adds a bot message with timestamp
        private void AddBotMessage(string message)
        {
            TextBlock text = new TextBlock();
            text.Text = DateTime.Now.ToString("HH:mm") + "  " + message;
            text.Foreground = Brushes.Cyan;
            text.FontSize = 14;
            text.Margin = new Thickness(5);
            text.TextWrapping = TextWrapping.Wrap;
            ChatPanel.Children.Add(text);
        }

        private void userInput_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
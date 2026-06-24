using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CybersecurityChatbot_Part3
{
    public partial class MainWindow : Window
    {
        // User profile to track session info
        private UserProfile? user;

        public MainWindow()
        {
            InitializeComponent();
        }

        // This runs when the window loads
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Initialise database
                DatabaseHelper.InitialiseDatabase();

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

                // Create user profile
                user = new UserProfile(name);

                // Log the session start
                ActivityLog.Log("Session started for user: " + user.Name);

                // Show welcome message
                AddBotMessage("Welcome, " + user.Name + "!");
                AddBotMessage("Type 'help' to see what I can do.");
                AddBotMessage("Type 'bye' to exit.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Startup error: " + ex.Message);
            }
        }

        // This runs when the Send button is clicked
        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            SendMessage();
        }

        // This runs when Enter is pressed in the input box
        private void UserInput_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Enter)
            {
                SendMessage();
            }
        }

        // This method sends the message and displays the response
        private void SendMessage()
        {
            try
            {
                if (user == null) return;

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
                    ActivityLog.Log("Session ended for user: " + user.Name);
                    MessageBox.Show("Session Summary:\n\nName: " + user.Name +
                                  "\nMessages Sent: " + user.MessageCount +
                                  "\nFavourite Topic: " + user.FavouriteTopic);
                    Application.Current.Shutdown();
                }

                // Scroll to bottom
                chatScroller.ScrollToBottom();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Add Task button click
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string title = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter task title:", "Add Task", "");

                if (string.IsNullOrWhiteSpace(title)) return;

                string description = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter task description:", "Add Task", "");

                string reminder = Microsoft.VisualBasic.Interaction.InputBox(
                    "Enter reminder (e.g. 'in 3 days') or leave blank:", "Add Task", "");

                TaskItem task = new TaskItem(title, description, reminder);
                DatabaseHelper.AddTask(task);

                AddBotMessage("[BOT]: Task added!\nTitle: " + title +
                             "\nDescription: " + description +
                             "\nReminder: " + (string.IsNullOrWhiteSpace(reminder) ? "None" : reminder));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding task: " + ex.Message);
            }
        }

        // View Tasks button click
        private void ViewTasks_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<TaskItem> tasks = DatabaseHelper.GetAllTasks();

                if (tasks.Count == 0)
                {
                    AddBotMessage("[BOT]: You have no tasks yet. Click 'Add Task' to add one!");
                    return;
                }

                string taskList = "[BOT]: Here are your tasks:\n\n";
                foreach (TaskItem task in tasks)
                {
                    string status = task.IsCompleted ? "Completed" : "Pending";
                    taskList += "ID: " + task.Id + " | " + task.Title + " | " + status + "\n";
                    taskList += "Description: " + task.Description + "\n";
                    if (!string.IsNullOrWhiteSpace(task.Reminder))
                        taskList += "Reminder: " + task.Reminder + "\n";
                    taskList += "\n";
                }

                AddBotMessage(taskList);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error viewing tasks: " + ex.Message);
            }
        }

        // Activity Log button click
        private void ActivityLog_Click(object sender, RoutedEventArgs e)
        {
            string logs = ActivityLog.GetLogsAsString();
            AddBotMessage("[BOT]: Activity Log:\n\n" + logs);
        }

        // Quiz button click
        private void Quiz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] questions = {
                    "What is the minimum recommended password length?\nA) 6  B) 8  C) 12  D) 4",
                    "What does HTTPS stand for?\nA) Hyper Text Transfer Protocol Secure  B) High Transfer Protocol  C) Hyper Tool Protocol  D) None",
                    "What is phishing?\nA) A sport  B) A cyber attack using fake emails  C) A type of virus  D) A password manager"
                };

                string[] answers = { "C", "A", "B" };

                int score = 0;

                for (int i = 0; i < questions.Length; i++)
                {
                    string answer = Microsoft.VisualBasic.Interaction.InputBox(
                        questions[i], "Cybersecurity Quiz", "");

                    if (answer.ToUpper().Trim() == answers[i])
                    {
                        score++;
                        AddBotMessage("[BOT]: Question " + (i + 1) + ": Correct!");
                    }
                    else
                    {
                        AddBotMessage("[BOT]: Question " + (i + 1) + ": Wrong! The correct answer was " + answers[i]);
                    }
                }

                AddBotMessage("[BOT]: Quiz complete! You scored " + score + " out of " + questions.Length + "!");
                ActivityLog.Log("Quiz completed. Score: " + score + "/" + questions.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in quiz: " + ex.Message);
            }
        }

        // This method adds a user message with timestamp
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
    }
}
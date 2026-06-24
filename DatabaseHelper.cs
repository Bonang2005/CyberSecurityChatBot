using MySql.Data.MySqlClient;

namespace CybersecurityChatbot_Part3
{
    // This class handles all database operations
    public static class DatabaseHelper
    {
        // Connection string
        private static string connectionString =
            "Server=127.0.0.1;Database=cybersecurity_db;Uid=root;Pwd=root1234;";

        // Create the database and table if they don't exist
        public static void InitialiseDatabase()
        {
            try
            {
                string setupConnection = "Server=127.0.0.1;Uid=root;Pwd=root1234;";

                using (MySqlConnection conn = new MySqlConnection(setupConnection))
                {
                    conn.Open();

                    // Create database
                    MySqlCommand cmd = new MySqlCommand(
                        "CREATE DATABASE IF NOT EXISTS cybersecurity_db;", conn);
                    cmd.ExecuteNonQuery();

                    // Use the database
                    cmd.CommandText = "USE cybersecurity_db;";
                    cmd.ExecuteNonQuery();

                    // Create tasks table
                    cmd.CommandText = @"
                        CREATE TABLE IF NOT EXISTS tasks (
                            id INT AUTO_INCREMENT PRIMARY KEY,
                            title VARCHAR(100) NOT NULL,
                            description VARCHAR(500),
                            reminder VARCHAR(100),
                            is_completed BOOLEAN DEFAULT FALSE,
                            date_added DATETIME DEFAULT CURRENT_TIMESTAMP
                        );";
                    cmd.ExecuteNonQuery();
                }

                ActivityLog.Log("Database initialised successfully");
            }
            catch (Exception ex)
            {
                ActivityLog.Log("Database error: " + ex.Message);
            }
        }

        // Add a task to the database
        public static void AddTask(TaskItem task)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "INSERT INTO tasks (title, description, reminder) " +
                                   "VALUES (@title, @description, @reminder)";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@title", task.Title);
                    cmd.Parameters.AddWithValue("@description", task.Description);
                    cmd.Parameters.AddWithValue("@reminder", task.Reminder);
                    cmd.ExecuteNonQuery();
                    ActivityLog.Log("Task added: " + task.Title);
                }
            }
            catch (Exception ex)
            {
                ActivityLog.Log("Error adding task: " + ex.Message);
            }
        }

        // Get all tasks from the database
        public static List<TaskItem> GetAllTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM tasks", conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TaskItem task = new TaskItem(
                            reader["title"].ToString() ?? "",
                            reader["description"].ToString() ?? "",
                            reader["reminder"].ToString() ?? ""
                        );
                        task.Id = Convert.ToInt32(reader["id"]);
                        task.IsCompleted = Convert.ToBoolean(reader["is_completed"]);
                        tasks.Add(task);
                    }
                }
            }
            catch (Exception ex)
            {
                ActivityLog.Log("Error getting tasks: " + ex.Message);
            }

            return tasks;
        }

        // Mark a task as completed
        public static void CompleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "UPDATE tasks SET is_completed = TRUE WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    ActivityLog.Log("Task completed: ID " + id);
                }
            }
            catch (Exception ex)
            {
                ActivityLog.Log("Error completing task: " + ex.Message);
            }
        }

        // Delete a task
        public static void DeleteTask(int id)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(
                        "DELETE FROM tasks WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    ActivityLog.Log("Task deleted: ID " + id);
                }
            }
            catch (Exception ex)
            {
                ActivityLog.Log("Error deleting task: " + ex.Message);
            }
        }
    }
}
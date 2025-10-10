using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using TaskTrackerApp.Models;

namespace TaskTrackerApp
{
    public static class TaskStorage
    {
        private static readonly string filePath = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "tasks.json");

        public static void SaveTasks(List<TaskItem> tasks)
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public static List<TaskItem> LoadTasks()
        {
            if (!File.Exists(filePath)) return new List<TaskItem>();
            var json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTrackerApp.Models
{
    // Represents a single task item in the list
    public class TaskItem
    {
        public string Title { get; set; }         // Task name
        public string Description { get; set; }   // Task details
        public bool IsCompleted { get; set; }     // Whether the task is done
        public string Priority { get; set; } = "Medium"; // Default
        public DateTime CreatedAt { get; set; }   // Timestamp
        public DateTime? DueDate { get; set; }   // Optional due date

        public TaskItem()
        {
            CreatedAt = DateTime.Now;
        }
    }
}

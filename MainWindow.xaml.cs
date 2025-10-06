using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TaskTrackerApp.Models;

namespace TaskTrackerApp
{
    public partial class MainWindow : Window
    {
        private List<TaskItem> allTasks;

        public MainWindow()
        {
            InitializeComponent();
            allTasks = TaskStorage.LoadTasks();
            RefreshList();
            DueDatePicker.SelectedDate = DateTime.Now;
        }

        // Add Task
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            string description = TaskDescriptionBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(description)) return;

            string priority = (PriorityBox.SelectedItem as ComboBoxItem)?.Content.ToString() ?? "Medium";
            DateTime? dueDate = DueDatePicker.SelectedDate;

            TaskItem newTask = new TaskItem
            {
                Description = description,
                IsCompleted = false,
                Priority = priority,
                DueDate = dueDate
            };

            allTasks.Add(newTask);
            TaskStorage.SaveTasks(allTasks);
            RefreshList();

            TaskDescriptionBox.Clear();
            DueDatePicker.SelectedDate = DateTime.Now;
            PriorityBox.SelectedIndex = 1; // Reset to Medium
        }

        // Refresh ListBox (always use full list for status counts)
        private void RefreshList(List<TaskItem>? filteredTasks = null)
        {
            TaskList.ItemsSource = null;
            TaskList.ItemsSource = filteredTasks ?? allTasks;
            UpdateStatusCounts();
        }

        // Toggle Completed
        private void TaskStatusChanged(object sender, RoutedEventArgs e)
        {
            TaskStorage.SaveTasks(allTasks);
            RefreshList();
        }

        // Search Filter
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string search = SearchBox.Text.ToLower();
            var filteredTasks = allTasks
                .Where(t => t.Description.ToLower().Contains(search))
                .ToList();
            RefreshList(filteredTasks);
        }

        // Filter Buttons
        private void ShowAll_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
            RefreshList();
        }

        private void ShowPending_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
            var filtered = allTasks.Where(t => !t.IsCompleted).ToList();
            RefreshList(filtered);
        }

        private void ShowCompleted_Click(object sender, RoutedEventArgs e)
        {
            SearchBox.Clear();
            var filtered = allTasks.Where(t => t.IsCompleted).ToList();
            RefreshList(filtered);
        }

        // Delete Task
        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem mi && mi.CommandParameter is TaskItem task && task != null)
            {
                // Show confirmation dialog
                MessageBoxResult result = MessageBox.Show(
                    $"Are you sure you want to delete the task:\n\"{task.Description}\"?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning
                );

                if (result == MessageBoxResult.Yes)
                {
                    allTasks.Remove(task);
                    TaskStorage.SaveTasks(allTasks);
                    RefreshList();
                }
            }
        }

        // Update Task
        private void UpdateTask_Click(object sender, RoutedEventArgs e)
        {
            if (sender is MenuItem mi && mi.CommandParameter is TaskItem task)
            {
                string newDesc = Microsoft.VisualBasic.Interaction.InputBox(
                    "Edit Task Description", "Update Task", task.Description);
                if (!string.IsNullOrWhiteSpace(newDesc))
                {
                    task.Description = newDesc;
                    TaskStorage.SaveTasks(allTasks);
                    RefreshList();
                }
            }
        }

        // Double-click Complete Task
        private void TaskList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (TaskList.SelectedItem is TaskItem task)
            {
                task.IsCompleted = !task.IsCompleted;
                TaskStorage.SaveTasks(allTasks);
                RefreshList();
            }
        }

        // Update Status Counts
        private void UpdateStatusCounts()
        {
            int total = allTasks.Count;
            int completed = allTasks.Count(t => t.IsCompleted);
            int pending = total - completed;

            CompletedCountText.Text = $"{completed}";
            PendingCountText.Text = $"{pending}";
            TotalCountText.Text = $"{total}";
        }
    }
}

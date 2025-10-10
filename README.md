# 🗂️ Task Tracker App

A clean and intuitive **desktop application** built with **C# and WPF (.NET 8.0 LTS)** that helps users manage their daily tasks effectively.  
This app allows users to add, edit, and delete tasks while maintaining data persistence across sessions.  
It’s lightweight, user-friendly, and demonstrates core WPF and MVVM design principles.

---

## 🚀 Features

- ✅ Add, edit, and delete tasks  
- ⚠️ Confirmation dialog before deleting a task  
- 💾 Persistent data storage using JSON (`tasks.json`)  
- 🎨 Modern and responsive WPF user interface  
- 🕓 Task sorting and organization by completion status  
- 🌈 Visual indicators using value converters (e.g., color and text decoration based on task state)

---

## 🛠️ Technologies Used

- **C# 7.3**
- **.NET 8.0 (Long Term Support)**
- **WPF (Windows Presentation Foundation)**
- **XAML** for UI layout and styling  
- **JSON** for local data persistence  

---

## 📁 Project Structure

```
TaskTrackerApp/
├── Converters/
│   ├── BoolToColorConverter.cs
│   ├── BoolToTextDecorationConverter.cs
│   └── PriorityToColorConverter.cs
├── Data/
│   └── tasks.json
├── Models/
│   └── TaskItem.cs
├── Services/
│   └── TaskStorage.cs
├── App.xaml
├── App.xaml.cs
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── AssemblyInfo.cs
├── README.md
├── .gitignore
└── .gitattributes
```

---

## 💡 How to Run

1. **Clone the repository**
   ```bash
   git clone https://github.com/DKBooysen/TaskTrackerApp.git
   ```

2. **Open in Visual Studio**
   - Ensure you have **.NET 8.0 SDK** installed.
   - Open the `.sln` file.

3. **Build and Run**
   - Press **F5** or select **Start Debugging**.

Your tasks will be automatically saved to `Data/tasks.json` after each update.

---

## 🧠 Future Improvements

- ⏰ Add due dates and reminders  
- 🏷️ Add categories or colored labels for task grouping  
- ☁️ Sync data to a cloud database for multi-device access  
- 🔍 Implement search and filtering features  

---

## 👤 Author

**Daniel Booysen**  
📍 South Africa  
💼 [LinkedIn](#www.linkedin.com/in/daniel-booysen-133041251) | 🧰 [GitHub Portfolio](#https://github.com/DKBooysen)

---

## 🪪 License

This project is open-source and available under the **MIT License**.  
You are free to use, modify, and distribute it with proper attribution.

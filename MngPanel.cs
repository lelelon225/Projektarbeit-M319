using System;
using System.Collections.Generic;
using System.Linq;

public class MngPanel
{
    // List to store tasks
    public List<Task> tasks;

    // Constructor
    public MngPanel()
    {
        // Initialize task list
        tasks = new List<Task>();
    }

    // Method to add a task
    public void AddTask(Task task)
    {
        Console.WriteLine("Aufgabe hinzugefügt");
        tasks.Add(task);
    }

    // Method to remove a task by ID
    public void RemoveTask(String input)
    {
        if(int.TryParse(input, out int taskId))
        {
            Task foundTask = tasks.Find(t => t.getId() == taskId);
            if(foundTask != null)
            {
                tasks.Remove(foundTask);
            }
            else
            {
                Console.WriteLine("Aufgabe mit dieser ID nicht gefunden");
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe");
        }
    }

    // Method to mark a task as done by ID
    public void MarkTaskAsDone(String input)
    {
        if(int.TryParse(input, out int taskId))
        {
            Task foundTask = tasks.Find(t => t.getId() == taskId);
            if(foundTask != null)
            {
                foundTask.Done = true;
            }
            else
            {
                Console.WriteLine("Aufgabe mit dieser ID nicht gefunden");
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe");
        }
    }

    // Method to sort tasks by priority
    public void SortTasksByPriority()
    {
        tasks.Sort((a, b) => a.getPriority().CompareTo(b.getPriority()));
        tasks.Reverse();
        PrintTable();
    }

    // Method to print tasks in a table format
    public void PrintTable()
    {
        // Check if there are no tasks
        if (!tasks.Any())
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║     Keine Aufgaben vorhanden           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            return;
        }

        // Calculate column widths
        int idWidth = Math.Max(4, tasks.Max(t => t.getId().ToString().Length) + 2);
        int taskWidth = Math.Max(30, tasks.Max(t => t.getTask().Length) + 2);
        int priorityWidth = 12;
        int statusWidth = 12;

        // Adjust taskWidth if total width exceeds console width
        int totalWidth = idWidth + taskWidth + priorityWidth + statusWidth + 5;
        if (totalWidth > Console.WindowWidth - 2)
        {
            taskWidth = Console.WindowWidth - idWidth - priorityWidth - statusWidth - 10;
            if (taskWidth < 15) taskWidth = 15;
        }

        // Print table header
        Console.WriteLine("╔" + new string('═', idWidth) + "╦" +
                          new string('═', taskWidth) + "╦" +
                          new string('═', priorityWidth) + "╦" +
                          new string('═', statusWidth) + "╗");

        // Print column titles
        Console.WriteLine("║" + CenterText("ID", idWidth) + "║" +
                          CenterText("Aufgabe", taskWidth) + "║" +
                          CenterText("Priorität", priorityWidth) + "║" +
                          CenterText("Status", statusWidth) + "║");

        // Print separator
        Console.WriteLine("╠" + new string('═', idWidth) + "╬" +
                          new string('═', taskWidth) + "╬" +
                          new string('═', priorityWidth) + "╬" +
                          new string('═', statusWidth) + "╣");

        // Print each task
        foreach (Task task in tasks)
        {
            // Prepare task details
            string id = task.getId().ToString();
            string taskName = task.getTask();
            int priority = task.getPriority();

            // Map priority to display string
            string priorityDisplay = priority switch
            {
                3 => "HIGH",
                2 => "MEDIUM",
                1 => "LOW",
                _ => "MEDIUM"
            };

            // Map done status to display string
            string status = task.Done ? "✓ Erledigt" : "○ Offen";

            if (taskName.Length > taskWidth - 2)
            {
                taskName = taskName.Substring(0, taskWidth - 5) + "...";
            }

            // Print each task row
            Console.WriteLine("║" + PadText(id, idWidth) + "║" +
                              PadText(taskName, taskWidth) + "║" +
                              CenterText(priorityDisplay, priorityWidth) + "║" +
                              PadText(status, statusWidth) + "║");
        }

        // Print table footer
        Console.WriteLine("╚" + new string('═', idWidth) + "╩" +
                          new string('═', taskWidth) + "╩" +
                          new string('═', priorityWidth) + "╩" +
                          new string('═', statusWidth) + "╝");

        // Print summary
        Console.WriteLine($"\nGesamt: {tasks.Count} Aufgabe(n) | " +
                          $"Erledigt: {tasks.Count(t => t.Done)} | " +
                          $"Offen: {tasks.Count(t => !t.Done)}");
    }

    // Helper method to center text within a given width
    private string CenterText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        int padding = width - text.Length;
        int padLeft = padding / 2;
        int padRight = padding - padLeft;
        return new string(' ', padLeft) + text + new string(' ', padRight);
    }
    
    // Helper method to pad text to the left within a given width
    private string PadText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        return " " + text + new string(' ', width - text.Length - 1);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class MngPanel
{
    public List<Task> tasks;

    public MngPanel()
    {
        tasks = new List<Task>();
    }

    public void AddTask(Task task)
    {
        Console.WriteLine("Aufgabe hinzugefügt");
        tasks.Add(task);
    }
    public void DisplayTasks()
    {
        Console.WriteLine("Aufgaben:");
        if(!tasks.Any())
        {
            Console.WriteLine("Keine Aufgaben vorhanden");
        }
        else
        {
            foreach (Task task in tasks)
            {
                Console.WriteLine($"{task.getId()}. {task.getTask()}");
            }
        }
    }

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
    public void MarkTaskAsDone(String input)
    {
        if(int.TryParse(input, out int taskId))
        {
            Task foundTask = tasks.Find(t => t.getId() == taskId);
            if(foundTask != null)
            {
                // Note: Task.setDone must exist for this to compile.
                foundTask.setDone(true);
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

    public void SortTasksByPriority()
    {
        //tasks.Sort((a, b) => a.getPriority().CompareTo(b.getPriority()));
    }

    public void PrintTable()
    {
        if (!tasks.Any())
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║     Keine Aufgaben vorhanden           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            return;
        }

        // Calculate column widths dynamically (ID, Task, Status)
        int idWidth = Math.Max(4, tasks.Max(t => t.getId().ToString().Length) + 2);
        int taskWidth = Math.Max(30, tasks.Max(t => t.getTask().Length) + 2);
        int statusWidth = Math.Max(12, tasks.Max(t => (t.isDone() ? "✓ Erledigt" : "○ Offen").Length) + 2);

        // Adjust if console is too narrow
        int totalWidth = idWidth + taskWidth + statusWidth + 4;
        if (totalWidth > Console.WindowWidth - 2)
        {
            taskWidth = Console.WindowWidth - idWidth - statusWidth - 6;
            if (taskWidth < 15) taskWidth = 15;
        }

        // Top border
        Console.WriteLine("╔" + new string('═', idWidth) + "╦" +
                          new string('═', taskWidth) + "╦" +
                          new string('═', statusWidth) + "╗");

        // Header
        Console.WriteLine("║" + CenterText("ID", idWidth) + "║" +
                          CenterText("Aufgabe", taskWidth) + "║" +
                          CenterText("Status", statusWidth) + "║");

        // Header separator
        Console.WriteLine("╠" + new string('═', idWidth) + "╬" +
                          new string('═', taskWidth) + "╬" +
                          new string('═', statusWidth) + "╣");

        // Task rows
        foreach (Task task in tasks)
        {
            string id = task.getId().ToString();
            string taskName = task.getTask();
            string status = task.isDone() ? "✓ Erledigt" : "○ Offen";

            // Truncate task name if too long
            if (taskName.Length > taskWidth - 2)
            {
                taskName = taskName.Substring(0, taskWidth - 5) + "...";
            }

            Console.WriteLine("║" + PadText(id, idWidth) + "║" +
                              PadText(taskName, taskWidth) + "║" +
                              PadText(status, statusWidth) + "║");
        }

        // Bottom border
        Console.WriteLine("╚" + new string('═', idWidth) + "╩" +
                          new string('═', taskWidth) + "╩" +
                          new string('═', statusWidth) + "╝");

        Console.WriteLine($"\nGesamt: {tasks.Count} Aufgabe(n) | " +
                          $"Erledigt: {tasks.Count(t => t.isDone())} | " +
                          $"Offen: {tasks.Count(t => !t.isDone())}");
    }

    private string CenterText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        int padding = width - text.Length;
        int padLeft = padding / 2;
        int padRight = padding - padLeft;
        return new string(' ', padLeft) + text + new string(' ', padRight);
    }

    private string PadText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        return " " + text + new string(' ', width - text.Length - 1);
    }
}

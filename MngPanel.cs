using System;
using System.Collections.Generic;

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
    {}


}

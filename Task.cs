using System;

public class Task
{

    public Task()
    {
        HashSet<int> taskIds = new HashSet<int>();
        Random random = new Random();
        int newId;
        do
        {
            newId = random.Next(1, 10000); // Generate random ID between
            } while (taskIds.Contains(newId));

        }
    public void AddTask()
    {
        Console.WriteLine("Funktion zum Hinzufügen einer Aufgabe wird aufgerufen.");
        

    }   
    public void ViewTasks()
    {
        Console.WriteLine("Funktion zum Anzeigen der Aufgaben wird aufgerufen.");
    }
    public void MarkTaskAsCompleted()
    {
        Console.WriteLine("Funktion zum Markieren einer Aufgabe als erledigt wird aufgerufen.");    
    }

    public void DeleteTask()
    {
        Console.WriteLine("Funktion zum Löschen einer Aufgabe wird aufgerufen.");
    }
    public void SortTasksByPriority()
    {
        Console.WriteLine("Funktion zum Sortieren der Aufgaben nach Priorität wird aufgerufen.");   
    }

}
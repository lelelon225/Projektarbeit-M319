/*
  MngPanel.cs
  -----------
  Diese Klasse verwaltet die Liste der Aufgaben (Tasks) und bietet Methoden zum
  Hinzufügen, Entfernen, Markieren als erledigt, Sortieren und Ausgeben in einer
  tabellarischen Form. Die Kommentare in diesem File erklären kurz, was jede
  Methode macht — die eigentliche Logik wurde absichtlich unverändert gelassen.
*/
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

    // AddTask: Fügt eine neue Aufgabe zur internen Liste hinzu.
    // Parameter:
    //   - task: das Task-Objekt, das hinzugefügt werden soll.
    // Verhalten:
    //   - Gibt eine Bestätigung auf der Konsole aus und hängt die Aufgabe an die Liste an.
    public void AddTask(Task task)
    {
        Console.WriteLine("Aufgabe hinzugefügt");
        tasks.Add(task);
    }



    // RemoveTask: Entfernt eine Aufgabe anhand einer eingegebenen ID (als String).
    // Parameter:
    //   - input: die ID als String; wird versucht in eine Ganzzahl zu parsen.
    // Verhalten:
    //   - Bei gültiger ID wird die Aufgabe gesucht und entfernt; ansonsten
    //     erscheint eine Fehlermeldung.
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
    // MarkTaskAsDone: Markiert eine Aufgabe als erledigt (done = true).
    // Parameter:
    //   - input: die ID als String; wird in eine Ganzzahl geparst.
    // Verhalten:
    //   - Wenn eine passende Aufgabe gefunden wird, wird ihr Status auf erledigt gesetzt.
    //   - Falls keine passende Aufgabe existiert oder die Eingabe ungültig ist,
    //     wird eine entsprechende Meldung ausgegeben.
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

    // SortTasksByPriority: Sortiert die Aufgabenliste nach Priorität.
    // Implementation:
    //   - Sortiert aufsteigend nach getPriority() und kehrt die Reihenfolge um,
    //     sodass hohe Priorität oben steht.
    //   - Anschließend wird die Tabelle ausgegeben.
    public void SortTasksByPriority()
    {
        tasks.Sort((a, b) => a.getPriority().CompareTo(b.getPriority()));
        tasks.Reverse();
        PrintTable();
    }

    // PrintTable: Gibt die Aufgaben in einer hübschen Tabellenansicht in der Konsole aus.
    // Details:
    //   - Berechnet die Spaltenbreiten dynamisch anhand des längsten Inhalts.
    //   - Gibt Kopfzeile, Trennlinien, Zeilen für jede Aufgabe und die Fußzeile aus.
    //   - Priorität wird in Text (HIGH/MEDIUM/LOW) übersetzt.
    //   - Status zeigt, ob die Aufgabe erledigt ist oder offen.
    public void PrintTable()
    {
        if (!tasks.Any())
        {
            Console.WriteLine("╔════════════════════════════════════════╗");
            Console.WriteLine("║     Keine Aufgaben vorhanden           ║");
            Console.WriteLine("╚════════════════════════════════════════╝");
            return;
        }

        // Calculate column widths dynamically
        int idWidth = Math.Max(4, tasks.Max(t => t.getId().ToString().Length) + 2);
        int taskWidth = Math.Max(30, tasks.Max(t => t.getTask().Length) + 2);
        int priorityWidth = 12;
        int statusWidth = 12;

        // Adjust if console is too narrow
        int totalWidth = idWidth + taskWidth + priorityWidth + statusWidth + 5;
        if (totalWidth > Console.WindowWidth - 2)
        {
            taskWidth = Console.WindowWidth - idWidth - priorityWidth - statusWidth - 10;
            if (taskWidth < 15) taskWidth = 15;
        }

        // Top border
        Console.WriteLine("╔" + new string('═', idWidth) + "╦" +
                          new string('═', taskWidth) + "╦" +
                          new string('═', priorityWidth) + "╦" +
                          new string('═', statusWidth) + "╗");

        // Header
        Console.WriteLine("║" + CenterText("ID", idWidth) + "║" +
                          CenterText("Aufgabe", taskWidth) + "║" +
                          CenterText("Priorität", priorityWidth) + "║" +
                          CenterText("Status", statusWidth) + "║");

        // Header separator
        Console.WriteLine("╠" + new string('═', idWidth) + "╬" +
                          new string('═', taskWidth) + "╬" +
                          new string('═', priorityWidth) + "╬" +
                          new string('═', statusWidth) + "╣");

        // Task rows
        foreach (Task task in tasks)
        {
            string id = task.getId().ToString();
            string taskName = task.getTask();
            int priority = task.getPriority();

            // Convert priority to text
            string priorityDisplay = priority switch
            {
                3 => "HIGH",
                2 => "MEDIUM",
                1 => "LOW",
                _ => "MEDIUM" // Default to MEDIUM if invalid
            };

            string status = task.isDone() ? "✓ Erledigt" : "○ Offen";

            // Truncate task name if too long
            if (taskName.Length > taskWidth - 2)
            {
                taskName = taskName.Substring(0, taskWidth - 5) + "...";
            }

            Console.WriteLine("║" + PadText(id, idWidth) + "║" +
                              PadText(taskName, taskWidth) + "║" +
                              CenterText(priorityDisplay, priorityWidth) + "║" +
                              PadText(status, statusWidth) + "║");
        }

        // Bottom border
        Console.WriteLine("╚" + new string('═', idWidth) + "╩" +
                          new string('═', taskWidth) + "╩" +
                          new string('═', priorityWidth) + "╩" +
                          new string('═', statusWidth) + "╝");

        Console.WriteLine($"\nGesamt: {tasks.Count} Aufgabe(n) | " +
                          $"Erledigt: {tasks.Count(t => t.isDone())} | " +
                          $"Offen: {tasks.Count(t => !t.isDone())}");
    }

    // CenterText: Hilfsfunktion, die einen Text in einer gegebenen Breite zentriert.
    // Rückgabe: der Text mit links/rechts Padding, zugeschnitten falls nötig.
    private string CenterText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        int padding = width - text.Length;
        int padLeft = padding / 2;
        int padRight = padding - padLeft;
        return new string(' ', padLeft) + text + new string(' ', padRight);
    }

    // PadText: Hilfsfunktion, die einen Text linksbündig in einer Spalte darstellt.
    // Fügt links ein Leerzeichen ein und füllt rechts mit Leerzeichen auf.
    private string PadText(string text, int width)
    {
        if (text.Length >= width) return text.Substring(0, width);
        return " " + text + new string(' ', width - text.Length - 1);
    }
}

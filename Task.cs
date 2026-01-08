/*
  Task.cs
  -------
  Diese Datei enthält die Klasse `Task`, die ein einzelnes To-Do-Element
  repräsentiert. Die Klasse ist bewusst einfach gehalten und verwendet
  klassische Getter/Setter-Methoden (statt C#-Properties), damit sie mit
  dem bestehenden Code der Übung kompatibel bleibt.

  Hinweise:
    * `Task(int id, string taskName, bool done, int priority)` ist der
      Hauptkonstruktor (Explizites Setzen aller Felder).
    * `Task(int id, string taskName)` ist ein Komfortkonstruktor,
      der `done = false` und `priority = 2` (MEDIUM) setzt.
*/

using System;

public class Task
{
    // Eindeutige ID der Aufgabe
    private int id;

    // Beschreibung / Name der Aufgabe
    private string taskName;

    // Erledigt-Status: true = erledigt, false = offen
    private bool done;

    // Priorität: 1 = LOW, 2 = MEDIUM, 3 = HIGH
    private int priority;

    /*
      Hauptkonstruktor
      Parameter:
       - id: eindeutige ID
       - taskName: Text / Beschreibung der Aufgabe
       - done: ob die Aufgabe bereits erledigt ist
       - priority: Priorität (1..3)
    */
    public Task(int id, string taskName, bool done, int priority)
    {
        this.id = id;
        this.taskName = taskName ?? ""; // Falls null übergeben wird, leere Zeichenkette verwenden
        this.done = done;
        this.priority = priority;
    }

    /*
      Komfortkonstruktor
      Setzt done auf false und priority auf 2 (MEDIUM).
      Wird z.B. verwendet, wenn nur ID und Name bekannt sind.
    */
    public Task(int id, string taskName)
        : this(id, taskName, false, 2)
    {
    }

    // Getter für ID
    public int getId()
    {
        return id;
    }

    // Getter für den Aufgabentext / Namen
    public string getTask()
    {
        return taskName;
    }

    // Setter für den Aufgabentext (optional, falls benötigt)
    public void setTask(string value)
    {
        taskName = value ?? "";
    }

    // Prüfen ob erledigt
    public bool isDone()
    {
        return done;
    }

    // Setzen des Erledigt-Status
    public void setDone(bool value)
    {
        done = value;
    }

    // Getter für Priorität
    public int getPriority()
    {
        return priority;
    }

    // Setter für Priorität (erwartet Werte z.B. 1..3)
    public void setPriority(int value)
    {
        priority = value;
    }

    // Einfache string-Repräsentation zur schnellen Ausgabe / Debugging
    public override string ToString()
    {
        return $"Task {id}: {taskName} (Done: {done}, Priority: {priority})";
    }

    // Komfort-Methoden zur Status-Anpassung
    public void markAsDone()
    {
        done = true;
    }

    public void markAsUndone()
    {
        done = false;
    }

    // Komfort-Methoden zur Prioritäts-Anpassung
    public void markAsHighPriority()
    {
        priority = 3;
    }

    public void markAsMediumPriority()
    {
        priority = 2;
    }

    public void markAsLowPriority()
    {
        priority = 1;
    }

    // Setzt die Standard-Priorität (hier: MEDIUM / 2)
    public void markAsDefaultPriority()
    {
        priority = 2;
    }
}

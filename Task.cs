using System;

public class Task
{
    // Private variables
    private int id;
    private string taskName;
    private bool done;
    private int priority;

    // Constructor
    public Task(int id, string taskName, bool done, int priority)
    {
        // Initialize variables
        this.id = id;
        this.taskName = taskName ?? "";
        this.done = done;
        this.priority = priority;
    }

    // Getter methods
    public int getId()
    {
        return id;
    }

    public string getTask()
    {
        return taskName;
    }

    public int getPriority()
    {
        return priority;
    }
    
    // Property for done
    public bool Done
    {
        get { return done; }
        set { done = value; }
    }
}

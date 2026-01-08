using System;

public class Task
{
    private int id;
    private string taskName;
    private bool done;

    public Task(int id, string taskName)
    {
        this.id = id;
        this.taskName = taskName;
        this.done = false;
    }

    public int getId()
    {
        return id;
    }

    public string getTask()
    {
        return taskName;
    }

    public bool isDone()
    {
        return done;
    }

    public void setDone(bool value)
    {
        done = value;
    }

}

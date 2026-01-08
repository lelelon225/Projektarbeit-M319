public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        bool running = true;
        while (running){
            running = Menu.MainMenu();
        }
    }
}

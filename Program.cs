public class Program
{
    public static void Main(string[] args)
    {
        Console.Clear();
        Menu.DisplayStartupScreen();
        bool running = true;
        while (running){
            running = Menu.MainMenu();
        }
    }
}

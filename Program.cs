using System;

public class Program
{ // Main Methode
    public static void Main(string[] args)
    {
        try{
            // Konsole beliebige
            Console.Clear();

            // Aufruf des Startbildschirms
            Menu.DisplayStartupScreen();

            // Aufruf des Hauptprogramms
            bool running = true;
            while (running)
            {
                running = Menu.MainMenu();
            }
        } // Error Handling
        catch (Exception ex)
        {
            Console.WriteLine("Irgendwas ist schief gelaufen: " + ex.Message);
            Console.WriteLine("Drücke eine beliebige Taste zum Beenden...");
            Console.ReadKey();
        }
    }
}

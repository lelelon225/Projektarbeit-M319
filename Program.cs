// Program.cs
// Zweck: Einstiegspunkt (Main) für die To-Do Konsolenanwendung.
// Dieses File enthält die Main-Methode, die beim Starten der Anwendung
// ausgeführt wird. Die Main-Methode:
// 1. Räumt die Konsole auf.
// 2. Zeigt einen kurzen Startbildschirm (Menu.DisplayStartupScreen).
// 3. Führt die Hauptmenü-Schleife aus (Menu.MainMenu) bis der Benutzer
//    das Programm beendet.
using System;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Konsole bereinigen für einen sauberen Start
            Console.Clear();

            // Optionaler Startbildschirm: sieht schick aus und wartet auf Tastendruck
            // Menu.DisplayStartupScreen() muss in Menu.cs implementiert sein.
            Menu.DisplayStartupScreen();

            // Haupt-Schleife: Menu.MainMenu() soll true zurückgeben, solange das
            // Programm weiterlaufen soll. Wenn false zurückgegeben wird, endet die App.
            bool running = true;
            while (running)
            {
                running = Menu.MainMenu();
            }
        }
        catch (Exception ex)
        {
            // Fange unerwartete Ausnahmen ab und gib eine einfache Meldung aus.
            // Für die Entwicklung kann man hier detaillierteres Logging ergänzen.
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Ein unerwarteter Fehler ist aufgetreten:");
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            Console.WriteLine("Drücken Sie eine Taste, um das Programm zu beenden...");
            Console.ReadKey();
        }
        finally
        {
            // Stelle sicher, dass die Konsolenfarben zurückgesetzt werden.
            Console.ResetColor();
        }
    }
}

using System;

public class Menu
{
    public static MngPanel panel = new MngPanel();

    public static bool MainMenu() // Main Menu Loop
    {

        bool running = true;
        while (running)
        {
            Menu.DisplayMenu();
            String choice = Console.ReadLine();


            Console.WriteLine();
            Console.WriteLine();

            if (!int.TryParse(choice, out int numericChoice)) // Input Validation
            {
                Console.WriteLine("Ungültige Eingabe, bitte eine Zahl eingeben.");
                continue;
            }


            switch (numericChoice) // Menu Options
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("To-Do hinzufügen");
                    Console.Write("Bitte geben Sie den Namen der To-Do ein: ");
                    string taskName = Console.ReadLine();
                    int id = panel.tasks.Count + 1;
                    Task task = new Task(id, taskName);
                    panel.AddTask(task);
                    return true;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Aufgaben anzeigen");
                    panel.PrintTable();
                    return true;
                case 3:
                    {
                        Console.Clear();
                        Console.WriteLine("To-Do erledigt");
                        Console.Write("Bitte geben Sie die ID der To-Do ein: ");
                        string input = Console.ReadLine();
                        panel.MarkTaskAsDone(input);
                        return true;
                    }
                case 4:
                    {
                        Console.Clear();
                        Console.WriteLine("To-Do entfernen");
                        Console.Write("Bitte geben Sie die ID der To-Do ein: ");
                        string input = Console.ReadLine();
                        panel.RemoveTask(input);
                        return true;
                    }
                case 5:
                    Console.WriteLine("Aufgabe 5 ausgewählt");
                    panel.SortTasksByPriority();
                    return true;
                case 0:
                    Console.WriteLine("Programm wird beendet");
                    return false;
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen");
                    return true;
            }
        }
        return false;
    }

    public static void DisplayMenu() // Menu Display
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                      HAUPTMENÜ                             ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [1] ➤  Aufgabe hinzufügen                                 ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [2] ➤  Aufgabe anzeigen                                   ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [3] ➤  Aufgabe als erledigt markieren                     ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [4] ➤  Aufgabe löschen                                    ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [5] ➤  Aufgaben nach Priorität sortieren                  ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [0] ➤  Programm beenden                                   ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("│ Bitte wählen Sie eine Option: ");
        Console.ResetColor();
    }

    public static void DisplayStartupScreen()
    {
        Console.Clear();

        // ASCII Art Title
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"
    ╔════════════════════════════════════════════════════════════════════════════╗
    ║                                                                            ║
    ║  ████████╗ ██████╗       ██████╗  ██████╗                                  ║
    ║  ╚══██╔══╝██╔═══██╗      ██╔══██╗██╔═══██╗                                 ║
    ║     ██║   ██║   ██║█████╗██║  ██║██║   ██║                                 ║
    ║     ██║   ██║   ██║╚════╝██║  ██║██║   ██║                                 ║
    ║     ██║   ╚██████╔╝      ██████╔╝╚██████╔╝                                 ║
    ║     ╚═╝    ╚═════╝       ╚═════╝  ╚═════╝                                  ║
    ║                                                                            ║
    ║              ███╗   ███╗ █████╗ ███╗   ██╗ █████╗  ██████╗ ███████╗██████╗ ║
    ║              ████╗ ████║██╔══██╗████╗  ██║██╔══██╗██╔════╝ ██╔════╝██╔══██╗║
    ║              ██╔████╔██║███████║██╔██╗ ██║███████║██║  ███╗█████╗  ██████╔╝║
    ║              ██║╚██╔╝██║██╔══██║██║╚██╗██║██╔══██║██║   ██║██╔══╝  ██╔══██╗║
    ║              ██║ ╚═╝ ██║██║  ██║██║ ╚████║██║  ██║╚██████╔╝███████╗██║  ██║║
    ║              ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝║
    ║                                                                            ║
    ╚════════════════════════════════════════════════════════════════════════════╝
    ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("              Willkommen bei Ihrem persönlichen Aufgaben-Manager!");
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
}

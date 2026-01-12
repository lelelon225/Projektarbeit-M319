using System;

public class Menu
{
    // Manage Panel initialization
    public static MngPanel panel = new MngPanel();

    // Main menu loop
    public static bool MainMenu()
    {
        bool running = true;
        while (running)
        {
            // Set console color and clear screen
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            // Print current tasks
            panel.PrintTable();

            // Display menu options
            Menu.DisplayMenu();
            String choice = Console.ReadLine();

            // Formatting
            Console.WriteLine();
            Console.WriteLine();

            if (!int.TryParse(choice, out int numericChoice))
            {
                Console.WriteLine("Ungültige Eingabe, bitte eine Zahl eingeben.");
                continue;
            }
            
            // Handle menu choices
            switch (numericChoice)
            {
                // Add To-Do
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║To-Do hinzufügen                                            ║   ");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    Console.Write("Bitte geben Sie den Namen der To-Do ein: ");
                    string taskName = Console.ReadLine();

                    int priority = 2;
                    bool validPriority = false;
                    while (!validPriority)
                    {
                        Console.Write("Bitte geben Sie die Priorität der To-Do ein(1-3): ");
                        string priorityInput = Console.ReadLine();
                        if (int.TryParse(priorityInput, out int parsedPriority) && parsedPriority >= 1 && parsedPriority <= 3)
                        {
                            priority = parsedPriority;
                            validPriority = true;
                        }
                        else
                        {
                            Console.WriteLine("Ungültige Eingabe, bitte eine Zahl zwischen 1 und 3 eingeben.");
                        }
                    }

                    int id = panel.tasks.Count + 1;

                    Task task = new Task(id, taskName, false, priority);
                    panel.AddTask(task);
                    return true;

                // Sort Tasks by Priority
                case 2:
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║To-Dos nach Priorität sortieren                             ║ ");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    panel.SortTasksByPriority();
                    return true;

                // Mark To-Do as Done
                case 3:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        panel.PrintTable();
                        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║To-Do erledigt                                              ║ ");
                        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("Bitte geben Sie die ID der To-Do ein: ");
                        string input = Console.ReadLine();

                        panel.MarkTaskAsDone(input);
                        return true;
                    }

                // Remove To-Do
                case 4:
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        panel.PrintTable();
                        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                        Console.WriteLine("║To-Do Löschen                                               ║");
                        Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                        Console.Write("Bitte geben Sie die ID der To-Do ein: ");
                        string input = Console.ReadLine();

                        panel.RemoveTask(input);
                        return true;
                    }

                // Exit Program
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Programm wird beendet");
                    return false;

                // Invalid Input
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen");
                    return true;
            }
        }
        return false;
    }

    // Display menu options
    public static void DisplayMenu()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║                      HAUPTMENÜ                             ║");
        Console.WriteLine("╠════════════════════════════════════════════════════════════╣");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [1] ➤  To-Do hinzufügen                                   ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [2] ➤  Aufgaben nach Priorität sortieren                  ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [3] ➤  To-Do als erledigt markieren                       ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("║  [4] ➤  To-Do löschen                                      ║");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Red;
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
    // Display Startup Ascii Art
    public static void DisplayStartupScreen()
    {
        Console.Clear();

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
    ║              ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ██╔╝ ╚═════╝ ╚══════╝╚═╝  ╚═║
    ║                                                                            ║
    ╚════════════════════════════════════════════════════════════════════════════╝
    ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("              Willkommen bei Ihrem persönlichen Aufgaben-Manager!");
        Console.WriteLine();
        Console.ResetColor();

        // Pause before proceeding
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
}

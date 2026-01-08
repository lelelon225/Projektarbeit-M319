// Menu.cs
// ---------
// Zweck: Enthält das Konsolenmenü für das Aufgabenverwaltungsprogramm.
// Dieses Menu stellt die Haupt-Benutzeroberfläche in der Konsole bereit.
// - Zeigt die Liste der Aufgaben an (über MngPanel.PrintTable())
// - Bietet Optionen zum Hinzufügen, Sortieren, Markieren als erledigt und Löschen
//   von Aufgaben.


using System;

public class Menu
{
    // Gemeinsames Verwaltungsobjekt für Aufgaben (MngPanel).
    // Es ist statisch, damit die statische MainMenu()-Methode darauf zugreifen kann.
    public static MngPanel panel = new MngPanel();

    // MainMenu: Führt die Endlosschleife des Menüs aus, bis der Benutzer das
    // Programm beendet. Gibt true zurück, solange das Menü weiterlaufen soll,
    // und false, wenn das Programm beendet werden soll.
    public static bool MainMenu() // Main Menu Loop
    {

        bool running = true;
        while (running)
        {
            // Menükopf (Farbe) und Aufräumen der Konsole
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            // Ausgabe der aktuellen Aufgaben in Tabellenform.
            // PrintTable() ist für die formatierte Darstellung zuständig.
            panel.PrintTable();

            // Anzeige der Menü-Auswahl
            Menu.DisplayMenu();
            String choice = Console.ReadLine();


            Console.WriteLine();
            Console.WriteLine();

            // Einfache Eingabevalidierung: die Wahl muss eine ganze Zahl sein.
            if (!int.TryParse(choice, out int numericChoice)) // Input Validation
            {
                Console.WriteLine("Ungültige Eingabe, bitte eine Zahl eingeben.");
                continue;
            }


            // Auswahl der Menüoptionen
            switch (numericChoice) // Menu Options
            {
                // [1] To-Do hinzufügen
                // - Fragt den Namen und die Priorität ab
                // - Erstellt ein neues Task-Objekt und fügt es dem Panel hinzu
                case 1:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║To-Do hinzufügen                                            ║   ");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    Console.Write("Bitte geben Sie den Namen der To-Do ein: ");
                    string taskName = Console.ReadLine();

                    // Priorität anfordern (Erwartung: 1..3). Hinweis: keine umfassende Validierung.
                    Console.Write("Bitte geben Sie die Priorität der To-Do ein(1-3): ");
                    int priority = int.Parse(Console.ReadLine());

                    // ID wird aktuell einfach aus der Anzahl der Aufgaben bestimmt.
                    int id = panel.tasks.Count + 1;

                    // Task-Konstruktor: (id, name, done, priority)
                    // done = false (neu hinzugefügte Aufgaben sind standardmäßig offen)
                    Task task = new Task(id, taskName, false, priority);
                    panel.AddTask(task);
                    return true;

                // [2] Aufgaben nach Priorität sortieren
                // - Löst die Sortierung im MngPanel aus und zeigt anschließend die Tabelle
                case 2:
                    // Hier Funktion einbauen (aktuell wird SortTasksByPriority aufgerufen)
                    Console.Clear();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
                    Console.WriteLine("║To-Dos nach Priorität sortieren                             ║ ");
                    Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
                    panel.SortTasksByPriority();
                    return true;

                // [3] To-Do als erledigt markieren
                // - Zeigt die Tabelle (zur Orientierung), fragt die ID ab und ruft
                //   MarkTaskAsDone im MngPanel auf.
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

                        // Übergabe der Eingabe an das Panel; dieses parst die ID und setzt
                        // gegebenenfalls den Erledigt-Status.
                        panel.MarkTaskAsDone(input);
                        return true;
                    }

                // [4] To-Do löschen
                // - Zeigt die Tabelle (zur Orientierung), fragt die ID ab und ruft
                //   RemoveTask im MngPanel auf.
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

                        // Entfernen wird im MngPanel durchgeführt (es parst die ID und
                        // entfernt die gefundene Aufgabe).
                        panel.RemoveTask(input);
                        return true;
                    }

                // [0] Programm beenden
                // - Beendet die Menüschleife und damit das Programm.
                case 0:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Programm wird beendet");
                    return false;

                // Standard: ungültige Auswahl
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen");
                    return true;
            }
        }
        return false;
    }

    // DisplayMenu: Gibt die statische Menüansicht mit Optionen aus.
    // Die Methode verändert keine Programmzustände, zeigt lediglich die
    // Auswahlmöglichkeiten für den Benutzer an.
    public static void DisplayMenu() // Menu Display
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

    // DisplayStartupScreen: Zeigt beim Programmstart eine ASCII-Überschrift und
    // wartet auf eine Taste, bevor es zum Hauptmenü übergeht.
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
    ║              ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═╝  ██╔╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝║
    ║                                                                            ║
    ╚════════════════════════════════════════════════════════════════════════════╝
    ");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("              Willkommen bei Ihrem persönlichen Aufgaben-Manager!");
        Console.WriteLine();
        Console.ResetColor();

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Drücken Sie eine beliebige Taste, um fortzufahren...");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();
    }
}

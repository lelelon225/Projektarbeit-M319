using System;
using System.Linq.Expressions;

public class Menu
{
    public static bool MainMenu()
    {
        bool running = true;
        while (running)
        {
            Menu.DisplayMenu();
            String choice = Console.ReadLine();

            if (!int.TryParse(choice, out int numericChoice))
            {
                Console.WriteLine("Ungültige Eingabe, bitte eine Zahl eingeben.");
                continue;
            }


            switch (numericChoice)
            {
                case 1:
                    Console.WriteLine("Aufgabe 1 ausgewählt");
                    return true;
                case 2:
                    Console.WriteLine("Aufgabe 2 ausgewählt");
                    return true;
                case 3:
                    Console.WriteLine("Aufgabe 3 ausgewählt");
                    return true;
                case 4:
                    Console.WriteLine("Aufgabe 4 ausgewählt");
                    return true;
                case 5:
                    Console.WriteLine("Aufgabe 5 ausgewählt");
                    return true;
                case 0:
                    Console.WriteLine("Programm wird beendet");
                    return false;
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen");
                    return true;
            }
        }
    }

    public static void DisplayMenu()
    {
        Console.WriteLine("1.--Aufgabe hinzufügen--");
        Console.WriteLine("2.--Aufgabe anzeigen--");
        Console.WriteLine("3.--Aufgabe als erledigt markieren--");
        Console.WriteLine("4.--Aufgabe löschen--");
        Console.WriteLine("5.--Aufgaben nach Priorität sortieren--");
        Console.WriteLine("0.--Programm Beenden--");
        Console.Write("Bitte wählen Sie eine Option:");

    }
}

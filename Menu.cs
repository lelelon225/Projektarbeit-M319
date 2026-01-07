public class Menu
{
    public Menu() {
        mainMenu();
    }
    public bool mainMenu()
    {
        bool running = false;
        Menu.displayMenu();
        while (!running){
            int choice = Console.Read();
            switch(choice)
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
                case 0: 
                Console.WriteLine("Programm wird beendet");
                return false;
                default:
                Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen");
                return true;
            }
        }
    }

    public static void displayMenu()
    {
        Console.WriteLine("1.--Aufgabe Hinzufügen--");
        Console.WriteLine("2.--Aufgabe Hinzufügen--");
        Console.WriteLine("3.--Aufgabe Hinzufügen--");
        Console.WriteLine("4.--Aufgabe Hinzufügen--");
        Console.WriteLine("0.--Programm Beenden--");
        Console.Write("Bitte wählen Sie eine Option:");

    }
}

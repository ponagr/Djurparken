using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        Zoo.AddNewAnimal("Berra", "Zebra", 5, "Afrika", 3);   //Namn, Ras, Ålder, Land, Hur många gånger per dag äter djuret
        Zoo.AddNewAnimal("Berit", "Gorilla", 2, "Asien", 3);
        Zoo.AddNewAnimal("Peppe", "Krokodil", 7, "Afrika", 2);
        Zoo.AddNewAnimal("Gigant", "Vattenbuffel", 4, "Afrika", 4);
        Zoo.AddNewAnimal("Voff", "Varg", 11, "Europa", 2);
        Zoo.AddNewAnimal("Nalle", "Bjorn", 1, "Europa", 4);
        Zoo.AddNewAnimal("Mjau", "Puma", 6, "Nordamerika", 2);

        //Zoo.ShowAnimals();
        // Console.ReadKey();
        // Console.Clear();


        var tempList = new List<Animal>();
        for (int i = 0; i < Zoo.animals.Count; i++)
        {
            if (int.IsEvenInteger(i))
            {
                tempList.Add(Zoo.animals[i]);
            }
        }
        // foreach (Animal animals in tempList)
        // {
        //     Console.WriteLine(animals.ToString());
        // }

        Zoo.AddNewPersonal("Pontus", Task.Healthcare, tempList);
        //Zoo.ShowPersonals();
        // Console.ReadKey();
        // foreach (HealthCare personal in Zoo.personals)
        // {
        //     personal.CheckAnimals();
        // }
        // Zoo.ShowHealthLog();
        Menu.MainMenu();
        Menu.ExitMenu();
        Console.WriteLine("Välkommen åter!");
        Console.ReadKey();
    }

}

public static class Menu
{
    //Metod som kan användas av alla andra menyer för att minska Redundans.
    //Används för att kunna göra val i menyn via Piltangenter, Enter och Backspace
    public static int ShowMenu(string[] options)
    {
        int menuChoice = 0;
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                    Console.WriteLine(options[i] + " <--");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                }
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
            {
                menuChoice++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
            {
                menuChoice--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
            {
                return menuChoice;
            }
            else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
            {
                return options.Length - 1;
            }
        }
        return -1;
    }
    //Meny-metoder som anropar olika metoder baserat på menyval, anropar först ShowMenu() för själva gränssnittet.
    public static int ShowMenu(Personal[] options)
    {
        int menuChoice = 0;
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                    Console.WriteLine(options[i] + " <--");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                }
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
            {
                menuChoice++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
            {
                menuChoice--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
            {
                return menuChoice;
            }
            else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
            {
                return options.Length - 1;
            }
        }
        return -1;
    }
    public static int ShowMenu(Animal[] options)
    {
        int menuChoice = 0;
        bool runMenu = true;

        while (runMenu)
        {
            Console.Clear();
            Console.CursorVisible = false;

            for (int i = 0; i < options.Length; i++)
            {
                if (i == menuChoice)
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;    //För att HighLighta nuvarande menyval med pil och textfärg
                    Console.WriteLine(options[i] + " <--");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(options[i]);  //Skriv ut resterande menyval utan pil och highlight
                }
            }

            var keyPressed = Console.ReadKey();

            if (keyPressed.Key == ConsoleKey.DownArrow && menuChoice < options.Length - 1)  //Om menyVal inte redan är på sista index , gå fram ett element
            {
                menuChoice++;
            }
            else if (keyPressed.Key == ConsoleKey.UpArrow && menuChoice > 0)    //Om menyVal inte redan är på index 0, gå tillbaka ett element
            {
                menuChoice--;
            }
            else if (keyPressed.Key == ConsoleKey.Enter)    //Välj nuvarande index
            {
                return menuChoice;
            }
            else if (keyPressed.Key == ConsoleKey.Backspace)    //Vid tryck på "Backspace", välj sista menyvalet(Avsluta/Gå Tillbaka)
            {
                return options.Length - 1;
            }
        }
        return -1;
    }
    public static void MainMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Djur", "2. Personal", "3. Avsluta" });
            switch (menuChoice)
            {
                case 0:
                    AnimalMenu();
                    break;
                case 1:
                    PersonalMenu();
                    break;
                case 2:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }
    public static void AnimalMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Lägg till Djur", "2. Visa Djur Info", "3. Sök efter specifika djur", "4. Gå Tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    Input.NewAnimal();
                    break;
                case 1:
                    ChooseAnimalMenu();
                    //Zoo.ShowAnimals();
                    //Anropa en till meny för att skriva ut Djurlista och välja vad du vill göra med djuret
                    break;
                case 2:
                    Input.SearchAnimal();
                    //Metod som läser input om vad man vill söka efter,
                    break;
                case 3:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }
    public static void ChooseAnimalMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            string[] animalOptions = new string[Zoo.animals.Count + 1];
            for (int i = 0; i < Zoo.animals.Count; i++)
            {
                animalOptions[i] = Zoo.animals[i].ToString();
            }
            animalOptions[animalOptions.Length - 1] = "Gå tillbaka";
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(animalOptions);
            if (menuChoice == animalOptions.Length -1)
            {
                break;
            }
            else
            {
                bool isRunning = true;
                while (isRunning)
                {
                    int choice = ShowMenu(new string[] { "1. Visa djurets matlogg", "2. Visa djurets hälsologg", "3. Visa djurets kostnader", "4. Gå Tillbaka" });
                    switch (choice)
                    {
                        case 0:
                            Zoo.animals[menuChoice].ShowFeedLog();
                            break;
                        case 1:
                            Zoo.animals[menuChoice].ShowHealthLog();
                            break;
                        case 2:
                            Zoo.animals[menuChoice].ShowExpenses();
                            break;
                        case 3:
                            isRunning = false;
                            break;
                    }
                }
            }
        }
    }
    public static void PersonalMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Visa Personallista", "2. Sök via Arbetsuppgifter", "3. Ändra Personal", "4. Gå Tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    ChoosePersonalMenu();
                    //Zoo.ShowPersonals();
                    //Visa personallista i meny, där du kan välja varje personal och då se deras 
                    break;
                case 1:
                    Input.ChooseTask();
                    //Lägg till metodanrop
                    break;
                case 2:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }

    public static void ChoosePersonalMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            string[] personalOptions = new string[Zoo.personals.Count + 1];
            for (int i = 0; i < Zoo.animals.Count -1; i++)
            {
                personalOptions[i] = Zoo.personals[i].ToString();
            }
            personalOptions[personalOptions.Length - 1] = "Gå tillbaka";
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(personalOptions);
            if (menuChoice == personalOptions.Length -1)
            {
                break;
            }
            else
            {
                bool isRunning = true;
                while (isRunning)
                {
                    int choice = ShowMenu(new string[] { "1. Visa djurets matlogg", "2. Visa djurets hälsologg", "3. Visa djurets kostnader", "4. Gå Tillbaka" });
                    switch (choice)
                    {
                        case 0:
                            Zoo.personals[menuChoice].PersonalInfo();
                            break;
                        case 1:
                            Zoo.animals[menuChoice].ShowHealthLog();
                            break;
                        case 2:
                            Zoo.animals[menuChoice].ShowExpenses();
                            break;
                        case 3:
                            isRunning = false;
                            break;
                    }
                }
            }
        }
    }

    public static void TaskMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Djurvårdare", "2. Djurmatare", "3. Städare", "4. Gå Tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    Zoo.SearchPersonalByTask(Task.Healthcare);
                    Console.ReadKey();
                    //Visa personallista i meny, där du kan välja varje personal och då se deras 
                    break;
                case 1:
                    Zoo.SearchPersonalByTask(Task.Foodcare);
                    Console.ReadKey();
                    //Lägg till metodanrop
                    break;
                case 2:
                    Zoo.SearchPersonalByTask(Task.Cleaning);
                    Console.ReadKey();
                    break;
                case 3:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }
    public static void AdminMenu()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Lägg till Personal", "2. Lägg till Djur", "3. Uppdatera Personal", "4. Uppdatera Djur", "5. Gå Tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    Input.NewPersonal();
                    break;
                case 1:
                    Input.NewAnimal();
                    //Lägg till metodanrop
                    break;
                    //Anropa en till meny för att skriva ut lista och välja vad du vill göra med djuret/personalen du väljer
                    //tex se logg/historik, ändra ålder, ändra hälsa, ändra matschema, ändra arbetsuppgift
                case 2:
                    //Skapa metod för att uppdatera personal
                    break;
                case 3:
                    //Skapa metod för att uppdatera djur
                    break;
                case 4:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }


    //PERSONAL OCH DJURMENYER

    public static void AnimalsToFeed()
    {
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = ShowMenu(new string[] { "1. Lägg till Personal", "2. Lägg till Djur", "3. Uppdatera Personal", "4. Uppdatera Djur", "5. Gå Tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    Input.NewPersonal();
                    break;
                case 1:
                    //Lägg till metodanrop
                    break;
                    //Anropa en till meny för att skriva ut lista och välja vad du vill göra med djuret/personalen du väljer
                    //tex se logg/historik, ändra ålder, ändra hälsa, ändra matschema, ändra arbetsuppgift
                case 2:
                    //Avsluta meny
                    runMenu = false;
                    break;
            }
        }
    }

    //Bekräfta Avsluta
    public static void ExitMenu()
    {
        bool runMenu = true; 
        while (runMenu)
        {                
            Console.WriteLine("Är du säker på att du vill avsluta programmet?\n");
            int menuChoice = ShowMenu(new string[] { "Ja, Avsluta", "Nej, Gå tillbaka" });
            switch (menuChoice)
            {
                case 0:
                    runMenu = false;    //Bekräfta och Avsluta program 
                    break;

                case 1:
                    MainMenu();     //Avbryt och återgå till Main-Menu
                    break;
            }
        }
    }
}

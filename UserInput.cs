using System.Runtime.Intrinsics.Arm;

public class Input
{
    public static void NewPersonal()
    {
        //LÄGG IN FELHANTERING

        Console.Write("Skriv in personalens namn: ");
        string name = FirstCharUpper(Console.ReadLine());
        //FirstCharUpper(name);
        // Console.Write("Välj personalens arbetsuppgift (Healthcare/Foodcare/Cleaning): ");
        // string task = Console.ReadLine();
        
        //Skriv ut Personal.AnimalsNotAssigned
        //Välj djur, lägg till i tempList, ta bort från AnimalsNotAssigned
        //
        var tempList = new List<Animal>();
        for (int i = 0; i < Personal.AnimalsNotAssigned.Count; i++)
        {
            if (int.IsEvenInteger(i))
            {
                tempList.Add(Personal.AnimalsNotAssigned[i]);   //GÖR NÅGOT MED DENNA, KAN INTE TA BORT FRÅN ANIMALSNOTASSIGNED
                Personal.AnimalsNotAssigned.RemoveAt(i);        //FÖRNS DJURET HAR FÅTT BÅDE ETT MATSCHEMA OCH HÄLSOKONTROLLSSCHEMA
            }
        }
        Console.WriteLine("Välj personalens arbetsuppgift:");
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = Menu.ShowMenu(new string[] { "1. Djurvårdare", "2. Djurmatare", "3. Städare", "4. Gå Tillbaka"});
            switch (menuChoice)
            {
                case 0:
                    //Metod för att lägga skriva ut lista med AnimalsNotAssigned baserat på healthcare,foodcare,cleaning, lägg listan i varje personal-underklass istället
                    Zoo.AddNewPersonal(name, Task.Healthcare, tempList);
                    //Visa personallista i meny, där du kan välja varje personal och då se deras 
                    break;
                case 1:
                    Zoo.AddNewPersonal(name, Task.Foodcare, tempList);
                    //Lägg till metodanrop
                    break;
                case 2:
                    Zoo.AddNewPersonal(name, Task.Cleaning, tempList);
                    break;
                case 3:
                    runMenu = false;
                    break;
            }
        }
        // switch(task)
        // {
        //     case "Healthcare":
        //         Zoo.AddNewPersonal(name, Task.Healthcare, tempList);
        //         break;
        //     case "Foodcare":
        //         Zoo.AddNewPersonal(name, Task.Foodcare, tempList);
        //         break;
        //     case "Cleaning":
        //         Zoo.AddNewPersonal(name, Task.Cleaning, tempList);
        //         break;
        // }
           
    }
    public static void ChooseTask()
    {
        Console.WriteLine("Välj personalens arbetsuppgift:");
        bool runMenu = true;
        while (runMenu)
        {
            //Lägg till så många menyval du vill i menuChoice-Array
            int menuChoice = Menu.ShowMenu(new string[] { "1. Djurvårdare", "2. Djurmatare", "3. Städare", "4. Gå Tillbaka" });
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
                    runMenu = false;
                    break;
            }
        }
    }

    public static void NewAnimal()
    {
        //LÄGG IN FELHANTERING


        Console.Write("Skriv in djurets namn: ");
        string name = Console.ReadLine();
        FirstCharUpper(name);
        Console.Write("Skriv in djurets art: ");
        string species = Console.ReadLine();
        FirstCharUpper(species);
        Console.Write("Skriv in djurets ursprungsland: ");
        string country = Console.ReadLine();
        FirstCharUpper(country);
        Console.Write("Skriv in djurets ålder: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Skriv in hur många gånger per dag djuret behöver äta: ");
        int foodAmmount = int.Parse(Console.ReadLine());
        
        Zoo.AddNewAnimal(name, species, age, country, foodAmmount);
    }
    public static void SearchAnimal()
    {
        Console.Write("Vad vill du söka efter, 1.Ras/2.Land: ");
        string input = FirstCharUpper(Console.ReadLine());
        Console.Write("Skriv in Rasen/Landet du vill söka efter: ");
        string searchFor = FirstCharUpper(Console.ReadLine());
        if (input == "Ras" || input == "1")
        {
            Zoo.SearchAnimal(input, searchFor);
        }
        else if (input == "Land" || input == "2")
        {
            Zoo.SearchAnimal(input, searchFor);
        }
        
    }

    static string FirstCharUpper(string value)
    {
        return char.ToUpper(value[0]) + value.Substring(1).ToLower();
    }
}

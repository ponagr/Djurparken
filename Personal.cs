public class Personal
{
    public string Name { get; set; }
    //public Task WorkTask { get; set; }
    //public string Schedule { get; set; }
    public static List<Animal> AnimalsNotAssigned { get; set; } = new List<Animal>();
    public List<Animal> AssignedAnimals { get; set; } = new List<Animal>();
    //OM WorkTask = Healthcare

    public void PersonalInfo()
    {
        Console.WriteLine($"Personal: {Name}\nAnsvarar över:");
        foreach (Animal animals in AssignedAnimals)
        {
            Console.WriteLine(animals.ToString());
        }
    }
    public override string ToString()
    {
        return $"Namn: {Name}, Arbetsschema: {AssignedAnimals}";
    }
}
public enum Task
{
    Healthcare,
    Foodcare,
    Cleaning
}

public class HealthCare : Personal
{
    public static List<HealthCare> personals = new List<HealthCare>();
    public const string workTask = "Healthcare";
    public void Schedule()
    {
        Console.WriteLine($"{Name} kommande arbetsuppgifter:");
        foreach (Animal animal in AssignedAnimals)
        {
            Console.WriteLine($"Hälsokontroll för: {animal.Name} - {animal.NextCheckup}");
        }
    }
    public void CheckAnimals()
    {
        var tempList = new List<Animal>();
        foreach (Animal animal in AssignedAnimals)
        {
            //FLYTTA KONTROLLEN IF(ANIMAL.NEEDSCHECKUP) TILL EN MENY DÄR DU SKRIVER UT ALLA DJUR SOM BEHÖVER CHECKUP
            //DÄR DU SEDAN KAN VÄLJA SPECIFIKT DJUR
            //OCH DÅ ANROPA DENNA METODEN FÖR JUST DET DJURET FÖR BÄTTRE KONTROLL

            if (animal.NeedsCheckup)
            {
                Console.Write("Skriv kommentar om djurets mående: ");
                string comment = Console.ReadLine();
                Console.Write("Djurets hälsa (Good/Bad): ");
                string health = Console.ReadLine();
                if (health == "Bad")
                {
                    animal.Health = AnimalHealth.Bad;
                }
                else
                {
                    animal.Health = AnimalHealth.Good;
                }
                animal.LastCheckup = DateTime.Now;
                animal.NextCheckup = DateTime.Now.AddDays(5);
                Console.WriteLine($"{animal.Name} har genomgått en hälsokontroll.");

                animal.Expenses.Add(Cost.HealthCare);
                Zoo.totalExpenses.Add(Cost.HealthCare);
                

                tempList.Add(animal);
                string tempString = $"Djur: {animal.Species}\nNamn: {animal.Name}\nHälsa: {animal.Health}\nSenaste hälsokontroll: {animal.LastCheckup}\nNästa hälsokontroll: {animal.NextCheckup}";
                Zoo.animalHealthLog.Add(tempString);
                string newLog = $"{animal.LastCheckup}, Hälsa: {animal.Health}, Kommentar: {comment}";
                animal.HealthLog.Add(newLog);
            }      
        }
        if (tempList.Count < 1)
        {
            Console.WriteLine("Inget av djuren behöver genomgå en hälsokontroll än");          
        }
            
    }
    //Lägg till Lista för djur som personalen ska hantera
    //OM animal.NeedsCare = true 
        //anropa metod CheckAnimal()
}
public class FoodCare : Personal
{
    public static List<FoodCare> personals = new List<FoodCare>();
    public const string workTask = "Foodcare";
    public void Schedule()
    {
        Console.WriteLine($"{Name} kommande arbetsuppgifter:");
        foreach (Animal animal in AssignedAnimals)
        {
            Console.WriteLine($"Mata: {animal.Name} vid {animal.FeedSchedule}");
        }
    }


    public void FeedAnimal(Animal animal)
    {
        //FLYTTA KONTROLLEN IF(DATETIME.NOW) TILL EN MENY DÄR DU SKRIVER UT ALLA DJUR SOM BEHÖVER MATAS
        //DÄR DU SEDAN KAN VÄLJA SPECIFIKT DJUR
        //OCH DÅ ANROPA DENNA METODEN FÖR JUST DET DJURET FÖR BÄTTRE KONTROLL
        if (DateTime.Now >= animal.FeedSchedule)
        {
            Console.WriteLine($"{animal.Name} har matats.");
            animal.FeedSchedule = DateTime.Now.AddHours(animal.FoodIntervall);
            Zoo.totalExpenses.Add(Cost.Food);
            animal.Expenses.Add(Cost.Food);
            string log = $"{animal.Name} matades: {DateTime.Now}";
            Zoo.animalFoodLog.Add(log);
            animal.FeedLog.Add(log);
        }
        else
        {
            Console.WriteLine($"{animal.Name} behöver inte matas än");
        }

        // Zoo.totalExpenses.Add(Cost.Food);
        // animal.Expenses.Add(Cost.Food);
    }
    //Lägg till Lista för djur som personalen ska mata
    //OM djur behöver matas, anropa metod FeedAnimal()
}
public class Cleaning : Personal
{
    public static List<Cleaning> personals = new List<Cleaning>();
    public const string workTask = "Cleaning";
    public void CleanAnimalEnclosure(Animal animal)     //SKAPA MENYMETOD SOM LISTAR PERSONALENS ASSIGNEDANIMALS OCH ANROPA SEDAN DENNA METOD VID VAL AV DJUR
    {
        Console.WriteLine($"Inhägnaden för {animal.Name} har rengjorts.");
    }
}
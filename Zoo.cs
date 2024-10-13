public static class Zoo
{
    public static List<Animal> animals = new List<Animal>();
    public static List<Personal> personals = new List<Personal>();
    public static List<string> animalHealthLog = new List<string>();
    public static List<string> animalFoodLog = new List<string>();
    public static List<int> totalExpenses = new List<int>();
    public static void AddNewAnimal(string name, string species, int age, string country, int foodPerDay)
    {
        int foodIntervall = 12 / foodPerDay;

        var animal = new Animal
        { Name = name,
            Species = species,
            Age = age,
            OriginCountry = country,
            FoodIntervall = foodIntervall,
            Health = AnimalHealth.Good,
            LastCheckup = DateTime.Now,
            NextCheckup = DateTime.Now, //DateTime.Now.AddDays(5),
            FeedSchedule = DateTime.Now.AddHours(foodIntervall)
        };

        animals.Add(animal);
        Personal.AnimalsNotAssigned.Add(animal);
    }

    public static void AddNewPersonal(string name, Task task, List<Animal> animals)  //List<Animal> animals?
    {
        //OM Task = Healthcare
        //Zoo.personals.Add(new HealthCare)
        //Osv..

        //
        switch(task)
        {
            case Task.Healthcare:
                var caretaker = new HealthCare { Name = name, AssignedAnimals = animals };
                personals.Add(caretaker);     //Byta ut schedule mot djurLista?
                HealthCare.personals.Add(caretaker);
                break;
            case Task.Foodcare:
                var feeder = new FoodCare { Name = name, AssignedAnimals = animals };
                personals.Add(feeder);
                FoodCare.personals.Add(feeder);
                break;
            case Task.Cleaning:
                var cleaner = new Cleaning { Name = name, AssignedAnimals = animals };
                personals.Add(cleaner);
                Cleaning.personals.Add(cleaner);
                break;            
        }
        //Zoo.personals.Add(new Personal { Name = name, Schedule = schedule });
    }

    public static void ShowHealthLog()
    {
        foreach (string log in animalHealthLog)
        {
            Console.WriteLine(log);
        }
    }

    //Sök efter personal baserat på Arbetsuppgifter
    public static void SearchPersonalByTask(Task task)
    {
        switch(task)
        {
            case Task.Healthcare:
                foreach (HealthCare personal in HealthCare.personals)
                {
                    Console.WriteLine(personal.ToString());
                }
                break;
            case Task.Foodcare:
                foreach (FoodCare personal in FoodCare.personals)
                {
                    Console.WriteLine(personal.ToString());
                }
                break;
            case Task.Cleaning:
                foreach (Cleaning personal in Cleaning.personals)
                {
                    Console.WriteLine(personal.ToString());
                }
                break;            
        }
    }
    

    //Sök efter djur baserat på art, namn eller ursprungsland
    public static void SearchAnimal(string searchFor, string findAnimal)
    {
        var animalSpecies = new List<Animal>();
        var animalCountry = new List<Animal>();
        
        switch(searchFor)
        {
            case "Ras":
                foreach (Animal animal in animals)
                {
                    if (findAnimal == animal.Species)
                    {
                        animalSpecies.Add(animal);
                    }
                }
                foreach (Animal animal in animalSpecies)
                {
                    Console.WriteLine(animal.ToString());
                }
                Console.ReadKey();
                break;
            
            case "Land":
                foreach (Animal animal in animals)
                {
                    if (findAnimal == animal.OriginCountry)
                    {
                        animalCountry.Add(animal);
                    }
                }
                foreach (Animal animal in animalCountry)
                {
                    Console.WriteLine(animal.ToString());
                }
                Console.ReadKey();
                break;
        }
        
    }

    //Uppdatera info om djurs ålder eller hälsa

    //Uppdatera info om personals arbetsuppgifter

    public static void ShowAnimals()
    {
        foreach (Animal animal in animals)
        {
            Console.WriteLine(animal.ToString());
        }
    }
    public static void ShowPersonals()
    {
        foreach (Personal personal in personals)
        {
            personal.PersonalInfo();
        }
    }

    public static void AnimalsToFeed()
    {}
}


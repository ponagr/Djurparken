public class Animal
{
    public string Name { get; set; }
    public string Species { get; set; }
    public int Age { get; set; }
    public string OriginCountry { get; set; }
    public int FoodIntervall { get; set; }
    
    public List<int> Expenses { get; set; } = new List<int>();
    
    //Lägg till check för detta, lägg till datum för LastCheckup,
    //OM Healt = Health.Bad 
        //Kontrollera OM LastCheckup < 1 dag från nuvarande DateAndTime
        //Isåfall är bool NeedsCheckup false
        //Annars är bool NeedsCheckup true
    //
    //Annars OM Healt = Health.Good
        //Kontrollera OM LastCheckup < 5 dagar från nuvarande DateAndTime
        //Isåfall är bool NeedsCheckup false
        //Annars är bool NeedsCheckup true
    public AnimalHealth Health { get; set; }
    public DateTime LastCheckup { get; set; }
    public DateTime NextCheckup { get; set; }
    public DateTime FeedSchedule { get; set; }
    
    public bool NeedsCheckup 
    { 
        get
        {
            return Health == AnimalHealth.Bad || (DateTime.Now >= NextCheckup);
        }  
    }
    public List<string> HealthLog { get; set; } = new List<string>();
    public List<string> FeedLog { get; set; } = new List<string>();

    //Jämför detta med FoodCare Personal, om klockan är samma som FeedSchedule så ska personalen mata djuret
    public void ShowHealthLog()
    {
        Console.Write("Logg för: ");
        ToString();
        Console.WriteLine($"\nKommande Hälsokontroll: {NextCheckup}");
        Console.WriteLine("Tidigare Hälsokontroller: ");
        foreach (string log in HealthLog)
        {
            Console.WriteLine($"{log}");
        }
    }
    public void ShowFeedLog()
    {
        Console.Write("Logg för: ");
        ToString();
        Console.WriteLine($"\nKommande Hälsokontroll: {NextCheckup}");
        Console.WriteLine("Tidigare Hälsokontroller: ");
        foreach (string log in FeedLog)
        {
            Console.WriteLine($"{log}");
        } 
    }
    public void ShowExpenses()
    {
        int total = 0;
        for (int i = 0; i < Expenses.Count; i++)
        {
            Console.WriteLine(Expenses[i]);
             
            total += Expenses[i];
        }
        Console.WriteLine($"\nTotalsumma av utgifter: {total}");
    }


    public override string ToString()
    {
        return $"Namn: {Name}, Ras: {Species}, Ålder: {Age}, Land: {OriginCountry}";
    }
}
public enum AnimalHealth
{
    Good,
    Bad
}
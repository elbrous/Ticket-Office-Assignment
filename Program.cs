using System;

public enum Place
{
    Seated,
    Standing
}

public class Ticket
{
    public int Age { get; private set; }
    public Place Place { get; private set; }
    public int Number { get; private set; }

    public Ticket(int age, Place place)
    {
        Age = age;
        Place = place;
        Number = TicketNumberGenerator();
    }

    public int Price()
    {
        int price;
        switch (Age)
        {
            case int n when (n <= 11):
                price = (Place == Place.Seated) ? 50 : 25;
                break;
            case int n when (n >= 12 && n <= 64):
                price = (Place == Place.Seated) ? 170 : 110;
                break;
            default:
                price = (Place == Place.Seated) ? 100 : 60;
                break;
        }
        return price;
    }

    public decimal Tax()
    {
        int price = Price();
        decimal tax = (decimal)((1 - 1 / 1.06) * price);
        return tax;
    }

    private int TicketNumberGenerator()
    {
        Random random = new Random();
        return random.Next(1, 8001);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Ticket Office!");
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        Console.Write("Enter your preference (Seated or Standing): ");
        string preferenceInput = Console.ReadLine();
        Place placePreference;
        Enum.TryParse(preferenceInput, true, out placePreference);

        Ticket customerTicket = new Ticket(age, placePreference);

        Console.WriteLine($"Total Price: {customerTicket.Price()} SEK");
        Console.WriteLine($"Tax: {customerTicket.Tax()} SEK");
        Console.WriteLine($"Ticket Number: {customerTicket.Number}");
        Console.WriteLine("Thank you for choosing us!");
    }
}


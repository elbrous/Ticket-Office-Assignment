using System;

public enum PlacePreference
{
    Seated,
    Standing
}

public class Ticket
{
    public int Age { get; set; }
    public PlacePreference Place { get; set; }

    public Ticket(int age, PlacePreference place)
    {
        Age = age;
        Place = place;
    }

    public int PriceSetter()
    {
        int price;
        switch (Age)
        {
            case int n when (n <= 11):
                price = (Place == PlacePreference.Seated) ? 50 : 25;
                break;
            case int n when (n >= 12 && n <= 64):
                price = (Place == PlacePreference.Seated) ? 170 : 110;
                break;
            default:
                price = (Place == PlacePreference.Seated) ? 100 : 60;
                break;
        }
        return price;
    }

    public decimal TaxCalculator(int price)
    {
        decimal tax = (decimal)((1 - 1 / 1.06) * price);
        return tax;
    }

    public int TicketNumberGenerator()
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
        PlacePreference placePreference;
        Enum.TryParse(preferenceInput, true, out placePreference);

        Ticket customerTicket = new Ticket(age, placePreference);

        int ticketPrice = customerTicket.PriceSetter();
        decimal tax = customerTicket.TaxCalculator(ticketPrice);
        int ticketNumber = customerTicket.TicketNumberGenerator();

        Console.WriteLine($"Total Price: {ticketPrice} SEK");
        Console.WriteLine($"Tax: {tax} SEK");
        Console.WriteLine($"Ticket Number: {ticketNumber}");
        Console.WriteLine("Thank you for choosing us!");
    }
}

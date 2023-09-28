using System;

namespace TicketOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask the customer for their age and place preference
            Console.WriteLine("Welcome to the Ticket Office!");
            Console.Write("Please enter your age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Do you want a standing or a seated ticket? ");
            string place = Console.ReadLine().ToLower();

            // Call the PriceSetter method to get the ticket price based on the age and place
            int price = PriceSetter(age, place);

            // Call the TaxCalculator method to get the tax amount based on the price
            decimal tax = TaxCalculator(price);

            // Call the TicketNumberGenerator method to get a random ticket number
            int ticketNumber = TicketNumberGenerator();

            // Display the total price, tax and ticket number to the customer
            Console.WriteLine($"Your total price is {price} SEK, including {tax} SEK tax.");
            Console.WriteLine($"Your ticket number is {ticketNumber}.");
            Console.WriteLine("Thank you for choosing us!");
        }

        // The PriceSetter method returns the ticket price based on the age and place
        static int PriceSetter(int age, string place)
        {
            int price = 0;
            if (place == "seated")
            {
                if (age <= 11)
                {
                    price = 50;
                }
                else if (age >= 65)
                {
                    price = 100;
                }
                else
                {
                    price = 170;
                }
            }
            else if (place == "standing")
            {
                if (age <= 11)
                {
                    price = 25;
                }
                else if (age >= 65)
                {
                    price = 60;
                }
                else
                {
                    price = 110;
                }
            }
            else
            {
                Console.WriteLine("Invalid place. Please enter standing or seated.");
            }
            return price;
        }

        // The TaxCalculator method returns the tax amount based on the price
        static decimal TaxCalculator(int price)
        {
            decimal tax = (1 - 1 / 1.06m) * price;
            return tax;
        }

        // The TicketNumberGenerator method returns a random number between 1 and 8000
        static int TicketNumberGenerator()
        {
            Random random = new Random();
            int ticketNumber = random.Next(1, 8001);
            return ticketNumber;
        }
    }
}


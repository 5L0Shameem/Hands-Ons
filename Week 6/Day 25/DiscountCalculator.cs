using System;

class DiscountCalculator
{
    static void Main()
    {
        Console.Write("Enter Product Name: ");
        string name = Console.ReadLine();

        double price;
        double discount;

        while (true)
        {
            Console.Write("Enter Product Price: ");
            if (double.TryParse(Console.ReadLine(), out price) && price >= 0)
                break;
            Console.WriteLine("Invalid Price");
        }

        while (true)
        {
            Console.Write("Enter Discount Percentage: ");
            if (double.TryParse(Console.ReadLine(), out discount) && discount >= 0)
                break;
            Console.WriteLine("Invalid Discount");
        }

        double finalPrice = price - (price * discount / 100);

        Console.WriteLine("\nProduct Name: " + name);
        Console.WriteLine("Original Price: " + price);
        Console.WriteLine("Discount: " + discount + "%");
        Console.WriteLine("Final Price: " + finalPrice);
    }
}

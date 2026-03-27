using System;

class EmployeePerformanceEvaluator
{
    static (double, int) GetPerformanceData(double sales, int rating)
    {
        return (sales, rating);
    }

    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        double sales;
        int rating;

        while (true)
        {
            Console.Write("Enter Sales Amount: ");
            if (double.TryParse(Console.ReadLine(), out sales) && sales >= 0)
                break;
            Console.WriteLine("Invalid Sales Amount");
        }

        while (true)
        {
            Console.Write("Enter Rating (1-5): ");
            if (int.TryParse(Console.ReadLine(), out rating) && rating >= 1 && rating <= 5)
                break;
            Console.WriteLine("Invalid Rating");
        }

        var data = GetPerformanceData(sales, rating);

        string performance = data switch
        {
            ( >= 100000, >= 4) => "High Performer",
            ( >= 50000, >= 3) => "Average Performer",
            _ => "Needs Improvement"
        };

        Console.WriteLine("\nEmployee Name: " + name);
        Console.WriteLine("Sales Amount: " + data.Item1);
        Console.WriteLine("Rating: " + data.Item2);
        Console.WriteLine("Performance: " + performance);
    }
}

using System;
class Q3
{
    static void Main()
    {
        Console.Write("Enter Employee Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        double salary = double.Parse(Console.ReadLine());

        Console.Write("Enter Experience (years): ");
        double experience = double.Parse(Console.ReadLine());

        double bonusPercentage = (experience < 2) ? 0.05 :
                                 (experience <= 5) ? 0.10 : 0.15;

        double bonus = salary * bonusPercentage;
        double finalSalary = salary + bonus;

        Console.WriteLine("Employee: " + name);
        Console.WriteLine("Bonus: " + bonus);
        Console.WriteLine("Final Salary: " + finalSalary);
    }
}

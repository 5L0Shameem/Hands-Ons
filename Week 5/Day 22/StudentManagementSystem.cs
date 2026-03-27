using System;
using System.Collections.Generic;

record Student(int RollNumber, string Name, string Course, int Marks);

class StudentManagementSystem
{
    static void Main()
    {
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("\n--- Student Record Management ---");
            Console.WriteLine("1. Add Students");
            Console.WriteLine("2. Display All Students");
            Console.WriteLine("3. Search Student by Roll Number");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid choice");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.Write("Enter number of students: ");
                    int n;
                    if (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
                    {
                        Console.WriteLine("Invalid number");
                        break;
                    }

                    for (int i = 0; i < n; i++)
                    {
                        int roll, marks;

                        while (true)
                        {
                            Console.Write("Enter Roll Number: ");
                            if (int.TryParse(Console.ReadLine(), out roll) && roll > 0)
                                break;
                            Console.WriteLine("Invalid Roll Number");
                        }

                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter Course: ");
                        string course = Console.ReadLine();

                        while (true)
                        {
                            Console.Write("Enter Marks: ");
                            if (int.TryParse(Console.ReadLine(), out marks) && marks >= 0)
                                break;
                            Console.WriteLine("Invalid Marks");
                        }

                        students.Add(new Student(roll, name, course, marks));
                        Console.WriteLine();
                    }
                    break;

                case 2:
                    Console.WriteLine("\nStudent Records:");
                    if (students.Count == 0)
                    {
                        Console.WriteLine("No records found");
                    }
                    else
                    {
                        foreach (var s in students)
                        {
                            Console.WriteLine($"Roll No: {s.RollNumber} | Name: {s.Name} | Course: {s.Course} | Marks: {s.Marks}");
                        }
                    }
                    break;

                case 3:
                    Console.Write("Enter Roll Number to search: ");
                    int searchRoll;
                    if (!int.TryParse(Console.ReadLine(), out searchRoll))
                    {
                        Console.WriteLine("Invalid Roll Number");
                        break;
                    }

                    var result = students.Find(s => s.RollNumber == searchRoll);

                    Console.WriteLine("\nSearch Result:");
                    if (result != null)
                    {
                        Console.WriteLine("Student Found:");
                        Console.WriteLine($"Roll No: {result.RollNumber} | Name: {result.Name} | Course: {result.Course} | Marks: {result.Marks}");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                    break;

                case 4:
                    return;

                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }
    }
}

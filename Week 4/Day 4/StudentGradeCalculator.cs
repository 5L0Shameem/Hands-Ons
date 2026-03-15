using System;

class Student
{
    public double CalculateAverage(int m1, int m2, int m3)
    {
        return (m1 + m2 + m3) / 3.0;
    }
}

class StudentGradeCalculatorProgram
{
    static void Main()
    {
        Student student = new Student();

        Console.Write("Enter Marks of 3 subjects separated by space: ");
        string[] input = Console.ReadLine().Split(' ');

        int m1 = int.Parse(input[0]);
        int m2 = int.Parse(input[1]);
        int m3 = int.Parse(input[2]);

        double average = student.CalculateAverage(m1, m2, m3);

        string grade;

        if (average >= 90)
            grade = "A+";
        else if (average >= 75)
            grade = "A";
        else if (average >= 60)
            grade = "B";
        else if (average >= 40)
            grade = "C";
        else
            grade = "Fail";

        Console.WriteLine("Average = " + average);
        Console.WriteLine("Grade = " + grade);
    }
}

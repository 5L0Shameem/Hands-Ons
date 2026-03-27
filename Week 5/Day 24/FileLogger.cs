using System;
using System.IO;
using System.Text;

class FileLogger
{
    static void Main()
    {
        Console.Write("Enter message: ");
        string message = Console.ReadLine();

        try
        {
            FileStream fs = new FileStream("log.txt", FileMode.Append, FileAccess.Write);
            byte[] data = Encoding.UTF8.GetBytes(message + Environment.NewLine);

            fs.Write(data, 0, data.Length);
            fs.Close();

            Console.WriteLine("Message written to file successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Operation completed");
        }
    }
}

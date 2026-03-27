using System;
using System.IO;

class FileInspector
{
    static void Main()
    {
        Console.Write("Enter folder path: ");
        string path = Console.ReadLine();

        try
        {
            if (!Directory.Exists(path))
            {
                Console.WriteLine("Invalid directory path");
                return;
            }

            string[] files = Directory.GetFiles(path);
            int count = 0;

            Console.WriteLine("\nFile Details:");

            foreach (string file in files)
            {
                FileInfo fi = new FileInfo(file);

                Console.WriteLine("Name: " + fi.Name);
                Console.WriteLine("Size: " + fi.Length + " bytes");
                Console.WriteLine("Created: " + fi.CreationTime);
                Console.WriteLine();

                count++;
            }

            Console.WriteLine("Total Files: " + count);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

using System;
using System.IO;

class DirectoryAnalyzer
{
    static void Main()
    {
        Console.Write("Enter root directory path: ");
        string path = Console.ReadLine();

        try
        {
            DirectoryInfo dir = new DirectoryInfo(path);

            if (!dir.Exists)
            {
                Console.WriteLine("Invalid directory path");
                return;
            }

            DirectoryInfo[] subDirs = dir.GetDirectories();

            Console.WriteLine("\nDirectory Details:");

            foreach (DirectoryInfo subDir in subDirs)
            {
                FileInfo[] files = subDir.GetFiles();
                Console.WriteLine(subDir.Name + " - Files Count: " + files.Length);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}

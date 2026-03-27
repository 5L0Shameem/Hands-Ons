using System;
using System.Threading.Tasks;

class AsyncFileLogger
{
    static async Task WriteLogAsync(string message)
    {
        await Task.Delay(1000);
        Console.WriteLine("Log Written: " + message);
    }

    static async Task Main()
    {
        Task t1 = WriteLogAsync("User logged in");
        Task t2 = WriteLogAsync("File uploaded");
        Task t3 = WriteLogAsync("Error occurred");

        Console.WriteLine("Logging in progress...");

        await Task.WhenAll(t1, t2, t3);

        Console.WriteLine("All logs completed");
    }
}

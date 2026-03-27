using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int Code { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public double Mrp { get; set; }
}

class LinqOperations
{
    static void Main()
    {
        List<Product> products = new List<Product>
        {
            new Product { Code = 101, Name = "Soap", Category = "FMCG", Mrp = 25 },
            new Product { Code = 102, Name = "Rice", Category = "Grain", Mrp = 50 },
            new Product { Code = 103, Name = "Oil", Category = "FMCG", Mrp = 120 },
            new Product { Code = 104, Name = "Wheat", Category = "Grain", Mrp = 40 },
            new Product { Code = 105, Name = "Shampoo", Category = "FMCG", Mrp = 60 }
        };

        var fmcg = products.Where(p => p.Category == "FMCG");
        var grain = products.Where(p => p.Category == "Grain");

        var sortByCode = products.OrderBy(p => p.Code);
        var sortByCategory = products.OrderBy(p => p.Category);
        var sortByMrpAsc = products.OrderBy(p => p.Mrp);
        var sortByMrpDesc = products.OrderByDescending(p => p.Mrp);

        var groupByCategory = products.GroupBy(p => p.Category);
        var groupByMrp = products.GroupBy(p => p.Mrp);

        var highestFmcg = products
            .Where(p => p.Category == "FMCG")
            .OrderByDescending(p => p.Mrp)
            .FirstOrDefault();

        var totalCount = products.Count();
        var fmcgCount = products.Count(p => p.Category == "FMCG");

        var maxPrice = products.Max(p => p.Mrp);
        var minPrice = products.Min(p => p.Mrp);

        var allBelow30 = products.All(p => p.Mrp < 30);
        var anyBelow30 = products.Any(p => p.Mrp < 30);

        Console.WriteLine("FMCG Products:");
        foreach (var p in fmcg)
            Console.WriteLine(p.Name);

        Console.WriteLine("\nGrain Products:");
        foreach (var p in grain)
            Console.WriteLine(p.Name);

        Console.WriteLine("\nSorted by Code:");
        foreach (var p in sortByCode)
            Console.WriteLine(p.Code + " " + p.Name);

        Console.WriteLine("\nSorted by Category:");
        foreach (var p in sortByCategory)
            Console.WriteLine(p.Category + " " + p.Name);

        Console.WriteLine("\nSorted by MRP Asc:");
        foreach (var p in sortByMrpAsc)
            Console.WriteLine(p.Name + " " + p.Mrp);

        Console.WriteLine("\nSorted by MRP Desc:");
        foreach (var p in sortByMrpDesc)
            Console.WriteLine(p.Name + " " + p.Mrp);

        Console.WriteLine("\nGroup by Category:");
        foreach (var g in groupByCategory)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
                Console.WriteLine("  " + p.Name);
        }

        Console.WriteLine("\nGroup by MRP:");
        foreach (var g in groupByMrp)
        {
            Console.WriteLine(g.Key);
            foreach (var p in g)
                Console.WriteLine("  " + p.Name);
        }

        Console.WriteLine("\nHighest FMCG Product:");
        if (highestFmcg != null)
            Console.WriteLine(highestFmcg.Name + " " + highestFmcg.Mrp);

        Console.WriteLine("\nTotal Products: " + totalCount);
        Console.WriteLine("FMCG Count: " + fmcgCount);

        Console.WriteLine("\nMax Price: " + maxPrice);
        Console.WriteLine("Min Price: " + minPrice);

        Console.WriteLine("\nAll below 30: " + allBelow30);
        Console.WriteLine("Any below 30: " + anyBelow30);
    }
}

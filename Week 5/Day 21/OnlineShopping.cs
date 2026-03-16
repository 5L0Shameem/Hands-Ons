using System;

class Product
{
    private double price;
    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public double Price
    {
        get { return price; }
        set
        {
            if (value >= 0)
                price = value;
            else
                Console.WriteLine("Price cannot be negative");
        }
    }

    public virtual double CalculateDiscount()
    {
        return Price;
    }
}

class Electronics : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.05);
    }
}

class Clothing : Product
{
    public override double CalculateDiscount()
    {
        return Price - (Price * 0.15);
    }
}

class Program
{
    static void Main()
    {
        Product e = new Electronics();
        e.Name = "Laptop";
        e.Price = 20000;

        Product c = new Clothing();
        c.Name = "Shirt";
        c.Price = 2000;

        Console.WriteLine("Electronics Final Price after 5% discount = " + e.CalculateDiscount());
        Console.WriteLine("Clothing Final Price after 15% discount = " + c.CalculateDiscount());
    }
}

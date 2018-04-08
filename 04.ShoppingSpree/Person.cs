using System;
using System.Collections.Generic;
using System.Text;


public class Person
{
    private string name;
    private decimal money;
    private List<Product> products;

    public List<Product> Products
    {
        get { return products; }
        set { this.products = value; }
    }

    public decimal Money
    {
        get { return money; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Money cannot be negative");
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Name cannot be empty");
            name = value;
        }
    }

    public Person()
    {
        this.Products = new List<Product>();
    }

    public Person(string name, decimal money) : this()
    {
        Name = name;
        Money = money;
    }

    public string TryBayProduct(Product product)
    {
        if (this.Money < product.Cost)
        {
            return $"{Name} can't afford {product.Name}";
        }
        this.Money -= product.Cost;
        this.Products.Add(product);

        return $"{Name} bought {product.Name}";

    }
}
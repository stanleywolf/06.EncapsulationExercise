using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Pizza
{
    private const int MIN_LENGHT = 1;
    private const int MAX_LENGHT = 15;
    private const int MIN_TOPPINGS = 0;
    private const int MAX_TOPPINGS = 10;

    private string  name;
    private Dough Dough { get; set; }
    private List<Topping> Toppings { get; set; }

    private double Calories => Dough.Calories + this.ToppingsCalories;

    public double ToppingsCalories
    {
        get
        {
            if (Toppings.Count == 0)
            {
                return 0;
            }
            return Toppings.Select(t => t.Calories).Sum();
        } 
    }

    public string  Name
    {
        get { return name; }
        set
        {
            if (string.IsNullOrEmpty(value) || value.Length > MAX_LENGHT)
            {
                throw new ArgumentException($"Pizza name should be between {MIN_LENGHT} and {MAX_LENGHT} symbols.");
            }
            name = value;
        }
    }

    public Pizza()
    {
        this.Toppings = new List<Topping>();
    }

    public Pizza(string name) : this()
    {
        this.Name = name;       
    }

    public void AddTopping(Topping topping)
    {
        this.Toppings.Add(topping);
        if (Toppings.Count > MAX_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_TOPPINGS}..{MAX_TOPPINGS}].");
        }
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:f2} Calories.";
    }

    public void SetDough(Dough dough)
    {
        if (Dough != null)
        {
            throw new InvalidOperationException("Dough already set!!!");
        }
        Dough = dough;
    }
}
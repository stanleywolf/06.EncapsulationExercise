using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Topping
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 50;
    private const int DEFAULT_MULTYPLIER = 2;

    private Dictionary<string, double> validTypes = new Dictionary<string, double>()
    {
        ["meat"] = 1.2,
        ["veggies"] = 0.8,
        ["cheese"] = 1.1,
        ["sause"] = 0.9
    };
    private string type;
    private double weight;

    private double TypeMultyplier => validTypes[Type];

    public double Calories => DEFAULT_MULTYPLIER * Weight * TypeMultyplier;

    public Topping(string type, double weight)
    {
        Type = type;
        ValidateWeight(type, weight);
        Weight = weight;
    }

    private void ValidateWeight(string type, double weight)
    {
        if (weight < MIN_WEIGHT || weight > MAX_WEIGHT)
        {
            throw new ArgumentException($"{type} weight should be in the range[{MIN_WEIGHT}..{MAX_WEIGHT}].");
        }       
    }

    public string Type
    {
        get { return type; }
        set
        {
            if (!this.validTypes.Any(f=>f.Key == value.ToLower()))
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value.ToLower();
        }
    }
    public double Weight
    {
        get { return weight; }
        set
        {
            
            weight = value;
        }
    }

    

}
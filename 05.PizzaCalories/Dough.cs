using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Dough
{
    private const int MIN_WEIGHT = 1;
    private const int MAX_WEIGHT = 200;
    private const int DEFAULT_MULTYPLIER = 2;


    private Dictionary<string, double> validFlourTypes = new Dictionary<string, double>()
    {
        ["white"] =  1.5,
        ["wholegrain"] = 1.0
    };
    private Dictionary<string,double> validBakingTehnoque = new Dictionary<string, double>()
    {
        ["crispy"] = 0.9,
        ["chewy"] = 1.1,
        ["homemade"] = 1.0
    };

    private double weight;
    private string flourType;
    private string bakingTechnique;

    public Dough(string flourType, string bakingTechnique, double weight)
    {
        FlourType = flourType;
        BakingTehnique = bakingTechnique;
        Weight = weight;
    }

    private double FlourMultyplier => validFlourTypes[this.FlourType];

    private double BakingTechniqueMultiplier => validBakingTehnoque[this.BakingTehnique];

    public double Calories => DEFAULT_MULTYPLIER * Weight * FlourMultyplier * BakingTechniqueMultiplier;

    public double Weight
    {
        get { return weight; }
        set
        {
            if (value< MIN_WEIGHT || value > MAX_WEIGHT)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_WEIGHT}..{MAX_WEIGHT}].");
            }
            weight = value;
        }
    }
    public string FlourType
    {
        get { return flourType; }
        set
        {
            ValidateTypes(value, validFlourTypes);
            flourType = value.ToLower();
        }
    }

    public string BakingTehnique
    {
        get { return bakingTechnique; }
        set
        {
            ValidateTypes(value, validBakingTehnoque);
            bakingTechnique = value.ToLower();
        }
    }

    private static void ValidateTypes(string type, Dictionary<string, double> doughDictionary)
    {
        if (!doughDictionary.Any(f => f.Key == type.ToLower()))
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }
}
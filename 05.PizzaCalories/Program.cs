using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string pizzaName = Console.ReadLine().Split()[1];
            Pizza pizza = new Pizza(pizzaName);

            Dough dough = CreateDough();
            pizza.SetDough(dough);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                CreateTopping(pizza, command);
            }
            Console.WriteLine(pizza);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
       
    }

    private static Dough CreateDough()
    {
        var doughInput = Console.ReadLine().Split();
        var flourType = doughInput[1];
        var bakingTechnique = doughInput[2];
        var doughWeight = double.Parse(doughInput[3]);

        Dough dough = new Dough(flourType, bakingTechnique, doughWeight);
        
        return dough;
    }

    private static void CreateTopping(Pizza pizza, string command)
    {
        var toppingInput = command.Split();
        var toppingName = toppingInput[1];
        var toppingWeight = double.Parse(toppingInput[2]);

        Topping topping = new Topping(toppingName, toppingWeight);
        pizza.AddTopping(topping);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main(string[] args)
    {
        var inputP = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        var peoples= new List<Person>();
        var products = new List<Product>();

        foreach (var inp in inputP)
        {
            var spInput = inp.Split("=");
            try
            {
                var name = spInput[0];
                var money = decimal.Parse(spInput[1]);
                var people = new Person(name,money);
                peoples.Add(people);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
        var inputPr = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
        foreach (var inp in inputPr)
        {
            var spInput = inp.Split("=");
            try
            {
                var name = spInput[0];
                var cost = decimal.Parse(spInput[1]);
                var product = new Product(name, cost);
                products.Add(product);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }                

        string command;
        while ((command = Console.ReadLine()) != "END")
        {
            var commArgs = command.Split();
            var personName = commArgs[0];
            var productName = commArgs[1];

            var people = peoples.Single(p => p.Name == personName);
            var product = products.Single(p => p.Name == productName);

            string output = people.TryBayProduct(product);
            Console.WriteLine(output);
        }
        foreach (var people in peoples)
        {
            if (people.Products.Count == 0)
            {
                Console.WriteLine($"{people.Name} - Nothing bought");
            }
            else
            {
                var prBought = string.Join(", ", people.Products.Select(p => p.Name));
                Console.WriteLine($"{people.Name} - {prBought}");
            }

        }       
    }
}
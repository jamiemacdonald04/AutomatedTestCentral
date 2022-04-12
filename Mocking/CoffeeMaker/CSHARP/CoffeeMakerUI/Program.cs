using System;
using CoffeeMaker;
namespace CoffeeMakerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var makeCofee = new MakeCoffee();
            makeCofee.MakeAllCoffees();
            Console.ReadLine();
        }
    }
}

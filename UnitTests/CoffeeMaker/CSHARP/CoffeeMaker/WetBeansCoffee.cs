using System;
using System.Collections.Generic;
using CoffeeMaker.interfaces;

namespace CoffeeMaker
{
    public class WetBeansCoffee : ICoffee
    {

        public WetBeansCoffee()
        {

        }

        public CoffeeModel AssignCoffeeProperties(int sugarLumps, string label,bool withMilk, string origin =null)
        {
            CoffeeModel coffee = new CoffeeModel();
            coffee.Label = label;
            coffee.Milk = withMilk;
            coffee.SugarLumps = sugarLumps;
            coffee.BeanOrigin = origin;
            return coffee;
        }


        public int GetBeans()
        {
            return 4;
        }

        public bool GrindBeans(string powerSource)
        {
            if(powerSource !=null && powerSource.ToLower() == "wind")
            {
                return true;
            }
            throw new ArgumentNullException("Parameter Type cannot be null");
        }

        public List<CoffeeModel> GroupOrder()
        {
            List<CoffeeModel> coffeeList = new List<CoffeeModel>();
            CoffeeModel coffeeOne = new CoffeeModel();
            CoffeeModel coffeeTwo = new CoffeeModel();
            CoffeeModel coffeeThree = new CoffeeModel();

            coffeeOne = AssignCoffeeProperties(1, "Frapachino", true, "France");
            coffeeTwo = AssignCoffeeProperties(1, "Capachino", true, "Italy");
            coffeeThree = AssignCoffeeProperties(1, "Latte", true, "Cambodia");
         
            coffeeList.Add(coffeeOne);
            coffeeList.Add(coffeeTwo);
            coffeeList.Add(coffeeThree);

            return coffeeList;
        }

        public string dry_beans()
        {
            int random_number = new Random().Next(1, 10);

            if (random_number % 2 == 0)
            {
                return "beans are dry";
            }

            return "beans are not dry";
        }
    }
}

using System;
namespace CoffeeMaker
{
    public class MakeCoffee
    {
        public MakeCoffee()
        {

        }
        public void MakeAllCoffees()
        {
            ICoffeeSelect weakCoffee = new WeakCoffee();
            ICoffeeSelect wetCoffee = new DryBeansCoffee();
            ICoffeeSelect dryCoffee = new WetBeansCoffee();

            ICoffeeMaker weakCoffeeMaker = new CoffeeMaker(weakCoffee);
            ICoffeeMaker dryCoffeeMaker = new CoffeeMaker(dryCoffee);
            ICoffeeMaker wetCoffeeMaker = new CoffeeMaker(wetCoffee);

            Console.WriteLine(weakCoffeeMaker.MakingCoffee());
            Console.WriteLine(dryCoffeeMaker.MakingCoffee());
            Console.WriteLine(wetCoffeeMaker.MakingCoffee());
        }
    }
}

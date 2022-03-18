using System;
namespace CoffeeMaker
{
    public class CoffeeMaker : ICoffeeMaker
    {
        private ICoffeeSelect coffeeSelect;

        public CoffeeMaker(ICoffeeSelect coffeeSelect)
        {
            this.coffeeSelect = coffeeSelect;
        }

        // Simplify
        public string MakingCoffee()
        {
            if (coffeeSelect.GetBeans() <= 0)
            {
                return "No coffee available";
            }
            if (!this.coffeeSelect.GrindBeans())
            {
                return "No ground coffee available";
            }
            return this.brew();
        }

        private string brew()
        {
            return "Coffee has now been brewed";
        }
    }
}

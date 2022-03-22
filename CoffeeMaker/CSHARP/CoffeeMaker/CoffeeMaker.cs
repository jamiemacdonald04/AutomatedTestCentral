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

        public string MakingCoffee()
        {
            var beans = coffeeSelect.GetBeans();
            if (beans <= 0)
            {
                return "No coffee available";
            }
            if (!this.coffeeSelect.GrindBeans())
            {
                return "No ground coffee available";
            }
            return this.brew(beans);
        }

        private string brew(int beans)
        {
            return $"Coffee has now been brewed with {beans} beans";
        }
    }
}

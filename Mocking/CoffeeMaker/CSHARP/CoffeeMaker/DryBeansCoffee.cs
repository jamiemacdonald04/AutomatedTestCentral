using System;
namespace CoffeeMaker
{
    public class DryBeansCoffee : ICoffeeSelect
    {
        public DryBeansCoffee()
        {
        }

        public int GetBeans()
        {
            return 3;
        }

        public bool GrindBeans()
        {
            return true;
        }
    }
}

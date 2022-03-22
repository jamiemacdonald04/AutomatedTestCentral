using System;
namespace CoffeeMaker
{
    public class WeakCoffee : ICoffeeSelect
    {

        public WeakCoffee()
        {
        }

        public int GetBeans()
        {
            return 1;
        }

        public bool GrindBeans()
        {
            return true;
        }
    } 
    
}

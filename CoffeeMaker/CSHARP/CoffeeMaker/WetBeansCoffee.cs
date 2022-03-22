using System;
namespace CoffeeMaker
{
    public class WetBeansCoffee : ICoffeeSelect
    {
        public WetBeansCoffee()
        {
        }

        public int GetBeans()
        {
            return 4;
        }

        public bool GrindBeans()
        {
            if(dry_beans() == "beans are dry")
            {
                return true;
            }

            return false;
        }

        private string dry_beans()
        {
            return "beans are dry";
        }
    }
}

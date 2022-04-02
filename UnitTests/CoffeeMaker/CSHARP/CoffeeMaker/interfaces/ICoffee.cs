
using System.Collections.Generic;

namespace CoffeeMaker.interfaces
{
    public interface ICoffee
    {
        public CoffeeModel AssignCoffeeProperties(int sugarLumps, string label, bool withMilk, string origin = null);

        public int GetBeans();


        public bool GrindBeans(string powerSource);


        public List<CoffeeModel> GroupOrder();


        public string dry_beans();
    }
}

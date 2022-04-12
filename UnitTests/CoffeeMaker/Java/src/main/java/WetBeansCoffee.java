import Interfaces.ICoffee;
import Models.CoffeeModel;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class WetBeansCoffee  implements ICoffee {

    public CoffeeModel AssignCoffeeProperties(int sugarLumps, String label,Boolean withMilk, String origin)
    {
        CoffeeModel coffee = new CoffeeModel();
        coffee.setLabel(label);
        coffee.setMilk(withMilk);
        coffee.setSugarLumps(sugarLumps);
        coffee.setBeanOrigin(origin);
        return coffee;
    }


    public int GetBeans()
    {
        return 4;
    }

    public boolean GrindBeans(String powerSource)
    {
        if(powerSource !=null && powerSource != "")
        {
            return true;
        }
        throw new NullPointerException("Parameter Type cannot be null");
    }

    public List<CoffeeModel> GroupOrder()
    {
        List<CoffeeModel> coffeeList = new ArrayList<CoffeeModel>();
        coffeeList.add(AssignCoffeeProperties(1, "Frapachino", true, "France"));
        coffeeList.add(AssignCoffeeProperties(1, "Capachino", true, "Italy"));
        coffeeList.add(AssignCoffeeProperties(1, "Latte", true, "Cambodia"));

        return coffeeList;
    }

    public String dry_beans()
    {
        Random randomNumberGenerator = new Random();
        int randomNumber = randomNumberGenerator.nextInt();
        if (randomNumber % 2 == 0)
        {
            return "beans are dry";
        }

        return "beans are not dry";
    }


}

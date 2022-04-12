import Interfaces.ICoffeeMaker;
import Interfaces.ICoffeeSelect;
import jdk.jshell.spi.ExecutionControl;

public class CoffeeMaker implements ICoffeeMaker {

    private ICoffeeSelect coffeeSelect;

    public CoffeeMaker(ICoffeeSelect coffeeSelect)
    {
        this.coffeeSelect = coffeeSelect;
    }

    @Override
    public String MakingCoffee() throws ExecutionControl.NotImplementedException {
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

    private String brew()
    {
        return "Coffee has now been brewed";
    }
}

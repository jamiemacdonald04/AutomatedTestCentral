import Interfaces.ICoffeeSelect;
import jdk.jshell.spi.ExecutionControl;

public class WeakCoffee implements ICoffeeSelect {

    public WeakCoffee()
    {
    }

    public int GetBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }

    public boolean GrindBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }
}

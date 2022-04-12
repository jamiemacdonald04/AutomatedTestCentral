import Interfaces.ICoffeeSelect;
import jdk.jshell.spi.ExecutionControl;

public class DryBeansCoffee implements ICoffeeSelect {

    public DryBeansCoffee()
    {
    }

    public int GetBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }

    public boolean GrindBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }
}

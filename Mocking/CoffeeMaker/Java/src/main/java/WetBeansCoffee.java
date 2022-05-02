import Interfaces.ICoffeeSelect;
import jdk.jshell.spi.ExecutionControl;

import java.io.IOException;

public class WetBeansCoffee  implements ICoffeeSelect {

    public WetBeansCoffee()
    {
    }

    public int GetBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }

    public boolean GrindBeans() throws ExecutionControl.NotImplementedException {
        throw new ExecutionControl.NotImplementedException("Not implemented");
    }

    public boolean getStreamOfBeans(String beanName) throws RuntimeException {
        try {
            return getBeanService(beanName);
        } catch (Exception e) {
            if (!areBarredBeans(beanName)) {
                return localBeans(beanName);
            } else {
                throw e;
            }
        }
    }

    public boolean getBeanService(String beanName) {
        if(beanName.equals("flapper")){
            return true;
        }
        return false;
    }

    public boolean areBarredBeans(String beanName) {
        if(beanName.equals("flapper")){
            return true;
        }
        return false;
    }

    public boolean localBeans(String beanName) throws RuntimeException {
        if(beanName.equals("flapper")){
            return true;
        }
        throw new RuntimeException("stuff");
    }
}

package Interfaces;

import jdk.jshell.spi.ExecutionControl;

public interface ICoffeeSelect {
    boolean GrindBeans() throws ExecutionControl.NotImplementedException;
    int GetBeans() throws ExecutionControl.NotImplementedException;
}

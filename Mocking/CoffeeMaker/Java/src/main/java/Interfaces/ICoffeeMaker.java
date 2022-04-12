package Interfaces;

import jdk.jshell.spi.ExecutionControl;

public interface ICoffeeMaker {
    String MakingCoffee() throws ExecutionControl.NotImplementedException;
}

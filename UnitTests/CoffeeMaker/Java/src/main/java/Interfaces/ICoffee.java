package Interfaces;

import Models.CoffeeModel;

import java.io.IOException;
import java.util.List;

public interface ICoffee {

    public CoffeeModel assignCoffeeProperties(int sugarLumps, String label, Boolean withMilk, String origin);

    public int getBeans();

    public boolean grindBeans(String powerSource);

    public List<CoffeeModel> groupOrder();

    public String dry_beans();

    public boolean runGetCoffee()  throws IOException;
}

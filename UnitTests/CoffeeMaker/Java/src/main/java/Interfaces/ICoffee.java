package Interfaces;

import Models.CoffeeModel;

import java.util.ArrayList;
import java.util.List;

public interface ICoffee {

    public CoffeeModel AssignCoffeeProperties(int sugarLumps, String label, Boolean withMilk, String origin);

    public int GetBeans();

    public boolean GrindBeans(String powerSource);

    public List<CoffeeModel> GroupOrder();

    public String dry_beans();
}

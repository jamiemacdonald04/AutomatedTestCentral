package Models;

public class CoffeeModel {
    public String label;
    public int sugarLumps;
    public Boolean milk;
    public String beanOrigin;

    public String getLabel() {
        return label;
    }

    public void setLabel(String label) {
        this.label = label;
    }

    public int getSugarLumps() {
        return sugarLumps;
    }

    public void setSugarLumps(int sugarLumps) {
        this.sugarLumps = sugarLumps;
    }

    public Boolean getMilk() {
        return milk;
    }

    public void setMilk(Boolean milk) {
        this.milk = milk;
    }

    public String getBeanOrigin() {
        return beanOrigin;
    }

    public void setBeanOrigin(String beanOrigin) {
        this.beanOrigin = beanOrigin;
    }
}

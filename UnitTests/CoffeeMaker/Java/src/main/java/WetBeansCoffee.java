import Interfaces.ICoffee;
import Models.CoffeeModel;

import java.io.IOException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;


import java.net.URL;
import java.net.HttpURLConnection;

public class WetBeansCoffee  implements ICoffee {

    public CoffeeModel assignCoffeeProperties(int sugarLumps, String label, Boolean withMilk, String origin)
    {
        CoffeeModel coffee = new CoffeeModel();
        coffee.setLabel(label);
        coffee.setMilk(withMilk);
        coffee.setSugarLumps(sugarLumps);
        coffee.setBeanOrigin(origin);
        return coffee;
    }


    public int getBeans()
    {
        return 4;
    }

    public boolean grindBeans(String powerSource)
    {
        if(powerSource !=null && powerSource != "")
        {
            return true;
        }
        throw new NullPointerException("Parameter Type cannot be null");
    }

    public List<CoffeeModel> groupOrder()
    {
        List<CoffeeModel> coffeeList = new ArrayList<CoffeeModel>();
        coffeeList.add(assignCoffeeProperties(1, "Frapachino", true, "France"));
        coffeeList.add(assignCoffeeProperties(1, "Capachino", true, "Italy"));
        coffeeList.add(assignCoffeeProperties(1, "Latte", true, "Cambodia"));

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

    public boolean runGetCoffee() throws IOException {

        URL url = new URL("https://google.com/stuff");
        HttpURLConnection.setFollowRedirects(false);
        HttpURLConnection httpURLConnection = (HttpURLConnection) url.openConnection();
        httpURLConnection.setRequestMethod("HEAD");
        int responseCode = httpURLConnection.getResponseCode();
        return (responseCode == httpURLConnection.HTTP_OK);
    }
}

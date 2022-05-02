import Interfaces.*;
import static org.hamcrest.CoreMatchers.*;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.junit.jupiter.api.Assertions.*;
import Models.CoffeeModel;
import org.junit.jupiter.api.*;

import java.io.IOException;
import java.util.List;

public class CoffeeTests {

    private static ICoffee wetBeanCoffee;

    @BeforeAll
    public static void init() {
        wetBeanCoffee = new WetBeansCoffee();
    }

    @BeforeEach
    public void initBeforeEachTest() {
        System.out.println("Setting it up before every test.");
    }

    @AfterEach
    public void cleanupAfterEachTest()
    {
        System.out.println("Clean up after every test");
    }

    @AfterAll
    public static void cleanup()
    {
        wetBeanCoffee = null;
    }

    @Disabled("Do not run this test as we are not ready for it.")
    @Test
    public void testDryingBeansForConsistency() {

        String consistencyValue = wetBeanCoffee.dry_beans();
        String test = wetBeanCoffee.dry_beans();
        if (test != consistencyValue)
        {
            Assertions.fail("the value of dry beans is inconsistent");
        }
    }

    @RepeatedTest(11)
    @Test()
    public void testDryingBeansForConsistancyWithException() {

        String consistencyValue = wetBeanCoffee.dry_beans();
        String test = wetBeanCoffee.dry_beans();
        if (test != consistencyValue)
        {
            System.out.println("the value of dry beans is inconsistent");
        }
    }

    @Test
    @Order(1)
    public void testDryingBeansHasValue()
    {
        String consistencyValue = wetBeanCoffee.dry_beans();
        assertNotEquals(consistencyValue, "");
    }

    @Test
    @Order(2)
    public void testBeanVolume()
    {
        int beanVolume = wetBeanCoffee.getBeans();
        assertEquals(beanVolume, 4);
    }

    @Test
    public void testLabelsAreEqual() {
        CoffeeModel coffee = new CoffeeModel();
        coffee = wetBeanCoffee.assignCoffeeProperties(1, "Frapachino", true, "France");
        assertEquals(coffee.getLabel(), "Frapachino");
    }

    @Test
    public void testComparingObjects()
    {
        CoffeeModel coffeeOne;
        CoffeeModel coffeeTwo;

        coffeeOne = wetBeanCoffee.assignCoffeeProperties(1, "Frapachino", true, "France");
        coffeeTwo = wetBeanCoffee.assignCoffeeProperties(1, "Frapachino", true, "France");

        CoffeeModel coffeeThree = coffeeOne;

        //are the same as the point to the same object
        assertSame(coffeeOne,coffeeThree);
        assertEquals(coffeeOne,coffeeThree);

        // are not the same although same type and same values
        assertNotSame(coffeeOne, coffeeTwo);
        assertNotEquals(coffeeOne, coffeeTwo);

        // watch this gotcha.  This should return false as they are not the same item, they do have the same value and will fail if they have different values.
        assertSame(coffeeOne.getLabel(), coffeeTwo.getLabel());
        // should use below for consistency
        assertEquals(coffeeOne.getLabel(), coffeeTwo.getLabel());
    }

    @Test
    public void testCoffeeGroup()
    {
        CoffeeModel coffeeOne;
        coffeeOne = wetBeanCoffee.assignCoffeeProperties(1, "Frapachino", true, "France");
        List<CoffeeModel> OrderredByGroup = wetBeanCoffee.groupOrder();

        assertThat(OrderredByGroup, not(hasItem(coffeeOne)));
        assertThat(OrderredByGroup, not(nullValue()));
    }

    @Test
    public void testWeakCoffeeGrindBeansTestWithInvalidArgument()
    {
        assertThrows(NullPointerException.class, () -> {wetBeanCoffee.grindBeans(null);});
    }

    @Test
    public void getGranniesSecretReceipt() throws IOException {
        assertFalse(wetBeanCoffee.runGetCoffee());
    }

}

import Interfaces.*;
import static org.hamcrest.CoreMatchers.*;
import static org.hamcrest.MatcherAssert.assertThat;
import static org.junit.jupiter.api.Assertions.*;
import Models.CoffeeModel;
import org.junit.jupiter.api.*;

import java.util.List;

public class CoffeeTests {

    private static ICoffee wetBeanCoffee;

    @BeforeAll
    public static void Init() {
        wetBeanCoffee = new WetBeansCoffee();
    }

    @BeforeEach
    public void InitBeforeEachTest() {
        System.out.println("Setting it up before every test.");
    }

    @AfterEach
    public void CleanupAfterEachTest()
    {
        System.out.println("Clean up after every test");
    }

    @AfterAll
    public static void Cleanup()
    {
        wetBeanCoffee = null;
    }

    @Disabled("Do not run this test as we are not ready for it.")
    @Test
    public void DryingBeansForConsistency() {

        String consistencyValue = wetBeanCoffee.dry_beans();
        String test = wetBeanCoffee.dry_beans();
        if (test != consistencyValue)
        {
            Assertions.fail("the value of dry beans is inconsistent");
        }
    }

    @RepeatedTest(11)
    @Test()
    public void DryingBeansForConsistancyWithException() {

        String consistencyValue = wetBeanCoffee.dry_beans();
        String test = wetBeanCoffee.dry_beans();
        if (test != consistencyValue)
        {
            Assertions.fail("the value of dry beans is inconsistent");
        }
    }

    @Test
    @Order(1)
    public void TestDryingBeansHasValue()
    {
        String consistencyValue = wetBeanCoffee.dry_beans();
        assertNotEquals(consistencyValue, "");
    }

    @Test
    @Order(2)
    public void TestBeanVolume()
    {
        int beanVolume = wetBeanCoffee.GetBeans();
        assertEquals(beanVolume, 4);
    }

    @Test
    public void TestLabelsAreEqual() {
        CoffeeModel coffee = new CoffeeModel();
        coffee = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");
        assertEquals(coffee.getLabel(), "Frapachino");
    }

    @Test
    public void TestIfTwoCoffeeObjectsAreTheSame()
    {

        CoffeeModel coffeeOne = new CoffeeModel();
        CoffeeModel coffeeTwo = new CoffeeModel();
        coffeeOne = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");
        coffeeTwo = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");

        assertNotSame(coffeeOne, coffeeTwo);

        // watch this gotcha.
        assertSame(coffeeOne.getLabel(), coffeeTwo.getLabel());

    }

    @Test
    public void TestCoffeeGroup()
    {
        CoffeeModel coffeeOne;
        coffeeOne = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");
        List<CoffeeModel> OrderredByGroup = wetBeanCoffee.GroupOrder();

        assertThat(OrderredByGroup, not(hasItem(coffeeOne)));
        assertThat(OrderredByGroup, not(nullValue()));
    }

    @Test
    public void WeakCoffeeGrindBeansTestWithInvalidArgument()
    {
        assertThrows(NullPointerException.class, () -> {wetBeanCoffee.GrindBeans(null);});
    }
}

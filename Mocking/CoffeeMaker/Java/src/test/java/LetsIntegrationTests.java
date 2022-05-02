import Interfaces.*;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;
import org.junit.jupiter.api.Test;
import jdk.jshell.spi.ExecutionControl;


public class LetsIntegrationTests {

    @Test
    public void TestNoBeanCoffee() throws ExecutionControl.NotImplementedException {
        ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
        when(coffeeMakerMock.GetBeans()).thenReturn(0);
        when(coffeeMakerMock.GrindBeans()).thenReturn(true);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);
        String coffee = coffeemaker.MakingCoffee();
        assertEquals(coffee, "No coffee available");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(0)).GrindBeans();
    }

    @Test
    public void TestGrindFailure() throws ExecutionControl.NotImplementedException {
        ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
        when(coffeeMakerMock.GetBeans()).thenReturn(1);
        when(coffeeMakerMock.GrindBeans()).thenReturn(false);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);
        String coffee = coffeemaker.MakingCoffee();
        assertEquals(coffee, "No ground coffee available");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(1)).GrindBeans();
    }

    @Test
    public void TestTheSweetSweetTasteOfCoffee() throws ExecutionControl.NotImplementedException {
         ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
         when(coffeeMakerMock.GetBeans()).thenReturn(1);
         when(coffeeMakerMock.GrindBeans()).thenReturn(true);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);
        String coffee = coffeemaker.MakingCoffee();
        assertEquals(coffee, "Coffee has now been brewed");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(1)).GrindBeans();
    }
}

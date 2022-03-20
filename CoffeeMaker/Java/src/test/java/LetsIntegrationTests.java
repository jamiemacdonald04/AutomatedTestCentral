import Interfaces.*;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;

import jdk.jshell.spi.ExecutionControl;
import org.junit.jupiter.api.Test;

public class LetsIntegrationTests {

    @Test
    public void TestNoBeanCoffee() throws ExecutionControl.NotImplementedException {
        ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
        when(coffeeMakerMock.GetBeans()).thenReturn(0);
        when(coffeeMakerMock.GrindBeans()).thenReturn(true);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);

        assertEquals(coffeemaker.MakingCoffee(), "No coffee available");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(0)).GrindBeans();
    }

    @Test
    public void TestGrindFailure() throws ExecutionControl.NotImplementedException {
        ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
        when(coffeeMakerMock.GetBeans()).thenReturn(1);
        when(coffeeMakerMock.GrindBeans()).thenReturn(false);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);

        assertEquals(coffeemaker.MakingCoffee(), "No ground coffee available");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(1)).GrindBeans();
    }

    @Test
    public void TestTheSweetSweetTasteOfCoffee() throws ExecutionControl.NotImplementedException {
         ICoffeeSelect coffeeMakerMock = mock(ICoffeeSelect.class);
         when(coffeeMakerMock.GetBeans()).thenReturn(1);
         when(coffeeMakerMock.GrindBeans()).thenReturn(true);

        ICoffeeMaker coffeemaker = new CoffeeMaker(coffeeMakerMock);

        assertEquals(coffeemaker.MakingCoffee(), "Coffee has now been brewed");
        verify(coffeeMakerMock, times(1)).GetBeans();
        verify(coffeeMakerMock, times(1)).GrindBeans();
    }
}

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.*;


import jdk.jshell.spi.ExecutionControl;
import org.junit.jupiter.api.Test;

public class AdvanceIntegrationTests {
    @Test
    public void TestNoBeanCoffee()  {
        WetBeansCoffee wetBeansCoffee = mock(WetBeansCoffee.class);
        when(wetBeansCoffee.getBeanService("flapper")).thenThrow(new RuntimeException("stuff"));
        //doThrow(new RuntimeException("stuff")).when(wetBeansCoffee).getBeanService("flapper");

        try {
            assertThrows()
          var jamie =  wetBeansCoffee.getStreamOfBeans("flapper");
          System.out.println(jamie);
        }
        catch (RuntimeException e){
            verify(wetBeansCoffee, times(1)).areBarredBeans("flapper");
        }

    }
}

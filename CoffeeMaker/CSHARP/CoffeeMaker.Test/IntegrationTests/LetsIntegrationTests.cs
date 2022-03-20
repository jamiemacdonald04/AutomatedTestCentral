using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
namespace CoffeeMaker.IntegrationTests
{
    [TestClass]
    public class LetsIntegrationTests
    {
        public LetsIntegrationTests()
        {
        }
        [TestMethod]
        public void TestNoBeanCoffee()
        {
            // Arange
            Mock<ICoffeeSelect> CoffeeMock = new Mock<ICoffeeSelect>();
            CoffeeMock.Setup(test => test.GrindBeans()).Returns(true);
            CoffeeMock.Setup(test => test.GetBeans()).Returns(0);

            //make the coffee, notice no mock here.
            ICoffeeMaker coffeeMaker =
                                    new CoffeeMaker(CoffeeMock.Object);
            //Act
            string coffee = coffeeMaker.MakingCoffee();

            //Assert

            //verify 
            CoffeeMock.Verify(mock => mock.GrindBeans(),  Times.Never());
            CoffeeMock.Verify(mock => mock.GetBeans(), Times.Once());
            Assert.AreEqual(coffee, "No coffee available", "Failed because there are no beans");
        }

        [TestMethod]
        public void TestGrindFailure()
        {
            // Arange
            Mock<ICoffeeSelect> CoffeeMock = new Mock<ICoffeeSelect>();
            CoffeeMock.Setup(test => test.GrindBeans()).Returns(false);
            CoffeeMock.Setup(test => test.GetBeans()).Returns(1);

            //make the coffee, notice no mock here.
            ICoffeeMaker coffeeMaker =
                                    new CoffeeMaker(CoffeeMock.Object);
            //Act
            string coffee = coffeeMaker.MakingCoffee();

            //Assert
            CoffeeMock.Verify(mock => mock.GrindBeans(), Times.Once());
            CoffeeMock.Verify(mock => mock.GetBeans(), Times.Once());
            Assert.AreEqual(coffee, "No ground coffee available", "Grinder broke so no grinds");
        }

        [TestMethod]
        public void TestTheSweetSweetTasteOfCoffee()
        {
            // Arange
            Mock<ICoffeeSelect> CoffeeMock = new Mock<ICoffeeSelect>();
            CoffeeMock.Setup(test => test.GrindBeans()).Returns(true);
            CoffeeMock.Setup(test => test.GetBeans()).Returns(1);

            //make the coffee, notice no mock here.
            ICoffeeMaker coffeeMaker =
                                    new CoffeeMaker(CoffeeMock.Object);

            //Act
            string coffee = coffeeMaker.MakingCoffee();

            //Assert
            CoffeeMock.Verify(mock => mock.GrindBeans(), Times.Once());
            CoffeeMock.Verify(mock => mock.GetBeans(), Times.Once());
            Assert.AreEqual(coffee, "Coffee has now been brewed", "Yum we have coffee");
        }
    }
}

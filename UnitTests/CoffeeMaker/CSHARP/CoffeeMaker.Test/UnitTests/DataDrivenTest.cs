using System;
using System.Reflection;
using CoffeeMaker.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMaker.Test.UnitTests
{
    public class DataDrivenTest
    {
        private ICoffee wetBeanCoffee;

        [TestInitialize]
        public void Init()
        {

            wetBeanCoffee = new WetBeansCoffee();
        }

        [TestCleanup]
        public void Cleanup()
        {
            wetBeanCoffee = null;
        }

        [TestMethod()]
        [TestProperty("powerSource", "Wind")]
        [TestProperty("powerSource", "coal")]
        public void WeakCoffeeGrindBeansTestWithProperties()
        {
            //act
            string firstProperty = getTestProperties(0, "WeakCoffeeGrindBeansTestWithProperties");
            string secndProperty = getTestProperties(1, "WeakCoffeeGrindBeansTestWithProperties");

            bool FirstWeakCoffee = wetBeanCoffee.GrindBeans(firstProperty);
            bool SecondweakCoffee = wetBeanCoffee.GrindBeans(secndProperty);
            Assert.IsFalse(SecondweakCoffee);
            Assert.IsTrue(FirstWeakCoffee);

        }


        private string getTestProperties(int index, string methodName)
        {
            // Get the current type
            Type t = GetType();
            //CollectionAssert.AllItemsAreUnique
            MethodInfo mi = t.GetMethod(methodName);
            Type MyType = typeof(TestPropertyAttribute);
            object[] attributes = mi.GetCustomAttributes(MyType, false);
            return ((TestPropertyAttribute)attributes[index]).Value;
        }
    }
}

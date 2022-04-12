using System;
using System.Collections.Generic;
using System.Reflection;
using CoffeeMaker.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using CollectionAssert = Microsoft.VisualStudio.TestTools.UnitTesting.CollectionAssert;
using IgnoreAttribute = Microsoft.VisualStudio.TestTools.UnitTesting.IgnoreAttribute;

namespace CoffeeMaker.Test.IntegrationTests
{
    [TestClass]
    public class CoffeeSelectTests
    {

        private ICoffee wetBeanCoffee;

        [TestInitialize]
        public void Init() {

            wetBeanCoffee = new WetBeansCoffee();
        }

        [TestCleanup]
        public void Cleanup()
        {
            wetBeanCoffee = null;
        }

       [Ignore("Do not run this test as we are not ready for it.")]
       [TestMethod]
        public void DryingBeansForConsistency()
        {

            string consistencyValue = wetBeanCoffee.dry_beans();

            for (int i = 0; i < 5; i++)
            {
                string test = wetBeanCoffee.dry_beans();

                if (test != consistencyValue)
                {
                    Assert.Inconclusive("the value of dry beans is inconsistent");
                }
            }
        }

        [Repeat(11)]
        [TestMethod]
        public void DryingBeansForConsistancyWithException()
        {

            string consistencyValue = wetBeanCoffee.dry_beans();
            string test = wetBeanCoffee.dry_beans();

            if (test != consistencyValue)
            {
                Assert.Inconclusive("the value of dry beans is inconsistent");
            }
            
        }

        [Order(1)]
        [TestMethod]
        public void TestDryingBeansHasValue()
        {
            //value is different everytime
            string consistencyValue = wetBeanCoffee.dry_beans();
            Assert.IsFalse(string.IsNullOrEmpty(consistencyValue));
        }

        [Order(2)]
        [TestMethod]
        public void TestBeanVolume()
        {
            int beanVolume = wetBeanCoffee.GetBeans();
            Assert.AreEqual(beanVolume, 4); 
        }

        [TestMethod]
        public void TestLabelsAreEqual()
        {
            CoffeeModel coffee = new CoffeeModel();
            coffee = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");

            Assert.AreEqual<string>(coffee.Label, "Frapachino");
        }

        [TestMethod]
        public void TestIfTwoCoffeeObjectsAreTheSame()
        {

            CoffeeModel coffeeOne = new CoffeeModel();
            CoffeeModel coffeeTwo = new CoffeeModel();
            coffeeOne = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");
            coffeeTwo = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");

            Assert.AreNotSame(coffeeOne, coffeeTwo);
            // watch this gotcha.
            Assert.AreSame(coffeeOne.Label, coffeeTwo.Label);

        }

        [TestMethod]
        public void TestCoffeeGroup()
        {
            CoffeeModel coffeeOne = new CoffeeModel();
            coffeeOne = wetBeanCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France");
            List<CoffeeModel> OrderredByGroup = wetBeanCoffee.GroupOrder();

            CollectionAssert.AllItemsAreUnique(OrderredByGroup);

            //note it is the same type with same values but it is a different object
            CollectionAssert.DoesNotContain(OrderredByGroup, coffeeOne);
            CollectionAssert.AllItemsAreNotNull(OrderredByGroup);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException), "To throw an exception when argument is null.")]
        public void WeakCoffeeGrindBeansTestWithInvalidArgument()
        {
            wetBeanCoffee.GrindBeans(null);
        }
    }
}

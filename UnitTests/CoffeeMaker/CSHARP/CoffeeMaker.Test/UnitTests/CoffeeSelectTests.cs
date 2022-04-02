using System;
using System.Collections.Generic;
using System.Reflection;
using CoffeeMaker.interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CoffeeMaker.Test.IntegrationTests
{
    [TestClass]
    public class CoffeeSelectTests
    {

        /*
         
         public CoffeeModel AssignCoffeeProperties(int sugarLumps, string label, bool withMilk, string origin = null);

        public int GetBeans();


        public bool GrindBeans(string powerSource);


        public List<CoffeeModel> GroupOrder();


        public string dry_beans();
         
         
         */

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

        [TestMethod]
        public void TestDryingBeansForConsistancy() {

            string consistancyValue = wetBeanCoffee.dry_beans();
            Console.WriteLine(consistancyValue);

            for (int i = 0; i < 5; i++)
            {
                string test = wetBeanCoffee.dry_beans();

                if (test != consistancyValue)
                {
                    Assert.Inconclusive("the value of dry beans is inconsistant");
                }
                Console.WriteLine(test);
            }
        }

        [TestMethod]
        public void TestDryingBeansHasValue()
        {
            //value is different everytime
            string consistancyValue = wetBeanCoffee.dry_beans();
            Assert.IsFalse(string.IsNullOrEmpty(consistancyValue));
        }

        [TestMethod]
        public void TestBeanVolume()
        {
            int beanVolume = wetBeanCoffee.GetBeans();
            Assert.AreEqual(beanVolume, 4); 
        }

        [TestMethod]
        public void TestGetBeansForError()
        {
            try
            {
                int beanVolume = wetBeanCoffee.GetBeans();
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestAssigningProperties() {

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
            CollectionAssert.DoesNotContain(OrderredByGroup,coffeeOne);
            CollectionAssert.AllItemsAreNotNull(OrderredByGroup);
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

        [TestMethod()]
        public void WeakCoffeeGrindBeansTestWithInvalidArgument()
        {
            Assert.IsFalse(wetBeanCoffee.GrindBeans(null));
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

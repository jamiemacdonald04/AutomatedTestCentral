package CoffeeMaker

import (
	"github.com/stretchr/testify/assert"
	"log"
	"testing"
)

var wetBeansCoffee = WetBeansCoffee{}

func TestMain(m *testing.M) {
	setup()
	m.Run()
	teardown()
}

func setup() {
	log.Println("\n-----runs before all tests-----")
}

func teardown() {
	log.Println("\n----runs after all tests----")
}
func TestBeanCount(t *testing.T) {
	var beanCount int = wetBeansCoffee.GetBeans()
	assert.Equal(t, beanCount, 4)
}

// to test this multiple time to get a failure we will need to run it as a script
//go test -run TestDryingBeansForConsistency -count 10 -v
// to skip this test run the test call with short arg
//go test -short -v
func TestDryingBeansForConsistency(t *testing.T) {
	if testing.Short() {
		t.Skip("skipping test")
	}
	consistencyValue := wetBeansCoffee.DryBeans()
	test := wetBeansCoffee.DryBeans()
	if test != consistencyValue {
		assert.Fail(t, "the value of dry beans is inconsistent")
		assert.FailNow(t, "the value of dry beans is inconsistent")
	}

}

func TestLabelsAreCorrect(t *testing.T) {
	coffee := NewCoffeeModel("Frapachino", 1, true, "France")
	assert.Equal(t, coffee.label, "Frapachino")
	assert.Equal(t, coffee.milk, true)
	assert.Equal(t, coffee.beanOrigin, "France")
	assert.NotEqual(t, coffee.sugarLumps, 2)
}

func TestCompareObjects(t *testing.T) {
	coffeeOne := NewCoffeeModel("Frapachino", 1, true, "France")
	coffeeTwo := NewCoffeeModel("Frapachino", 1, true, "France")
	coffeeThree := &coffeeOne
	coffeeFour := &coffeeOne

	// are pointing to the same object
	assert.Same(t, coffeeThree, coffeeFour)

	// are not pointing to the same object although are the same type and content
	assert.NotSame(t, coffeeOne, coffeeTwo)
	assert.NotSame(t, coffeeOne.label, coffeeTwo.label)

	// asserts that two objects are equal or convertable to the same types and equal.
	assert.EqualValues(t, coffeeOne.label, coffeeTwo.label)
	assert.EqualValues(t, coffeeOne, coffeeTwo)

	// Exactly asserts that two objects are equal in value and type.
	assert.Exactly(t, coffeeThree, coffeeFour)
}

func TestCoffeeGroup(t *testing.T) {
	var subOrder []CoffeeModel
	var newOrder []CoffeeModel

	subOrder = append(subOrder, wetBeansCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France"))
	subOrder = append(subOrder, wetBeansCoffee.AssignCoffeeProperties(1, "Coffee", false, "France"))
	coffeeOne := NewCoffeeModel("Frapachino", 1, true, "France")
	hotChocolate := NewCoffeeModel("hot chocolate with marshmallows", 1, true, "France")
	orderedByGroup := wetBeansCoffee.GroupOrder()

	// list contains
	assert.Contains(t, orderedByGroup, coffeeOne)
	// list does not contain
	assert.NotContains(t, orderedByGroup, hotChocolate)
	// list is not empty
	assert.NotEmpty(t, orderedByGroup)
	// list is empty
	assert.Empty(t, newOrder)
	// subset is part of list
	assert.Subset(t, orderedByGroup, subOrder)
}

func TestErrorAssumptions(t *testing.T) {
	_, err := wetBeansCoffee.GrindBeans("")
	assert.Error(t, err)
	assert.ErrorContains(t, err, "cannot have an empty power source")
}

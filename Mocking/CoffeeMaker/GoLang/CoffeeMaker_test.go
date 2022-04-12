package CoffeeMaker

import (
	"testing"

	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/mock"
)

//create your mock object
type MakeCoffeeMock struct {
	mock.Mock
}

// create your test methods
func TestNoBeanCoffee(t *testing.T) {
	makeCoffeeMock := new(MakeCoffeeMock)
	makeCoffeeMock.On("GetBeans").Return(0)
	makeCoffeeMock.On("GrindBeans").Return(true)
	makeCoffee := CoffeeMaker{coffeeSelect: makeCoffeeMock}
	coffee := makeCoffee.MakingCoffee()
	assert.Equal(t, coffee, "No coffee available", "Failed because there are no beans")
	makeCoffeeMock.AssertNotCalled(t, "GrindBeans")
}
func TestGrindFailure(t *testing.T) {
	makeCoffeeMock := new(MakeCoffeeMock)
	makeCoffeeMock.On("GetBeans").Return(1)
	makeCoffeeMock.On("GrindBeans").Return(false)
	makeCoffee := CoffeeMaker{coffeeSelect: makeCoffeeMock}
	coffee := makeCoffee.MakingCoffee()
	assert.Equal(t, coffee, "No ground coffee available", "Grinder broke so no grinds")
}
func TestTheSweetSweetTasteOfCoffee(t *testing.T) {
	makeCoffeeMock := new(MakeCoffeeMock)
	makeCoffeeMock.On("GetBeans").Return(1)
	makeCoffeeMock.On("GrindBeans").Return(true)
	makeCoffee := CoffeeMaker{coffeeSelect: makeCoffeeMock}
	coffee := makeCoffee.MakingCoffee()
	assert.Equal(t, coffee, "Coffee has now been brewed", "Yum we have coffee")
}

//Create your test stubs
func (a *MakeCoffeeMock) GetBeans() int {
	args := a.Called()
	return args.Get(0).(int)
}
func (a *MakeCoffeeMock) GrindBeans() bool {
	args := a.Called()
	return args.Get(0).(bool)
}

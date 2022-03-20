package CoffeeMaker

import (
	"github.com/stretchr/testify/assert"
	"github.com/stretchr/testify/mock"
	"testing"
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
	makeCoffee.MakingCoffee()
	assert.Equal(t, makeCoffee.MakingCoffee(), "No coffee available", "Failed because there are no beans")
	makeCoffeeMock.AssertNotCalled(t, "GrindBeans")
}
func TestGrindFailure(t *testing.T) {
	makeCoffeeMock := new(MakeCoffeeMock)
	makeCoffeeMock.On("GetBeans").Return(1)
	makeCoffeeMock.On("GrindBeans").Return(false)
	makeCoffee := CoffeeMaker{coffeeSelect: makeCoffeeMock}
	assert.Equal(t, makeCoffee.MakingCoffee(), "No ground coffee available", "Grinder broke so no grinds")
}
func TestTheSweetSweetTasteOfCoffee(t *testing.T) {
	makeCoffeeMock := new(MakeCoffeeMock)
	makeCoffeeMock.On("GetBeans").Return(1)
	makeCoffeeMock.On("GrindBeans").Return(true)
	makeCoffee := CoffeeMaker{coffeeSelect: makeCoffeeMock}
	assert.Equal(t, makeCoffee.MakingCoffee(), "Coffee has now been brewed", "Yum we have coffee")
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

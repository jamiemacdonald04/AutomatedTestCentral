package CoffeeMaker

type CoffeeMaker struct {
	coffeeSelect ICoffeeSelect
}

func (coffeeMaker *CoffeeMaker) MakingCoffee() string {
	if coffeeMaker.coffeeSelect.GetBeans() <= 0 {
		return "No coffee available"
	}
	if !coffeeMaker.coffeeSelect.GrindBeans() {
		return "No ground coffee available"
	}
	return brew()
}

func brew() string {
	return "Coffee has now been brewed"
}

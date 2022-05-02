package CoffeeMaker

type CoffeeModel struct {
	label      string
	sugarLumps int
	milk       bool
	beanOrigin string
}

func NewCoffeeModel(label string, sugarLumps int, milk bool, beanOrigin string) CoffeeModel {
	return CoffeeModel{label: label, sugarLumps: sugarLumps, milk: milk, beanOrigin: beanOrigin}
}

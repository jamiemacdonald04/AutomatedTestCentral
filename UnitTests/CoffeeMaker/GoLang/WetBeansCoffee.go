package CoffeeMaker

import (
	"errors"
	chain "github.com/g8rswimmer/error-chain"
	"math/rand"
	"time"
)

type WetBeansCoffee struct {
}

func (wetBeansCoffee *WetBeansCoffee) AssignCoffeeProperties(sugarLumps int, label string, withMilk bool, origin string) CoffeeModel {
	coffee := NewCoffeeModel(label, sugarLumps, withMilk, origin)
	return coffee
}

func (wetBeansCoffee *WetBeansCoffee) GetBeans() int {
	return 4
}

func (wetBeansCoffee *WetBeansCoffee) GrindBeans(powerSource string) (bool, error) {
	if powerSource != "" {
		return true, nil
	}
	errorChain := chain.New()
	errorChain.Add(errors.New("cannot have an empty power source"))
	errorChain.Add(errors.New("the string was empty"))
	return false, errorChain
}

func (wetBeansCoffee *WetBeansCoffee) GroupOrder() []CoffeeModel {
	var coffeeList []CoffeeModel

	coffeeList = append(coffeeList, wetBeansCoffee.AssignCoffeeProperties(1, "Frapachino", true, "France"))
	coffeeList = append(coffeeList, wetBeansCoffee.AssignCoffeeProperties(1, "Coffee", false, "France"))
	coffeeList = append(coffeeList, wetBeansCoffee.AssignCoffeeProperties(1, "Capachino", true, "Italy"))
	coffeeList = append(coffeeList, wetBeansCoffee.AssignCoffeeProperties(1, "Latte", true, "Cambodia"))

	return coffeeList
}

func (wetBeansCoffee *WetBeansCoffee) DryBeans() string {
	rand.Seed(time.Now().UnixNano())
	min := 10
	randomNumber := rand.Intn(30-min+1) + min
	if randomNumber%2 == 0 {
		return "beans are dry"
	}
	return "beans are not dry"
}

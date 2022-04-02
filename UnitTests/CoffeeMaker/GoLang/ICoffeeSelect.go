package CoffeeMaker

/*
<summary>
This is our contract for our coffee select method and will be what we use to mock.
</summary>
*/
type ICoffeeSelect interface {
	GrindBeans() bool
	GetBeans() int
}

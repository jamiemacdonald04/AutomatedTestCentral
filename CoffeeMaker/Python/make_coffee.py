from weak_coffee import *
from wet_beans_coffee import *
from dry_beans_coffee import *
from coffee_maker import *


class MakingCoffee:
    def make_a_coffee(self):
        make_weak_coffee = CoffeeMaker(WeaKCoffee())
        make_wet_coffee = CoffeeMaker(DryBeansCoffee())
        make_dry_coffee = CoffeeMaker(WetBeansCoffee())

        print(make_weak_coffee.making_coffee())
        print(make_wet_coffee.making_coffee())
        print(make_dry_coffee.making_coffee())


if __name__ == '__main__':
    make_coffee = MakingCoffee()
    make_coffee.make_a_coffee()

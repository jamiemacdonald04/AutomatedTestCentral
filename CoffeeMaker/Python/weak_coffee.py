from abstract_coffee_select import *


class WeaKCoffee(AbstractCoffeeSelect):
    def get_beans(self) -> int:
        return 1

    def grind_beans(self) -> bool:
        return True

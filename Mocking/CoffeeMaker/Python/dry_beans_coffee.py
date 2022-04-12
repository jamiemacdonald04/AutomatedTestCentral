from abstract_coffee_select import *


class DryBeansCoffee(AbstractCoffeeSelect):
    def get_beans(self) -> int:
        return 3

    def grind_beans(self) -> bool:
        return True

import string

from abstract_coffee_select import *


class WetBeansCoffee(AbstractCoffeeSelect):
    def get_beans(self) -> int:
        return 4

    def grind_beans(self) -> bool:
        if self.__dry_beans() == "beans are dry":
            return True
        return False

    def __dry_beans(self) -> string:
        return "beans are dry"

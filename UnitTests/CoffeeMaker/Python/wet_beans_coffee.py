import random
import string
from coffee_model import CoffeeModel


class WetBeansCoffee:
    def assign_coffee_properties(self, sugar_lumps: int, label: string, with_milk: bool,
                                 origin: string) -> CoffeeModel:
        coffee = CoffeeModel(sugar_lumps, label, with_milk, origin)
        return coffee

    def get_beans(self) -> int:
        return 4

    def grind_beans(self, power_source: string):

        if power_source is not None and power_source != "":
            return True

        raise Exception('This is the exception you expect to handle')

    def group_order(self) -> []:
        coffees = [self.assign_coffee_properties(1, "Frapachino", True, "France"),
                   self.assign_coffee_properties(1, "Capachino", True, "Italy"),
                   self.assign_coffee_properties(1, "Latte", True, "Cambodia")]

        return coffees

    def dry_beans(self) -> string:
        randomNumber = random.randrange(1, 10)
        if randomNumber % 2 == 0:
            return "beans are dry"
        return "beans are not dry"

    def get_beans(self) -> int:
        return 4

    def __dry_beans(self) -> string:
        return "beans are dry"

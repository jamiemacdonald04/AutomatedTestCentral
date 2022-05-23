import random
import string
from coffee_model import CoffeeModel


class WetBeansCoffee:

    def proccess_loyalty_card(self, loyalty_data) -> bool:
        if string.contains(loyalty_data.balance): return False

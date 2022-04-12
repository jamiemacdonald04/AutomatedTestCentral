import string


class CoffeeMaker:
    coffeeSelect = None

    def __init__(self, coffee_select):
        self.CoffeeSelect = coffee_select

    def making_coffee(self) -> string:
        beans = self.CoffeeSelect.get_beans()
        if beans <= 0:
            return "No coffee available"
        if not self.CoffeeSelect.grind_beans():
            return "No ground coffee available";
        return self._brew(beans)

    def _brew(self, beans) -> string:
        brew = "Coffee has now been brewed with {} beans"
        return brew.format(beans);

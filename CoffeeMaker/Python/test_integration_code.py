import unittest
from unittest.mock import MagicMock
from coffee_maker import *
from dry_beans_coffee import *


class TestCofeeSelect(unittest.TestCase):

    def test_coffee_no_beans(self):
        coffee_select_Mock = MagicMock(AbstractCoffeeSelect)
        coffee_select_Mock.get_beans.return_value = 0
        coffee_select_Mock.grind_beans.return_value = False

        maker = CoffeeMaker(coffee_select_Mock)

        assert maker.making_coffee() == "No coffee available"

        # called with zero arguments
        coffee_select_Mock.get_beans.assert_called_with()
        # was called once with zero arguments
        coffee_select_Mock.get_beans.assert_called_once_with()
        # was it called at least once
        coffee_select_Mock.get_beans.assert_called()
        # was called once only
        coffee_select_Mock.get_beans.assert_called_once()

    def test_grind_failure(self):
        coffee_select_Mock = MagicMock(AbstractCoffeeSelect)
        coffee_select_Mock.get_beans.return_value = 1
        coffee_select_Mock.grind_beans.return_value = False

        maker = CoffeeMaker(coffee_select_Mock)

        assert maker.making_coffee() == "No ground coffee available"

        # called with zero arguments
        coffee_select_Mock.get_beans.assert_called_with()
        # was called once with zero arguments
        coffee_select_Mock.get_beans.assert_called_once_with()
        # was it called at least once
        coffee_select_Mock.get_beans.assert_called()
        # was called once only
        coffee_select_Mock.get_beans.assert_called_once()

        coffee_select_Mock.grind_beans.assert_called_once()

    def test_the_sweat_taste_of_coffee(self):
        beans = 4
        coffee_select_Mock = MagicMock(AbstractCoffeeSelect)
        coffee_select_Mock.get_beans.return_value = beans
        coffee_select_Mock.grind_beans.return_value = True

        maker = CoffeeMaker(coffee_select_Mock)

        assert maker.making_coffee() == "Coffee has now been brewed with {} beans".format(beans)

        # called with zero arguments
        coffee_select_Mock.get_beans.assert_called_with()
        # was called once with zero arguments
        coffee_select_Mock.get_beans.assert_called_once_with()
        # was it called at least once
        coffee_select_Mock.get_beans.assert_called()
        # was called once only
        coffee_select_Mock.get_beans.assert_called_once()

        coffee_select_Mock.grind_beans.assert_called_once()


if __name__ == '__main__':
    unittest.main()

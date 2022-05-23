import unittest
from wet_beans_coffee import *


def repeat(times):
    def repeat_helper(f):
        def call_helper(*args):
            for i in range(0, times):
                f(*args)

        return call_helper

    return repeat_helper


class TestCoffee(unittest.TestCase):

    @classmethod
    def setUpClass(cls):
        cls._wet_coffee = WetBeansCoffee()

    @classmethod
    def tearDownClass(cls) -> None:
        cls._wet_coffee = None

    def setUp(self) -> None:
        print("runs before every test")

    def tearDown(self) -> None:
        print("runs after every test")

    @unittest.skip('Do not run this test as we are not ready for it.')
    def test_drying_beans_for_consistency(self):
        consistency_value = self.__class__._wet_coffee.dry_beans()
        test = self.__class__._wet_coffee.dry_beans()
        if test != consistency_value:
            raise AssertionError

    @repeat(11)
    def test_drying_beans_for_consistency_with_exception(self):
        consistency_value = self.__class__._wet_coffee.dry_beans()
        test = self.__class__._wet_coffee.dry_beans()
        if test != consistency_value:
            print("not consistent.")
        else:
            print("consistent.")

    def test_a_drying_beans_has_value(self):
        consistency_value = self.__class__._wet_coffee.dry_beans()
        self.assertNotEquals(consistency_value, "")

    def test_b_bean_volume(self):
        bean_volume = self.__class__._wet_coffee.get_beans()
        self.assertEquals(bean_volume, 4)

    def test_labels_are_equal(self):

        coffee_one = self.__class__._wet_coffee.assign_coffee_properties(1, "Frapachino", True, "France")
        self.assertEquals(coffee_one.label, "Frapachino");

    def test_if_two_coffee_objects_are_the_same(self):

        coffee_one = self.__class__._wet_coffee.assign_coffee_properties(1, "Frapachino", True, "France")
        coffee_two = self.__class__._wet_coffee.assign_coffee_properties(1, "Frapachino", True, "France")
        coffee_three = coffee_one
        self.assertIsNot(coffee_one, coffee_two)
        self.assertIs(coffee_one, coffee_three)
        self.assertIsInstance(coffee_one, CoffeeModel)

        # watch out for this as they are both string but not the same object.  Looks only to assess the contents
        self.assertIs(coffee_one.label, coffee_two.label);

    def test_coffee_group(self):

        coffee_one = self.__class__._wet_coffee.assign_coffee_properties(1, "Frapachino", True, "France")
        # same but not the same object
        same_content_but_not_coffee_one = self.__class__._wet_coffee.assign_coffee_properties(1, "Frapachino", True, "France")
        OrderedByGroup = self.__class__._wet_coffee.group_order()
        OrderedByGroup.append(coffee_one)
    
        self.assertIn(coffee_one, OrderedByGroup)
        self.assertNotIn(same_content_but_not_coffee_one, OrderedByGroup)

    def test_weak_coffee_grind_beans_with_invalid_argument(self):
        with self.assertRaises(Exception):
            power_source = ""
            self.__class__._coffee_model.grind_beans(power_source)


if __name__ == '__main__':
    unittest.main()

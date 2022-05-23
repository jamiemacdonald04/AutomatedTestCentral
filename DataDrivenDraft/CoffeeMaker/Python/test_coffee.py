import unittest
from wet_beans_coffee import *
import json


class TestCoffee(unittest.TestCase):

    @classmethod
    def setUpClass(cls):
        cls._wet_coffee = WetBeansCoffee()

    @classmethod
    def tearDownClass(cls) -> None:
        cls._wet_coffee = None

    def openJsonFile(self, location: string):
        return json.load(open(location))

    def test_drying_beans_for_consistency(self):
        test_data = self.openJsonFile("test_data.json")
        for loyalty in test_data:
            print(loyalty)


if __name__ == '__main__':
    unittest.main()

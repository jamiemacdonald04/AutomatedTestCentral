class CoffeeModel:
    label = ""
    sugar = 0
    milk = False
    bean_origin = ""

    def __init__(self, sugar_lumps, label, milk, bean_origin):
        self.label = label;
        self.sugar_lumps = sugar_lumps;
        self.milk = milk;
        self.bean_origin = bean_origin;


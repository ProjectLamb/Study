class Cat:
    def speak(self):
        print("meow")


class Dog:
    def speak(self):
        print("bark")


class Zoo:
    def __init__(self):
        self.cat = Cat()
        self.Dog = Dog()
        #self.sheep = Sheep()
        #self.cow = Cow()

class abstract_Animal:
    def speak(self):
        pass


class Cat(abstract_Animal):
    def speak(self):
        print("meow")


class Dog(abstract_Animal):
    def speak(self):
        print("bark")

# 동물원은 전혀 건들 필요 없어진다.


class Zoo:
    def __init__(self):
        self.animals = []  # 동물 리스트 만들기

    def AddAnimal(self, _animal: abstract_Animal):
        self.animals.append(_animal)

    def speakAll(self):
        for _animal in self.animals:
            _animal.speak()


zoo = Zoo()
zoo.AddAnimal(Cat())
zoo.AddAnimal(Dog())
zoo.speakAll()

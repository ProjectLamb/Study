# interface method
class Animal:
    def speak(self):
        pass


class Cat(Animal):
    def speak(self):
        print("meow")


class Dog(Animal):
    def speak(self):
        print("bark")


class Sheep(Animal):
    def speak(self):
        print("meh")


class Cow(Animal):
    def speak(self):
        print("moo")


def hey(animal):
    animal.speak()

# 추가되는 동물에 대해 hey함수의 수정을 필요로 하지 않는다


bingo = Dog()
kitty = Cat()
sheep = Sheep()
cow = Cow()

hey(bingo)
hey(kitty)
hey(sheep)
hey(cow)

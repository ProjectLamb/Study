class Animal():
    def __init__(self, type):
        self.type = type


def hey(animal):
    if animal.type == 'Cat':
        print('meow')
    elif animal.type == 'Dog':
        print('bark')


bingo = Animal('Dog')
kitty = Animal('Cat')

# Cow와 Sheep을 추가하기위해 hey함수의 수정이 필요하다.

hey(bingo)
hey(kitty)

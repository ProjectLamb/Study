class Cat:
    def speak(self):
        print("meow")


class BlackCat(Cat):
    def speak(self):
        print("black meow")


def speak(_cat: Cat):
    _cat.speak()


cat = Cat()
speak(cat)
cat = BlackCat()
speak(cat)

# 에러 발생
# class Fish(Cat):
#  def speak(self):
#    raise Exception("Fish cannot speak")
#
#cat = Fish()
# speak(cat)

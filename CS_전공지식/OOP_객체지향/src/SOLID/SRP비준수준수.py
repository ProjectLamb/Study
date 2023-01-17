# 다음은 두개의 기능이 섞여있어 옳지 않다
def addPrint(a, b):
    res = a + b
    print(res)
# 다음과 같이 단 하나의 책임으로 분리하자


def add(a, b):
    return a + b


def printf(str):
    print(str)

class Dog {
    public string bark() { return "woof woof";}
}

class Duck{    
    public string bark() { return "quack quack";}    
}

class Fox {
    public string whatDoesTheFoxSay() { return "ring-ding-ding-ding-dingeringeding!, Wa-pa-pa-pa-pa-pa-pow!";}
}

class Communication {
    public string communicate(?????? _animal)
    {
        switch (true) {
            case animal.IsInstanceOfType(Dog):
                return animal.bark();
            case animal.IsInstanceOfType(Duck):
                return animal.quack();
            case animal.IsInstanceOfType(Fox):
                return animal.whatDoesTheFoxSay();
            default:
                throw new InvalidArgumentException("Unknown animal");
        }
    }
}

//기존 코드를 변경하지 않고 새 동물 클래스를 추가할 수 있습니까? 
//새 동물 클래스를 추가하려면 communi () 함수에서 스위치를 수정해야 합니다. 

//게다가 벌써부터 communicate에 오류가 났다.
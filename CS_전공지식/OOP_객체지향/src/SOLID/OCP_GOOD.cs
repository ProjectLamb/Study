interface IComunicatable
{
    public string speak();
}

class Dog : IComunicatable
{
    public string speak() { return "'woof woof'"; }
}

class Duck : IComunicatable {   
    public string speak() { return "'quack quack'"; }
}

class Fox : IComunicatable {
    public string speak() { return "ring-ding-ding-ding-dingeringeding!, Wa-pa-pa-pa-pa-pa-pow!"; }
}

class Communication
{
    public string communicate(IComunicatable _animal)
    {
        return _animal.speak();
    }
}


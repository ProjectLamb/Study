using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    /*
    *
    */
    interface Observer {
        public void Update();
    }

    class Subject {
        List<Observer> mObservers = new List<Observer>();

        public void Register(Observer _observer) {
            mObservers.Add(_observer);
        }

        public void Unregister(Observer _observer){
            mObservers.Remove(_observer);
        }

        public void AlertToObservers(){
            foreach(Observer E in mObservers){E.Update();}
        }
    }

    /*
    * Concrete
    */
    class ConcreteObserver_Cat : Observer {
        public void Update() {
            Console.WriteLine("Meow");
        }
    }
    class ConcreteObserver_Dog : Observer {
        public void Update() {
            Console.WriteLine("Bark");
        }
    }
    class Owner : Subject {}
    /*
    * Client.cs
    */
    static void Main(string argv){
        Owner owner = new Owner();
        ConcreteObserver_Cat cat = new ConcreteObserver_Cat();
        ConcreteObserver_Dog dog = new ConcreteObserver_Dog();

        owner.Register(cat);  owner.Register(dog);
        owner.AlertToObservers();
        owner.Unregister(cat);
        owner.AlertToObservers();
    } 
}
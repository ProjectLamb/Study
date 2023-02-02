using System;
namespace Observer2
{
    public abstract class Observer_Player
    {
        private String name;

        public Observer_Player(String _name)
        {
            this.name = _name;
        }

        public String Name { get { return this.name; } }

        public abstract void Update(int diceNumber);
    }

    public class ConcreteObserver_EvenBattingPlayer : Observer_Player
    {
        public ConcreteObserver_EvenBattingPlayer(String _name) : base(_name) { }
        public override void Update(int diceNumber)
        {
            if (diceNumber % 2 == 0) { Console.WriteLine("짝수 당첨"); }
        }
    }
    public class ConcreteObserver_OddBattingPlayer : Observer_Player
    {
        public ConcreteObserver_OddBattingPlayer(String _name) : base(_name) { }
        public override void Update(int diceNumber)
        {
            if (diceNumber % 2 != 0) { Console.WriteLine("홀수 당첨"); }
        }
    }
}
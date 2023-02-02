using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    public abstract class Observer_Player {
        private String name;

        public Observer_Player(String _name) {
            this.name = _name;
        }

        public String Name {get{return this.name;}}

        public abstract void Update(int diceNumber);
    }

    public abstract class Subject_DiceGame {
        protected List<Observer_Player> playerList = new List<Observer_Player>();

        public void AddPlayer(Observer_Player player){
            playerList.Add(player);
        }

        public abstract void Play();
    }

    public class ConcreteSubject_FairDiceGame : Subject_DiceGame {
        private Random random = new Random();

        public override void Play()
        {
            int diceNumber = random.Next(6) + 1;
            Console.WriteLine($"주사위눈 : {this.diceNumber}");

            foreach(Observer_Player E in playerList){
                E.Update(diceNumber);
            }
        }
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

    public static void main(String[] args){
        Subject_DiceGame diceGame = new ConcreteSubject_FairDiceGame();

        ArrayList<Observer_Player> player = new ArrayList<Observer_Player>();
        player.Add(new ConcreteObserver_EvenBattingPlayer("짝궁둥이"));
        player.Add(new ConcreteObserver_OddBattingPlayer("홀아비"));
        player.Add(new ConcreteObserver_OddBattingPlayer("홀쭉이"));

        foreach(Observer_Player E in player){
            diceGame.AddPlayer(E);
        }

        for(int i = 0; i< 5; i++){
            diceGame.Play();
            Console.WriteLine();
        }
    }
}
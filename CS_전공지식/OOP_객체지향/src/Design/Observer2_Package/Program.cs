using System;
using System.Collections;
using System.Collections.Generic;

namespace Observer2
{
    public class Program
    {
        public static void Main()
        {
            Subject_DiceGame diceGame = new ConcreteSubject_FairDiceGame();

            List<Observer_Player> player = new List<Observer_Player>();
            player.Add(new ConcreteObserver_EvenBattingPlayer("짝궁둥이"));
            player.Add(new ConcreteObserver_OddBattingPlayer("홀아비"));
            player.Add(new ConcreteObserver_OddBattingPlayer("홀쭉이"));

            foreach (Observer_Player E in player)
            {
                diceGame.AddPlayer(E);
            }

            for (int i = 0; i < 5; i++)
            {
                diceGame.Play();
                Console.WriteLine();
            }
        }
    }
}
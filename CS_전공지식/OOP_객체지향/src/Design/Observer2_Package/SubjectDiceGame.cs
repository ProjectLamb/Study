using System;
namespace Observer2
{
    public abstract class Subject_DiceGame
    {
        protected List<Observer_Player> playerList = new List<Observer_Player>();

        public void AddPlayer(Observer_Player player)
        {
            playerList.Add(player);
        }

        public abstract void Play();
    }

    public class ConcreteSubject_FairDiceGame : Subject_DiceGame
    {
        private Random random = new Random();

        public override void Play()
        {
            int diceNumber = random.Next(6) + 1;
            Console.WriteLine($"주사위눈 : {diceNumber}");

            foreach (Observer_Player E in playerList)
            {
                E.Update(diceNumber);
            }
        }
    }
}
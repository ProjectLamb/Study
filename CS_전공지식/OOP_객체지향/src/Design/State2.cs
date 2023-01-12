using System;
using System.Collections;
using System.Collections.Generic;
namespace DesignPattern
{
    public class Player
    {
        public Player() { speed = 0;  state = new StateStandUp(this); }
        public int speed { get; set; }
        public State state { get; set; }

        public void Talk(String _msg)
        {
            Console.WriteLine($"플레이어의 말 : {_msg}");
        }
    }

    //플레이어에 대한 State 객체 작성
    public abstract class State
    {
        protected Player player;
        public State(Player _player)
        {
            this.player = _player;
        }

        public abstract void StandUp();
        public abstract void SitDown();
        public abstract void Walk();
        public abstract void Run();
        public abstract String GetDescription(); //현재 상태 반환
    }


    public class StateStandUp : State
    {
        public StateStandUp(Player _player) : base(_player) { }

        public override void StandUp() { player.Talk("언제 음직일꺼야?"); }
        public override void SitDown() { 
            player.Talk("앉으니깐 좋다.");
            player.state = new StateSitDown(player);
        }
        public override void Walk()
        {
            player.speed = 5;
            player.state = new StateWalk(player);
            player.Talk("걷기 시작.");
        }
        public override void Run()
        {
            player.speed = 20;
            player.state = new StateRun(player);
            player.Talk("갑자기?? 존나뛰어.");
        }
        public override String GetDescription()
        {
            return "지금은 서있는 상태";
        }
    }
    public class StateSitDown : State
    {
        public StateSitDown(Player _player) : base(_player) { }
        public override void StandUp()
        {
            player.state = new StateStandUp(player);
            player.Talk("일어나자.");
        }
        public override void SitDown()
        {
            player.Talk("쥐나겠다.");
        }
        public override void Walk()
        {
            player.speed = 1;
            player.state = new StateStandUp(player);
            player.Talk("어떻게 앉은상태에서 걷냐? 일단 서있자");
        }
        public override void Run()
        {
            player.speed = 1;
            player.state = new StateStandUp(player);
            player.Talk("어떻게 앉은상태에서 뛰냐 일단 서있자");
        }
        public override String GetDescription()
        {
            return "앉아있음";
        }

    }
    public class StateWalk : State
    {
        public StateWalk(Player _player) : base(_player) { }
        public override void StandUp()
        {
            player.speed = 0;
            player.state = new StateStandUp(player);
            player.Talk("멈춰..");
        }
        public override void SitDown()
        {
            player.speed = 0;
            player.state = new StateSitDown(player);
            player.Talk("걷다가 앉으면 넘어질 수 있다.");
        }
        public override void Walk()
        {
            player.Talk("난 걷는걸 좋아하지");
        }
        public override void Run()
        {
            player.speed = 20;
            player.state = new StateRun(player);
            player.Talk("슬슬 뛴다.");
        }
        public override String GetDescription()
        {
            return "걷는 중";
        }
    }
    public class StateRun : State
    {
        public StateRun(Player _player) : base(_player) { }
        public override void StandUp()
        {
            player.speed = 0;
            player.state = new StateStandUp(player);
            player.Talk("뛰다가 갑자기 멈춰?? 연골 나가요.");
        }
        public override void SitDown()
        {
            player.speed = 0;
            player.state = new StateSitDown(player);
            player.Talk("뛰다가 어떻게 앉노.. 미쳤나");
        }
        public override void Walk()
        {
            player.speed = 5;
            player.state = new StateWalk(player);
            player.Talk("속도 줄인다~");
        }
        public override void Run()
        {
            player.speed += 2;
            player.state = new StateRun(player);
            player.Talk("더 빨리 뛰라고? ㅇㅋ");
        }
        public override String GetDescription()
        {
            return "달리는 중";
        }
    }
    static void StateMain()
    {
        Console.WriteLine("[1] : 서있기 | [2] : 앉기 | [3] : 걷기 | [4] : 뛰기 | [5] : 상태 출력 | [0] : 종료");
        Player player = new Player();
        bool stop = false;
        while (!stop)
        {
            var Input = Console.ReadLine();

            try
            {
                var validValue = Input;
            }
            catch
            {
                Console.WriteLine("You did not enter a valid format.");
                Console.ReadLine();
            }

            switch (Input)
            {
                case "1":
                    player.state.StandUp();
                    break;
                case "2":
                    player.state.SitDown();
                    break;
                case "3":
                    player.state.Walk();
                    break;
                case "4":
                    player.state.Run();
                    break;
                case "5":
                    Console.WriteLine(player.state.GetDescription());
                    break;
                case "0":
                    Console.WriteLine("프로그램 종료");
                    stop = true;
                    return;
                default:
                    break;
            }
        }
    }
}
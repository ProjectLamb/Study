using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    internal class Decorator {
        interface Attackable {
            public void Attack();
        } 

        public class Player : Attackable {
            public void Attack(){
                Console.WriteLine("평타");                
            }            
        } 

        public abstract class Decorator : Attackable {
            protected Attackable attackable;
            public Decorator(Attackable attackable){
                this.attackable = attackable;
            }
        }

        public class Laser : Decorator {
            public override void Attack(){
                attackable.Attack();
                Console.WriteLine("찌유유유웅");       
            }
        }

        public class Knife : Decorator {
            public override void Attack(){
                attackable.Attack();
                Console.WriteLine("슉 슈슈슉 ㅅ벌럼아 칼협 칼협");       
            }
        }

        public class Screem : Decorator {
            
            public override void Attack(){
                attackable.Attack();
                Console.WriteLine("喝!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
        
        static void Main(string[] argv){
            Player player = new Player();
            player.Attack();

            Attackable decorator = new Laser(player);
            decorator.Attack();
            decorator = new Knife(decorator);
            decorator.Attack();
            decorator = new Laser(decorator);
            decorator = new Screem(decorator);
            decorator.Attack();
        }
    }
}
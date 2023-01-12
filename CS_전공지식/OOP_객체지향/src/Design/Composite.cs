using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    internal class Composite {
        public interface Equipment_Composition {
            public void Equip();
            public void Dump();
        }

        public class Weapon_Leaf : Equipment_Composition {
            public void Equip(){/*...*/}
            public void Dump(){/*...*/}
        }
        public class Hat_Leaf : Equipment_Composition {
            public void Equip(){/*...*/}
            public void Dump(){/*...*/}
        }
        public class Body_Leaf : Equipment_Composition {
            public void Equip(){/*...*/}
            public void Dump(){/*...*/}
        }
        public class Accessories_Leaf : Equipment_Composition {
            public void Equip(){/*...*/}
            public void Dump(){/*...*/}
        }
        public class Player : Equipment_Composition {
            Array<Equipment_Composition> Equipments = new Array<Equipment_Composition>();

            public void 줍기(Equipment_Composition _장비){
                Equipments.Add(_장비);
            }

            public override void EquipAll(){
                foreach(Equipment_Composition E in Equipments){
                    E.Equip();
                }
            }
        }

        static void Main(string argv){
            Player Sophia = new Player();
            Weapon_Leaf sword = new Weapon_Leaf(); 
            Body_Leaf 철갑옷 = new Body_Leaf();
            
            Sophia.줍기(sword);
            Sophia.줍기(철갑옷);

            Sophia.EquipAll();
        } 
    }
}
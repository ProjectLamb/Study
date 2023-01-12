using System;
using System.Collections;
using System.Collections.Generic;

namespace DesignPattern
{
    internal class Composite {
        public interface Graphic {
            public void Print();
        }
        public class Ellipse : Graphic {
            static int ellipseNum = 0;
            private int order = 0;
            public Ellipse() {
                order = ellipseNum;
                ellipseNum++;
            }
            public void Print(){ Console.WriteLine($"{this.order} Ellipse"); }
        }

        public class Circle : Graphic {
            static int circleNum = 1;
            private int order = 0;
            public Circle() {
                order = circleNum;
                circleNum++;
            }
            public void Print(){ Console.WriteLine($"{this.order} Circle"); }
        }

        public class CompositeGrapic : Graphic {
            private readonly List<Graphic> graphics = new List<Graphic>();
            public void addGrapic(Graphic G){
                graphics.Add(G);
            }
            public void Print(){
                foreach(Graphic E in graphics){E.Print();}
            }            
        }

        static void Main(string argv){
            CompositeGrapic compositeGrapic = new CompositeGrapic();
            compositeGrapic.addGrapic(new Circle());
            compositeGrapic.addGrapic(new Circle());
            compositeGrapic.addGrapic(new Ellipse());
            compositeGrapic.addGrapic(new Circle());
            compositeGrapic.addGrapic(new Ellipse());
            compositeGrapic.addGrapic(new Ellipse());
            compositeGrapic.addGrapic(new Ellipse());

            compositeGrapic.Print();
        }
    }
}
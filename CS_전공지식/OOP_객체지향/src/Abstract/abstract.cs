namespace interface_ex {

    /************************************************
    *추상 클래스는 다른 클래스를 만드는데 도움을 준다.
    *************************************************/
    abstract class Player{ //(미완성 클래스, 미완성 설계도) 
      //void Play(int _pos){} 
            //{...}몸통이 있으면 (구현이 되어있으면) 상관없다 에러 안뜨는데..

      //////////////////////////////////////////
        abstract void Play(int _pos);
        abstract void Stop();
      //////////////////////////////////////////
            //다음과 같이 몸통 없는 함수를 쓰면.. abstract가 된다.

    }
    public class App
    {
        public static void main(){
            Player p = new Player();
        }
    }
}
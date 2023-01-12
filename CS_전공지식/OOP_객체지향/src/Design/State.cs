namespace DesignPattern
{
    enum Estate{ GREEN, YELLOW, RED}
    //enum I{}
    /* 다음은 안좋은 예시
    public class TrraficLight {
        private State mState;
        public TrraficLight(State _s){ this.state = _s; }
        public State state {get; set;} 
        public void Speak(State _s){
            if(_s == GREEN){Console.WriteLine("green light");}
            else if(_s == RED){Console.WriteLine("red light");}
        }

        public void Wait(State _s){
            Console.WriteLine("Wait.. the light changed");
            if(_s == GREEN){Console.WriteLine("green light");}
            else if(_s == RED){Console.WriteLine("red light");}
        }
    }
    */

    public class TrraficLight {
        private State mState;
        public State state {get; set;} 
        
        public TrraficLight(State _s){
            this.state = _s;
        }
        public void Speak(){
            this.state.Speak();
        }
        public void Wait(){
            this.state.Wait();
        }
    }

    public interface State {
        public void Speak();
        public void Wait(TrraficLight _trraficLight);
    }

    public class GreenLight : State {
        public void Speak(){Console.WriteLine("green light");}
        public void Wait(TrraficLight _trraficLight){
            _trraficLight.state = RedLight;//바뀌어질 상태
            Console.WriteLine("wait.. the light changed");
        }
    }
    public class RedLight : State {
        public void Speak(){Console.WriteLine("red light");}
        public void Wait(TrraficLight _trraficLight){
            _trraficLight.state = GreenLight;//바뀌어질 상태
            Console.WriteLine("wait.. the light changed");
        }
    }
    //서로 상태 클래스는 서로 각각 상태클래스를 알고있다.
}
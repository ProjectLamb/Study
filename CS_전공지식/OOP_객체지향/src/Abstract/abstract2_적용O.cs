namespace starCraft {
    ///////////////////////////////////////
    abstract class Unit{
        int x, y;
        abstract void move(int _x, int _y);
        void stop();
    }
    ///////////////////////////////////////
        // 유닛이라 하면 꼭 구현이 되어 있어야 하는 부분들이다.

    ///////////////////////////////////////
    public class Marin : Unit{
        void move(int _x, int _y) {/*마린 전용 구현부*/}
        void stimPack(){}
    }
    public class Tank : Unit{
        void move(int _x, int _y) {/*탱크 전용 구현부*/}
        void changeMode(){}
    }
    public class Dropship : Unit{
        void move(int _x, int _y) {/*드랍쉽 전용 구현부*/}
        void load(){}
        void unload(){}
    }
    ///////////////////////////////////////
        // abstract를 상속받아 각 클래스마다 구현부 다르게

    public class app
    {
        public static void main(){
            Unit[] group = new Unit[3];
            group[0] = new Marin();
            group[1] = new Tank();
            group[2] = new Dropship();
        }
    }
}

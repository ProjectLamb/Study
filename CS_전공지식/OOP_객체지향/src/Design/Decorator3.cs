namespace DesignPattern
{
    public interface Component
    {
        public String add();
    }

    public class 에스프레소 : Component {
        String name = "에스프레소";
        public String add() {
            return name;
        }
    }

    public abstract class CoffeeDecorator : Component{
        protected readonly Component coffeeComponent;
        public CoffeeDecorator(Component component){
            this.coffeeComponent = component;
        }
        public virtual String add()
        {
            return coffeeComponent.add();
        }
    }
    public class 물데코레이터 : CoffeeDecorator
    {
        public 물데코레이터(Component component) : base(component) { }
        public override String add() { return $"{coffeeComponent.add()} + 물"; }
    }
    public class 우유데코레이터 : CoffeeDecorator {
        public 우유데코레이터(Component component) : base(component){}
        public override String add() { return $"{coffeeComponent.add()} + 우유"; }
    }
    public class 얼음데코레이터 : CoffeeDecorator
    {
        public 얼음데코레이터(Component component) : base(component) { }
        public override String add() { return $"{coffeeComponent.add()} + 얼음"; }
    }
    public class 휘핑크림데코레이터 : CoffeeDecorator
    {
        public 휘핑크림데코레이터(Component component) : base(component) { }
        public override String add() { return $"{coffeeComponent.add()} + 휘핑크림"; }
    }
    public class 자바칩데코레이터 : CoffeeDecorator
    {
        public 자바칩데코레이터(Component component) : base(component) { }
        public override String add() { return $"{coffeeComponent.add()} + 자바칩"; }
    }
    static void Main(string[] argv)
    {
        Component espresso = new 에스프레소();
        Console.WriteLine($"espresso : {espresso.add()}");
        Component americano = new 물데코레이터(espresso);
        Console.WriteLine($"americano : {americano.add()}");
        Console.WriteLine($"espresso : {espresso.add()}");
        Component latte = new 우유데코레이터(new 에스프레소());
        Console.WriteLine($"latte : {latte.add()}");

        Component 자바칩프라푸치노 = new 자바칩데코레이터(new 휘핑크림데코레이터(new 얼음데코레이터(latte)));
        Console.WriteLine($"자바칩프라푸치노 : {자바칩프라푸치노.add()}");
    }
}
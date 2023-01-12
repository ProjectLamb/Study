
class Rectangle
{
    protected int width;
    protected int height;

    public void setWidth(int width) {
        this.width = width;
    }

    public void setHeight(int height){
        this.height = height;
    }

    public int calculateArea(): int
    {
        return this.width * this.height;
    }
}

class Square : Rectangle
{
    public void setWidth(int width)
    {
        this.width = width;
        this.height = width;
    }

    public void setHeight(int height)
    {
        this.width = height;
        this.height = height;
    }
}

class RectangleTest extends TestCase
{
    public  testCalculateArea()
    {
        shape = /* new Rectangle(); - lets replace by */ new Square();
        shape.setWidth(10);
        shape.setHeight(2);

        this.assertEquals(shape.calculateArea(), 20); // FAILS - 4 != 20

        shape.setWidth(5);
        this.assertEquals(shape.calculateArea(), 10); // FAILS - 25 != 10
    }
}

//부모 클래스의 메서드가 작동하는 방식을 변경해서는 안 됩니다.

//Square 클래스는 Rectangle 클래스에서 상속하면 안 됩니다. 
//이 두 클래스가 모두 계산 영역을 가질 수 있는 경우 
//공통 인터페이스를 구현하고 상당히 다르기 때문에 서로 상속하지 않도록 합니다.
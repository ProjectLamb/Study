interface IICalculableArea
{
    public calculateArea();
}

class Rectangle : ICalculableArea
{
    protected int width;
    protected int height;

    public void __construct(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public int calculateArea() {
        return this.width * this.height;
    }
}

class Square : ICalculableArea
{
    protected int edge;

    public void __construct(int edge) {
        this.edge = edge;
    }

    public  calculateArea(){
        return this.edge * this.edge ;
    }
}
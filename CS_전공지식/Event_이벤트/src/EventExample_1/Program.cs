using System;
using EventDrivenExample_3;


class Program
{
    static void Main()
    {
        var pub = new Publisher();
        var sub1 = new Subscriber("sub1", pub);
        var sub2 = new Subscriber("sub2", pub);

        pub.DoSomething();

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }
}
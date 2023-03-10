using System;

Action action = () =>
{
    Console.WriteLine("Start Sleep on {0} second", 1);
    Thread.Sleep(1000);
    Console.WriteLine("...");
};

Action<object> actionObject = (input) =>
{
    int inputInt = (int)input;
    Console.WriteLine("Start Sleep on {0} second", inputInt);
    while (inputInt-- != 0)
    {
        Thread.Sleep(1000);
        Console.WriteLine("...");
    }
};

Func<int> func = () =>
{
    Console.WriteLine("Start Sleep on {0} second", 1);
    Thread.Sleep(1000);
    Console.WriteLine("...");
    return 100;
};

Func<object, int> funcObject = (input) =>
{
    int inputInt = (int)input;
    Console.WriteLine("Start Sleep on {0} second", inputInt);
        while (inputInt-- != 0)
    {
        Thread.Sleep(1000);
        Console.WriteLine("...");
    }
    return 100 * (int)input;
};
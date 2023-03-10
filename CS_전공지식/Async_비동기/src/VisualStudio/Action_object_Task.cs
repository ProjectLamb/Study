using System;
using System.Threading.Tasks;

/*
Action<object> 
    : 리턴 없음
    : 인풋 있음 

Task.Factory.StartNew(Action<object>, object);
*/

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

List<Task> actionsObjectTasks = new List<Task>();

Console.WriteLine("인풋은 있지만 리턴 없는 것 동기 실행");
Console.WriteLine("Start");
Task.Run(() => { actionObject.Invoke(1); })
    .ContinueWith(t => actionObject.Invoke(2))
    .ContinueWith(t => actionObject.Invoke(3))
    .ContinueWith(t => actionObject.Invoke(4)).Wait();
Console.WriteLine("Finished");


Console.WriteLine("인풋은 있지만 리턴도 없는 것 비동기 실행");
Console.WriteLine("Start");
for (int i = 0; i < N; i++)
{
    actionsObjectTasks.Add(Task.Factory.StartNew(actionObject, i + 1));
}
Task.WhenAll(actionsObjectTasks).Wait();
Console.WriteLine("Finished");
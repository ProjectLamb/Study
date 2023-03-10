using System;
using System.Threading.Tasks;

/*
Action 
    : 리턴 없음
    : 인풋 없음

Task.Run();
*/

Action action = () =>
{
    Console.WriteLine("Start Sleep on {0} second", 1);
    Thread.Sleep(1000);
    Console.WriteLine("...");
};

List<Task> actionsTasks = new List<Task>();

Console.WriteLine("인풋도 없고 리턴도 없는 것 동기 실행");
Console.WriteLine("Start");
Task.Run(action)
    .ContinueWith(t => action.Invoke())
    .ContinueWith(t => action.Invoke())
    .ContinueWith(t => action.Invoke()).Wait();
Console.WriteLine("Finished");

Console.WriteLine("인풋도 없고 리턴도 없는 것 비동기 실행");
Console.WriteLine("Start");
for (int i = 0; i < N; i++) { actionsTasks.Add(Task.Run(() => action.Invoke())); }
Task.WhenAll(actionsTasks).Wait();
Console.WriteLine("Finished");

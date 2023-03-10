using System;
using System.Threading.Tasks;
using System.Linq;

Func<int> func = () =>
{
    Console.WriteLine("Start Sleep on {0} second", 1);
    Thread.Sleep(1000);
    Console.WriteLine("...");
    return 100;
};

List<Task<int>> funcTasks = new List<Task<int>>();

Console.WriteLine("인풋은 없지만 리턴은 있는것 동기 실행");
Console.WriteLine("Start");
Task<int>.Run(func)
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return func.Invoke();
    })
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return func.Invoke();
    })
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return func.Invoke();
    }).Wait();
Console.WriteLine("Finished");

Console.WriteLine("인풋은 없지만 리턴은 있는것 funcTasks동기 실행");

Console.WriteLine("Start");
for (int i = 0; i < N; i++) { funcTasks.Add(Task.Run(() => func.Invoke())); }
var funcTasksAll = Task<int>.WhenAll(funcTasks);
funcTasksAll.Wait();
var ints = funcTasksAll.Result;

Console.WriteLine("Funcs Result {0}", ints.Sum());
Console.WriteLine("Finished");
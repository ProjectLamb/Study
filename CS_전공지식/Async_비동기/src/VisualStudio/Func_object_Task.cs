using System;
using System.Threading.Tasks;
using System.Linq;

Func<object, int> funcObject = (input) =>
{
    int inputInt = (int)input;
    Console.WriteLine("Start Sleep on {0} second", inputInt);
    for (int i = 0; i < inputInt; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine("...");
    }
    return 100 * inputInt;
};

List<Task<int>> funcsObjectTasks = new List<Task<int>>();
Console.WriteLine("인풋도 있고 리턴도 있는 동기 실행");
Console.WriteLine("Start");

Task<int>.Factory.StartNew(funcObject, 1)
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return funcObject.Invoke(2);
    })
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return funcObject.Invoke(3);
    })
    .ContinueWith((t) =>
    {
        Console.WriteLine(t.Result);
        return funcObject.Invoke(4);
    }).Wait();
Console.WriteLine("Finished");


Console.WriteLine("인풋도 있고 리턴도 있는것 비동기 실행");
Console.WriteLine("Start");
for (int i = 0; i < N; i++)
{
    funcsObjectTasks.Add(Task<int>.Factory.StartNew(funcObject, i + 1));
}
var funcObjectTasksAll = Task<int>.WhenAll(funcsObjectTasks);

var ints = funcObjectTasksAll.Result;
Console.WriteLine("Funcs Result {0}", ints.Sum());
Console.WriteLine("Finished");
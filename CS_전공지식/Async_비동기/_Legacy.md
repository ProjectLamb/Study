테스트 연결
```cs
Task<int> t = new Task<int>(n => Sum((int) n), 100);  //Int 반환을 가지는 Task 
//100은 뭐냐..

t.Start();                  //명시적 시작
t.Wait();                   //Task 완료 대기

Console.WriteLine($"result is {t.Result}");
-----------------------------------------------

//t 가 완료되면 Console.Writeline 를 실행해라.
Task<Int32> t = Task.Run(() => Sum(CancellationToken.None, 100));
Task cwt = t.Continuewith(task => Console.Writeline("The sum is: " + task.Result));
```

조건적 태스크 연결
```cs
// TaskContinuationOptions
// OnlyOnCanceled, OnlyOnFaulted, OnlyOnRantoCompletion, 79

CancellationTokenSource cts = new CancellationTokenSource();

cts.Cancel();


Task<Int32> t = Task.Run(() => Sum(cts. Token, 100), cts.Token);

t.Continuewith( //성공 완료시
    task => Console.WriteLine(" The sum is: "+ task.Result), 
    TaskContinuation0ptions.OnlyOnanToCompletion
    );

t.Continuewith(
    //예외 발생시
    task => Console.Writeline(" Sum threw: " + task.Exception.InnerException),
    TaskContinuationOptions.Only0nFaulted
    );

t.Continuewith(
    task => Console.WriteLine("Sum was canceled"), 
    TaskContinuationOptions.OnlyOnCanceled
    );
```

태스크의 복잡한 연결
```cs
// Parent/Child Task₴9 92, TaskCreationOptions.AttachedToParent 

Task<Int32[]> parent = new Task<Int32[]>(() =>
{
    var results = new Int32[3];
    new Task(() => //차일드로 연결
        results[0] = Sum(10), TaskCreationOptions.AttachedToParent).Start();
    new Task(() => //차일드로 연결
        results[1] = Sum(20), TaskCreationOptions.AttachedToParent).Start();
    new Task(() => //차일드로 연결
        results[2] = Sum(30), TaskCreationOptions.AttachedToParent).Start();
    return results;
});

var cwt = parent.Continuewith( // parent Task가 끝나면 수행할 Task 연결
    parentTask => Array.ForEach(parentTask. Result, Console.Writeline)
);

parent.Start();
```

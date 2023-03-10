using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Example_1 {
    public static void Main(){
        int ctr = 0;
        while(ctr <= 1000000){ctr++;}
        Console.WriteLine("Finished {0} loop iterations", ctr);
    }
}

public class Example_1_Async {
    public static async Task<int> Main(){
        var result = await Task<int>.Run(() =>{
                        int ctr = 0;
                        while(ctr <= 1000000){ctr++;}
                        Console.WriteLine("F inished {0} loop iterations", ctr);
                        return ctr;
                });
    }
}

public class Example_1_AsyncCancelation {

    CancellationTokenSource tokenSource;
    private void Awake() {
        tokenSource = new CancellationTokenSource();
    }
    public static async Task<int> Main(){
        var result = await Task<int>.Run(() =>{
                            int ctr = 0;

                            while(ctr <= 1000000){
                                ctr++;
                                if(tokenSource.IsCancellationRequested){return;}
                            }
                            Console.WriteLine("F inished {0} loop iterations", ctr);
                            return ctr;
                        }, tokenSource.Token);
    }
    private void OnDisable() {
        tokenSource.Cancel();
    }
}

/*
단, 이건 프로그램이 끝나도 취소작업을 안했기 때문에 멈추질 않는다.
*/



/*
* 단일 작업에 대해 연속 작업 만들기
*/

public class Example_2 {
    public static async Task Main(){
        Task<DayOfWeek> taskA = Task.Run(()=>DateTime.Today.DayOfWeek);

        await taskA.ContinueWith(
            (antecent) => {
                Console.WriteLine($"Today is {antecent.Result}.");
            }
        );
    }
}

/*
여러 선행 작업에 대해 연속 작업 만들기
WhenAll : WhenAll도 테스크를 병렬 실행
WhenAny : WhenAny도 테스크를 병렬 실행
*/

public class WhenAllExample {
    public static async Task Main(){
        var tasks = new List<Task<int>>();
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int baseValue = ctr;
            tasks.Add(Task.Factory.StartNew(
                (b) => {
                    Thread.Sleep(1000);
                    return (int)b! * (int)b;
                }
                , baseValue));
        }

        var results = await Task.WhenAll(tasks);
        for (int i = 0; i < results.Length; i++) {
            Console.WriteLine(results[i]);
        }
        int sum = 0;

        for (int ctr = 0; ctr <= results.Length - 1; ctr++)
        {
            var result = results[ctr];
            Console.Write($"{result} {((ctr == results.Length - 1) ? "=" : "+")} ");
            sum += result;
        }

        Console.WriteLine(sum);
    }
}
//예상하기로 3초 걸릴듯

public class WhenAnyExample {
    public static async Task Main(){
        var tasks = new List<Task<int>>();
        for (int ctr = 1; ctr <= 10; ctr++)
        {
            int baseValue = ctr;
            tasks.Add(Task.Factory.StartNew((b) => { Thread.Sleep(1000); return (int)b! * (int)b; }, baseValue));
        }
        List<int> results = new List<int>();
        while (tasks.Any())
        {
            var finished = await Task.WhenAny(tasks);
            results.Add(finished.Result);
            Console.WriteLine(finished.Result);
            tasks.Remove(finished);
        }

        int sum = 0;

        for (int ctr = 0; ctr <= results.Count - 1; ctr++)
        {
            var result = results[ctr];
            Console.Write($"{result} {((ctr == results.Count - 1) ? "=" : "+")} ");
            sum += result;
        }

        Console.WriteLine(sum);
    }
}
/*
https://learn.microsoft.com/ko-kr/dotnet/standard/parallel-programming/chaining-tasks-by-using-continuation-tasks
https://www.youtube.com/watch?v=gxaJyuf-2dI
*/
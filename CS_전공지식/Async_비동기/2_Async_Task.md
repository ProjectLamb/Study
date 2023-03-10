---
ebook:
  theme: one-dark.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #45C1A4; border-left: 5px solid #45C1A4; border-right: 5px solid #45C1A4; background-color: #45C1A4; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #45C1A4 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## ⏱️ 2. Async Task


* 결국 핵심은 Task 라는 것이죠. 그리고 이 Task 는 문서에 나와있듯 비동기적인 작업에 대한 단위입니다. 이제 Task 하면 비동기적인 작업이겠구나를 연상시켜 보세요.

* 태스크간 상관관계가 없어야 한다. 그래야지 병렬화 할 수 있고 그룹화 할 수 있다.

### 📄 1. Task

**① Task 인스턴스**
1. Task : 작업 반환값이 존재하지 않는것 (Action 델리게이트)
2. Task﹤TResult﹥ : 작업 반환값이 존재하는것 (Func 델리게이트)

**② Task 실행**
1. taskInstance.Start() : 인스턴스화 된 작업 실행하기 
2. Task.Run() : 인스턴스 없이 바로 실행

![](./img/2023-03-08-17-54-42.png)


**③ 실행된 Task 기다리기**
1. Wait() : 해당 작업이 모두 완료 때까지 기다리기
2. async await : 가독성이 좋다.

**④ Task 연속**
1. ContinueWith()
    * 콜백을 등록해 작업 결과를콜백으로 받는 방식
    * Task 인스턴스를 연속적으로 전달 할 수도 있고, 병렬적인 처리도 가능하다.

#### 구제적인 사용법

1. 기본 동작 : 단순 비동기 작업이 목적이다.
   1. Task인스턴스를 만들고 
   2. 원하는 작업을 연결해 Start() 호출
   3. 기다리기 Wait()
   4. 결과 반환받기 .Result

2. 인스턴스 없이 
   1. Task.Run(델리게이트)를 사용한다.
   2. Action, Func 같은 델리게이트를 전달받는다.
   3. 호출시 비동기 작업이 시작된 Task 인스턴스를 반환함

3. 기본 동작을 이용한 병렬처리
   1. Task를 여러개 만들어 동시에 동작시킨다/
   2. 이 Task에 대해 
      1. 각각 기다리게 하거나
      2. 특정 Task 작업이 완료되기를 기다려야한다면
   3. WhenAll(), WhenAny()
      1. WhenAll() : Task 배열을 인자로 받는다.
         * 모두 완료될때까지 대기
      2. WhenAny() : Task 먼저끝난 하나를 인자로 받든다
         * 가장 먼저 완료되는 Task 배열의 인덱스를 반환 하나라도 완료되면 다음 라인으로 진행
         * 인덱스 순서는 완료된 순서


4. 콜백을 이용한 비동기 처리
   1. ContinueWith() 메서드 사용
   2. 콜백으로 사용할 메서드를 Action Func를 넘긴다.
   3. 연속적인 병렬처리 가능 혹은 콜백 내부에서 다른 Task 실행 가능

5. TAP의 Cancel
   1. CancellationTokenSource 인스턴스를 생성해
   2. CancellationToken 값을 이용해 조작할수 있다

### 📄 2. 스레드풀

###### \#작업 \#작업을담는 큐 \#스레드


#### 1). 작업
1. 작업은 실행될 함수를 담는 클래스다. 
**단, 변수화된 함수를 담는 클래스다.**
1. 인스턴스화가 된다.
2. 함수를 병렬적(동기적), 또는 순차적(비동기적)으로 실행한다.

**① 델리게이트 만들기**

*
    ```cs
    delegate T DelegateType(T param,[...]);

    //1. Action 리턴 없는것
    Action action = () => {};
    Action<T> actionT = (T param) => {};

    //2. Func 리턴 있는것
    Func<TResult> func = () => {return result as TResult};
    Func<T, TResult> funcT = (T param) => {return result as TResult};

    //3. 람다식 그 자체
    ```

**② Task Instance 만들기**
1. Action : *리턴이* 없는 델리게이트 사용
    ```cs
    인풋이 없는 테스크 만들기
    Task taskInstance = new Task(Action);
    Task taskInstance = new Task(Action, CancellationToken);

    인풋이 있는 테스크 만들기
    Task taskInstance = new Task(Action<T>, T);
    Task taskInstance = new Task(Action<T>, T, CancellationToken);
    ```
1. Func : *리턴이* 있는 델리게이트 사용
    ```cs
    인풋 없지만 아웃풋 있는 테스크 만들기
    Task taskInstance = new Task<T>(Func<TResult>);

    인풋 아웃풋 다있는 테스크 만들기
    Task taskInstance = new Task<T>(Func<T ,TResult>, T);
    ```

**③ 실행하기**

1. 인스턴스화 된 작업 실행하기 : *Task Class*
   ```cs
   taskInstance.Start();
   ```
2. 인스턴스 없이 작업 실행하기 : *테스크를 바로 반환*
    만들고 바로 실행 (성능상 이게 좋다.)
    단, 여기서의 action은 패러미터가 없어야함
    ```cs
    
    var taskInstance = Task.Run(Action, CancelationToken);
    var taskInstance = Task.Run(Func<Task>, CancelationToken);
    var taskInstance = Task<TResult>.Run(Func<Task>, CancelationToken);
    ```

**④ 대기를 통해 완료**
* 동기적 : 인스턴스가 실행을 완료할 때까지 호출 스레드를 차단합니다.

    ```cs
    taskInstance.Wait(); // _Task_ 작업이 몇초가 걸리든 대기하고 완료한다.
    taskInstance.Result;

    taskInstance.Wait(int 32); // _Task_ 작업이 몇초가 걸리든 int32 초만 기다리고 끝낸다.
    taskInstance.Result;
    ```

* 완료를 통해 얻을수 있는 결과/ 정보
    ```cs
    taskInstance.Result; 
    taskInstance.IsCompleted;
    taskInstance.Status;
    ```

* 예시

    ```cs
    // -----------------------------------
    // 2초동안 작업되는 작업
    Task task = Task.Run(()=> Thread.Sleep(2000));
    //-----------------------------------
    task.Wait();
    task.Wait(1000);
    //2초 동안 절전 모드이지만 1초 제한 시간 값을 정의하는 작업을 시작하므로
    //호출 스레드는 시간 제한이 만료될 때까지 및 태스크 실행이 완료되기 전에 차단됩니다.
    //-----------------------------------
    1. 태스크가 다 안끝났다면 기다린다
    2. 다만 태스크 시간안에 끝내지 못하면 완료되기전에 차단한다.
    ```

**⑤ 복수의 테스크들을 대기하는 기법 완료**
***WhenAll & WhenAny*** : 복수 테스크들을 모두 병렬적으로 실행하지만.
1. WhenAll() : Task 배열을 인자로 받는다.
    ```cs
    Task<int>[] tasks = new Task<int>[10];

    for(;;){
        tasks.add(Task.Run(() => {..}));
    }

    /*All*/

    int[] results = await Task.WhenAll(tasks);
    ```
2. WhenAny() : Task 먼저끝난 하나를 인자로 받든다
    ```cs
    List<Task<int>> tasks = new List<Task<int>>();

    for(;;){
        tasks.add(Task.Run(() => {..}));
    }

    /*Any*/

    while(tasks.Any()){
        Task<int> finishedOneTask = await Task.WhenAny();
        results.Add(finishedOneTask.Result);
        tasks.Remove(finishedOneTask); //List 제거
    }
    ```

**⑥ 완료 직후 동기적으로 연결할 명령들**
```cs    
// 이러한 비스무리한 작업을 하고 싶을떄
if(task.IsCompleted == true){
    // 콜백
}
``` 
* **일명 테스크 완료에 따라 실행할 콜백**
  1. 동기적 흐름을 가진 Wait()을 비동기로 실행하기 (쓰레기임 🗑️)
     ```cs
     Task.Run(() => {
        Task taskInstance = new Task();
        taskInstance.Start();
        taskInstance.Wait();
     });
     //근데 근본적으로 Run 조차도 Wait 해야하므로 좋지는 않다.
     ```
  2. ContinueWith() : Javascript에서 콜백 처리하는것과 비슷함     
        ```cs
        taskInstance.ContinueWith(델리게이트 콜백);
        taskInstance.ContinueWith(() =>{...});
        taskInstance.ContinueWith(Action<T>, T);
        taskInstance.ContinueWith<TResult>(Func<TResult>, T);
        taskInstance.ContinueWith(() =>{...}).ContinueWith(()=>{...}).ContinueWith(()=>{...});
        ``` 
  3. Async Await : await 키워드가 붙으면 Task인것을 Task 떼고 결과를 반환해 준다는 의미이다.
        ```cs
        var result = await taskInstance;
        ```


**⑦ 중간 취소**
* OperationCanceledException
    ```cs
    private static int Sum(CancellationToken ct, int n) {
        int sum = 0;
        for (; n > 0; n--) {
            //작업 취소가 요청되면 OperationcanceledException을 
            //innerExceptions로 하는 AgeregateException 발생
            ct. ThrowIfCancellationRequested();
            checked ( sum? += n;) 
        }
        return sum;
    }

    static void Main(string[] args) {
        CancellationTokenSource cts = new CancellationTokenSource();
        Task<Int32> t = Task.Run(() => Sum(cts. Token, 10000000), cts. Token);
        cts.Cancel(); //작업 취소
        try {
            Console.Writeline("The sum is: " + t.Result);
        } 
        catch (AggregateException x) {
        // AggregateException exception handler
        x.Handle (e => e is OperationCanceledException);
        //Operation.. 이면 처리된 것으로
        Console.WriteLine( " Sum was canceled" );
        }
    }
    ```


### 📄 3. IO(인풋-결과물) 중심 Task 작업

#### 사실 비동기의 핵심은 어쨌든 
#### 병렬처리하고 결과를 가져오는거 아님?

완료된 테스크에만 관심이 있다. 그 완료된 테스크를 어떨게 받을 수 있을까?

#### 1). Async Await
![](./img/2023-03-08-19-27-12.png)

**① 직렬적 : 동기적으로 실행결과 받아오기**
이거.. 병렬된게 아니라 동기실행하는것 사실 체이닝 되는거야
 *A -> B -> C -> D*
```cs
void functionAsync(){
    await DownloadAsync(A);
    await DownloadAsync(B);
    await DownloadAsync(C);
    await DownloadAsync(D);
}
```
마치 다음과 같다.
```cs
void functionAsync(){
    taskInstance
        .ContinueWith(t=>{DownloadAsync.Invoke(A))
        .ContinueWith(t=>{DownloadAsync.Invoke(B))
        .ContinueWith(t=>{DownloadAsync.Invoke(C))
        .ContinueWith(t=>{DownloadAsync.Invoke(D)).Wait();
}
```

**② 병렬적 : 즉 A,B,C,D 독립적으로 실행 결과를 받아오려면?**
```cs
void functionAsync(){
    await DownloadAsync(A).ConfigureAwait(false);;
    await DownloadAsync(B).ConfigureAwait(false);;
    await DownloadAsync(C).ConfigureAwait(false);;
    await DownloadAsync(D).ConfigureAwait(false);;
}
```
* ConfigureAwait
  * 작업에 대해 ConfigureAwait(true)를 호출하는 것은 명시적으로 ConfigureAwait를 호출하지 않는 것과 동작이 같습니다. 이 메서드를 명시적으로 호출하여 원래 동기화 컨텍스트에서 의도적으로 연속을 수행하려는 것임을 판독기에 알립니다.
  * 작업에 대해 ConfigureAwait(false)를 호출하여 스레드 풀에 대한 연속을 예약함으로써 UI 스레드에서의 교착 상태를 방지합니다. 앱과 관계없는 라이브러리의 경우 false를 전달하는 것이 좋은 옵션이 됩니다


#### 예시
<details>
   <summary style="cursor:pointer; text:bold"><b>📂1. 동기적인 아침준비📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
   ```cs
using System;
using System;
using System.Threading.Tasks;

namespace AsyncTaskExample_1
{
    // These classes are intentionally empty for the purpose of this example. They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
    internal class Bacon { }
    internal class Coffee { }
    internal class Egg { }
    internal class Juice { }
    internal class Toast { }

    public class Program_NoTask
    {
        /*
        static void Main(string[] args)
        {
            Console.WriteLine("Progrma No Task : Takes 30");
            
            Coffee cup = PourCoffee();
            Console.WriteLine("coffee is ready");
            
            Egg eggs = FryEggs(2);
            Console.WriteLine("eggs are ready");

            Bacon bacon = FryBacon(3);
            Console.WriteLine("bacon is ready");

            Toast toast = ToastBread(2);
            ApplyButter(toast);
            ApplyJam(toast);
            Console.WriteLine("toast is ready");

            Juice oj = PourOJ();
            Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }
        */
        static Bacon FryBacon(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            Task.Delay(3000).Wait();
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
        private static Egg FryEggs(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            Task.Delay(3000).Wait();
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }
        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static Toast ToastBread(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            Task.Delay(3000).Wait();
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }
    }
}
   ```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂2. 비동기적인 아침준비📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Threading.Tasks;

namespace AsyncTaskExample_1
{
    public class Program_Task_List
    {
        // These classes are intentionally empty for the purpose of this example.
        // They are simply marker classes for the purpose of demonstration, contain no properties, and serve no other purpose.
        internal class Bacon { }
        internal class Coffee { }
        internal class Egg { }
        internal class Juice { }
        internal class Toast { }

        static async Task mainOne() {
            Console.WriteLine("Progrma No Task : Takes 20");

            Coffee cup = PourCoffee();
            Console.WriteLine("##################### coffee is ready #####################");

            //FryEggs 함수와 FryBacon 함수와 ToastBread 함수를 각각 실행하고, 비동기 작업을 Task 클래스에 저장한다.
            var eggsTask = FryEggsAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            // * 토스트를 구운 다음에는 반드시 버터와 잼을 발라야 한다는 사실을 깨달을 수 있다. 그렇다면 토스트를 굽고 버터와 잼을 바르는 단계를 하나의 메서드로 구현해보자.
            // Toast toast = await toastTask; //결과가 필요할 때에 await 연산자를 사용해 작업이 완료되어 결과가 반환되기를 기다린다. 
            // ApplyButter(toast);
            // ApplyJam(toast);


            Juice oj = PourOJ();
            Console.WriteLine("##################### oj is ready #####################");

            Egg eggs = await eggsTask; //결과가 필요할 때에 await 연산자를 사용해 작업이 완료되어 결과가 반환되기를 기다린다. 
            Console.WriteLine("##################### eggs are ready #####################");

            Bacon bacon = await baconTask; //결과가 필요할 때에 await 연산자를 사용해 작업이 완료되어 결과가 반환되기를 기다린다. 
            Console.WriteLine("##################### bacon is ready #####################");

            Toast toast = await toastTask; //이제 전과 달리, 토스트 두 조각 모두 굽는 걸 기다릴 필요없이 바로 계란 후라이를 요리할 수 있고 토스트가 완성되면 그 때 버터와 잼을 바를 수 있다.
            Console.WriteLine("##################### toast is ready #####################");

            Console.WriteLine("##################### Breakfast is ready! #####################");
        }

        static async Task mainSecond() {
            Coffee cup = PourCoffee();
            Console.WriteLine("Coffee is ready");

            var eggsTask = FryBaconAsync(2);
            var baconTask = FryBaconAsync(3);
            var toastTask = MakeToastWithButterAndJamAsync(2);

            var allTasks = new List<Task> { eggsTask, baconTask, toastTask };
            //예제 코드는 모든 비동기 작업을 실행시킨 뒤, while 문 내에서 Task.WhenAny를 사용해 전체 비동기 작업 중 하나라도 완료되길 await 한다.
            while (allTasks.Any()) {
                Task finished = await Task.WhenAny(allTasks);

                if (finished == eggsTask) {
                    Console.WriteLine("eggs are ready");
                }
                else if (finished == baconTask) {
                    Console.WriteLine("bacon is ready");
                }
                else if (finished == toastTask) {
                    Console.WriteLine("toast is ready");
                }
                allTasks.Remove(finished);
            }
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello");
            //await mainOne();
            await mainSecond();
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");

            Console.WriteLine("cooking first side of bacon...");

            await Task.Delay(3000);

            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }

            Console.WriteLine("cooking the second side of bacon...");

            await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);

            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }
    }
}
```
</details>

#### 2). 비동기 루프
```js
async function processArray(arr){
    arr.forEach(async item => {
        await func(item);
    });
}
```

```js
async function processArray(array) {
    for(const item of array){
        await delayLog(item);
    }
    console.log("Done!");
}
```

#### 3). Async는 언제 끝나는건가?
*
    ```cs
    staitc void Main(){
        Test();
    }

    async static void Test(){
        await AsyncFunction();
    }
    ```

### 참조

[가장 많은 도움을 받은 블로그 : 에로로](https://blog.naver.com/vactorman/220340602523)

https://www.youtube.com/watch?v=ZUqUlZ3GjlA

https://www.youtube.com/watch?v=CrUrvVatAxo

https://learn.microsoft.com/ko-kr/dotnet/api/system.threading.tasks.task?view=net-7.0

https://steady-coding.tistory.com/548


https://velog.io/@jinuku/C-async-await%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%98%EC%97%AC-%EB%B9%84%EB%8F%99%EA%B8%B0%EB%A5%BC-%EB%8F%99%EA%B8%B0%EC%B2%98%EB%9F%BC-%EA%B5%AC%ED%98%84%ED%95%98%EA%B8%B0-1

https://ibocon.tistory.com/89

https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/

https://stackoverflow.com/questions/14658001/cannot-implicitly-convert-type-string-to-system-threading-tasks-taskstring

https://www.youtube.com/watch?v=PwoF8jsCUtM


https://velog.io/@ksh4820/asyncawait%EB%A5%BC-%EC%9D%B4%EC%9A%A9%ED%95%B4-loop-%EB%8B%A4%EB%A3%A8%EA%B8%B0

https://velog.io/@hanameee/%EB%B0%B0%EC%97%B4%EC%97%90-%EB%B9%84%EB%8F%99%EA%B8%B0-%EC%9E%91%EC%97%85%EC%9D%84-%EC%8B%A4%EC%8B%9C%ED%95%A0-%EB%95%8C-%EC%95%8C%EC%95%84%EB%91%90%EB%A9%B4-%EC%A2%8B%EC%9D%84%EB%B2%95%ED%95%9C-%EC%9D%B4%EC%95%BC%EA%B8%B0%EB%93%A4

https://www.youtube.com/watch?v=3GhKdDCvtKE&list=PLOeFnOV9YBa43HKvIhBUMK6UhSjP2kizx&index=7
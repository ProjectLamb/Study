using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AsyncTaskExample_2
{
	public class Program
	{
		static void Main() {
            JustWait();
			//TaskFunc1();
            //TaskFunc2();
            //TaskFunc3();
        }

        static async void JustWait() {
            Console.WriteLine("5초카운트");
            await Task.Delay(5000);
            Console.WriteLine("5초가 지났음");
        }

		static void TaskFunc1() {
            Action<object> action = (object obj) =>
            {
                Console.WriteLine($"/// Task : {Task.CurrentId} : Thread : {Thread.CurrentThread.ManagedThreadId} ///");
                Console.WriteLine("Hello Task : {0}", obj);
            };

            Action nullaction = () =>
            {
                Console.WriteLine($"/// Task : {Task.CurrentId} : Thread : {Thread.CurrentThread.ManagedThreadId} ///");
                Console.WriteLine("Hello Task : null");
            };

            Task.Run(nullaction); //null 

            //
            Task t1 = new Task(action, "alpha");
            t1.Start();

            Task t2 = Task.Run(() => {
                Console.WriteLine($"/// Task : {Task.CurrentId} : Thread : {Thread.CurrentThread.ManagedThreadId} ///");
                Console.WriteLine("Hello Task : {0}", "delta");
            });
            t1.Wait();

            Task t3 = new Task(action, "beta");
            // 기껏 병렬 만들었지만 작업 인스턴스를 순차실행하고 싶을때를 대비해 만든 실행
            t3.RunSynchronously();
            t3.Wait();
        }

        static void TaskFunc2() {
            // Wait on a single task with no timeout specified.
            // Thread Sleep은 Wait이 되어야지 느껴진다.
            Task taskA = Task.Run(() => Thread.Sleep(2000)); //2초동안 작업되는 어떤 작
            Console.WriteLine("taskA Status: {0}", taskA.Status);
            try
            {
                taskA.Wait();
                Console.WriteLine("taskA Status: {0}", taskA.Status);
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }
        }

        static void TaskFunc3() {
            Task taskA = Task.Run(() => Thread.Sleep(2000)); //똑같이 2초동안 작업되는 작업이 있다.
            try
            {
                taskA.Wait(1000);       // Wait for 1 second. 즉 2초동안 작업이든 뭐든지간에 1초만 기다린다
                bool completed = taskA.IsCompleted;
                //2초 동안 절전 모드이지만 1초 제한 시간 값을 정의하는 작업을 시작하므로
                //호출 스레드는 시간 제한이 만료될 때까지 및 태스크 실행이 완료되기 전에 차단됩니다.
                Console.WriteLine("Task A completed: {0}, Status: {1}",
                                 completed, taskA.Status);
                if (!completed)
                    Console.WriteLine("Timed out before task A completed.");
            }
            catch (AggregateException)
            {
                Console.WriteLine("Exception in taskA.");
            }
        }
    }
}


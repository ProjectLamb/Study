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

            var eggsTask = FryEggsAsync(2);
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
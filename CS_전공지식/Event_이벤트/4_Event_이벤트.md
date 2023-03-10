---
ebook:
  theme: one-dark.css
  title: 이벤트지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #D8D241; border-left: 5px solid #D8D241; border-right: 5px solid #D8D241; background-color: #D8D241; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #C4B000 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>


## 💡 4-2 Event 소개
#### 이벤트를 발생시키면 그 이벤트에대해 반응한다.

### 📄1. 용어정리

1. Publisher(Sender, raise) : 이벤트를 정의하고 일으키는 주체인 클래스다.
2. Subscriber(receiver, eventhandler) : 이벤트 발생시 작동하는 동작
3. Client : Publisher, Subscriber 둘다 아니지만, 이 두개를 연결(구독)시키는 "코드.cs"

### 📄 2. Eventhandler & Event & EventArgs

#### 1). Eventhandler

*\#Subscriber \#Method \#이벤트 직후 반응하는 함수*

**일단 함수다.** 

**① 형태, 구성요소**

* 
    ```cs
    public void HandlerFunction(object sender, EventArgs e){
        /*...*/
    }
    ```
* 이벤트 핸들러라면 다음과 같이 구성되어있다.
    1. 반환은 void형 함수.
    2. object Sender : **Publisher(sender, raise) 객체**를 받는 패러미터다.
    3. EventArgs : 이벤트를 Invoke, Raise 한쪽에서 넘어온 **이벤트 데이터 객체**

#### 2). Event

*\#발생시키는것 \#Notifiy하는것 \#Alert하는것*

일단 **델리게이트다**(함수를 담는 타입이다.) <sub>*함수를 담는다니 뭘 담는거임??*</sub> 바로 **Eventhandler**이다.

* 
    ```
    "메뉴 아이콘을 클릭" 했더니 "메뉴창이 켜졌다." 라는 예제가 있다.
    일어난 이벤트에대해 Handle할 동작("메뉴창이 켜졌다.")함수를 담는다.
    ```

**① 이벤트 생성** : 위 아래는 동일한거다.

* 
    ```cs
    event EventHandler someEvent;
    deletate void EventHandler<Evnetargs>(object? sender, Eventargs e) someEvent;
    ```

**② 이벤트 일으키기**
1. 넘겨주고 싶은 데이터가 없이, 그냥 Invoke만 해도 장땡일때
    ```cs
    someEvent?.Invoke(this, Eventargs.empty);
    someEvent(this, Eventargs.empty);
    ```
2. 넘겨주고싶은 데이터가 있을때. 꼭 Eventargs 타입으로 전달해야한다.
    ```cs
    Eventargs args = new Eventargs(...);
    
    someEvent?.Invoke(this, args);
    someEvent(this, args);
    
    ?. 연산자를 사용하면 해당 이벤트에 null 처리가 쉽다.
    ```
**③ 이벤트 구독과 구독취소**

*
    ```cs
    1. "someEvent"라는 이벤트에 따라 실행시키고 싶은 함수 "HandlerFunction"이 있을떄.  
        //a). event EventHandler someEvent;
        //b). void HandlerFunction(object sender, EventArgs e){ /*...*/ }

    2. 이 두개를 연결(구독)해주는 작업은 다음과 같다.
        someEvent += handlerFunction(); 

    3. 이 두개간 연결을 취소(구독 취소)하는 작업은 다음과 같다.
        someEvent -= handlerFunction();
    ```

#### 3). EventArgs

**EventArgs는 이벤트 일으킬때 넣었던 args 매개변수다.**
  * 굳이 매개변수를 전달 안하고 싶을떄 ```EventArgs.empty```

**① 이벤트 데이터 객체를 내마음대로 정의하기**
* 넘겨 받을 이벤트 데이터 객체를 커스터마이징 할 수도 있다,
    ```cs
    class CustomEventArgs : EventArgs {
        public T Data1 {get; set;}
        public T Data2 {get; set;}
                    : 
        public T DataN {get; set;}

        public CustomEventArgs(T Data1, T Data2, ... ,T DataN){
            /*...*/
        }
    }
    ```
* 이 EventArgs에 따라서 다양하게 이벤트 선언이 가능하다. (위에 이미 있었지만 다시 복습하는겸 작성했다.)
    ```cs
    퍼블리셔 게시클래스 선언 종류
    일반).  event EventHandler someEvent;
    커스텀). event EventHandler<CustomEventArgs> someCustomEvent;

    일반). delegate void EventHandler<Eventargs>(object? sender, Eventargs e) someEvent
    커스텀). delegate void CustomEventHandler(object? sender, CustomEventArgs e) someCustomEvent;
    ```

### 📄 3. Publisher & Subscriber & Client

#### 1). Publisher(Sender, raise)

*\#publisher \#sender \#raise \#게시클래스*

**클래스다.**

* 이 클래스는 다음 특징을 가진다.
    1. rasie : 이벤트를 Invoke, ***"방장이 방송을 시작한다."***
    2. publish(send) : 실행된 이벤트를 ***"구독자(리시버, 핸들러)에게 알림"*** 을 보낸다.
* 이 클래스는 다음으로 구성되어 있다.
    1. Event-EventHandler   : 이벤트를 생성하고, 핸들러(함수)를 대입시킨다.
    2. EventInvoker(Emitter) : 이벤트를 일으키는 기능 제공
    3. 구독과 구독취소 : Client가 사용할 수 있도록 구독과 구독취소 기능을 제공
       * 이벤트 구독에 대해서 (+, -) 연산자 쓰지만, 프로퍼티를 이용해서 다음과 같이 정의도 가능
        ```cs
        //새 이벤트 처리기 메서드를 추가하거나 제거하기 전에 이벤트를 잠그는 것이 좋습니다.
        event EventHandler IDrawingObject.OnDraw
        {
            add {
                lock (objectLock) { PreDrawEvent += value; }
            }
            remove {
                lock (objectLock) { PreDrawEvent -= value; }
            }
        }
        ```


#### 2). Subscriber(receiver, eventhandler)
*\#receiver \#handler \#메서드*

**다른 클래스가 가지고 있는 메서드다. 함수다.**

* 이 함수는 다음과 같은 특징을 가진다.
    1. subscribe(receive) : 방장을 ***"구독하고 알림을 받을준비"*** 를 한다.
    2. eventhandler : 알림을 받고 행동을 취한다. ***"방송에 입장한다."***
* 이 함수는 다음으로 구성되어있다.
    1. 누가 Publisher(sender) 인지 데이터
    2. 이벤트에 의해 전달받은 데이터 

#### 3). Client

Publisher, Subscriber 둘다 아니지만, **이 두개를 연결(구독)시키는 "코드.cs"**

* Publisher Subscriber 구독 & 구독 취소


#### 4). 예시 코드 (메시지 보내기)

<details>
   <summary style="cursor:pointer; text:bold"><b>📂1. 커스텀 이벤트 데이터📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;

using EventDrivenExample_3;

public class CustomEventArgs : EventArgs
{
	public CustomEventArgs(string _message) {
		Message = _message;
	}

	public string Message { get; set; }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂2. 발행자(Publisher)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
namespace EventDrivenExample_3;

class Publisher
{
    //이벤트 변수
    public event EventHandler<CustomEventArgs> RaiseCustomEvent;

    public void DoSomething() {
        EmitCustomEvent(new CustomEventArgs("Event triggered"));
    }
    protected virtual void EmitCustomEvent(CustomEventArgs e) { 
        //동기화 문제로 (Race Condition) 꼭 이벤트에대한 Temporary 이벤트 변수를 만들어야 한다.
        //그리고 null 체크를 통해 핸들러가 있는지 확인한. 
        EventHandler<CustomEventArgs> raiseEvent = RaiseCustomEvent;

        // Event will be null if there are no subscribers
        if (raiseEvent != null)
        {
            e.Message += $" at {DateTime.Now}";
            raiseEvent(this, e); // Call to raise the event.
        }
    }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂3. 구독자(Subscriber)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Security.Cryptography;

using EventDrivenExample_3;

class Subscriber
{
    private readonly string mId;

    public Subscriber(string _id, Publisher _pub) {
        mId = _id;
        _pub.RaiseCustomEvent += HandleCustomEvent;
    }

    void HandleCustomEvent(Object sender, CustomEventArgs e) {
        Console.WriteLine($"{mId} received this message: {e.Message}");
    }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂4. 클라이언트(Client)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using EventDrivenExample_3;

class Program
{
    static void Main()
    {
        var pub = new Publisher();
        var sub1 = new Subscriber("sub1", pub);
        var sub2 = new Subscriber("sub2", pub);

        pub.DoSomething();

        Console.WriteLine("Press any key to continue");
        Console.ReadLine();
    }
}
```
</details>

### 📄 4. 파생 클래스에 이벤트
#### 파생 클래스에서도 발생할 수 있도록 기본 클레스에서 이벤트 선언

파생 클래스에서는 기본 클래스 내에서 선언된 이벤트를 직접호출할 수 없다
그러면 파생클래스에서 어떨게 기본클래스 이벤트를 호출할 수 있을까?

1. 이벤트를 래핑하는 기본 클래스에서 보호된 호출 메서드를 만들어야한다.
2. 그리고 Override 하여 재정의한다면 간접적으로 이벤트 호출이 가능하다
3. 기본 클래스에서 가상 이벤트를 선언하지 말고 파생 클래스에서 재정의합니다.

#### 예시 코드 (도형 그리기)
<details>
   <summary style="cursor:pointer; text:bold"><b>📂1. 커스텀 이벤트 데이터📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
namespace EventDrivenExample_5
{
	public class ShapeEventArgs : EventArgs
	{
		public ShapeEventArgs(double area) { NewArea = area; }
		public double NewArea { get; }
	}
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂2. 도형 클래스 : 발행자(Publisher)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
namespace EventDrivenExample_5
{
	public abstract class Shape
	{
		protected double mArea;

		public double Area {
			get => mArea;
			set => mArea = value;
		}

		public event EventHandler<ShapeEventArgs> ShapeChangedEvnet;

		public abstract void Draw();

		protected virtual void OnShapeChanged(ShapeEventArgs _e) {
			ShapeChangedEvnet?.Invoke(this, _e);
		}
	}

	public class Circle : Shape {
		private double mRadius;

		public Circle(double _radius) {
			this.mRadius = _radius;
			mArea = Math.PI * _radius * _radius;
		}

		public void Update(double _d) {
			this.mRadius = _d;
			mArea = Math.PI * mRadius * mRadius;
			OnShapeChanged(new ShapeEventArgs(mArea));
		}

		protected override void OnShapeChanged(ShapeEventArgs _e) { 
			// Call the base class event invocation method.
			base.OnShapeChanged(_e);
		}

        public override void Draw()
        {
			Console.WriteLine("Drawing a circle");
        }
    }

	public class Rectangle : Shape {
        private double mLength;
        private double mWidth;

		public Rectangle(double _length, double _width) {
			this.mLength = _length;
            this.mWidth = _width;
			mArea = mLength * mWidth;
        }

		public void Update(double _length, double _width)
        {
            this.mLength = _length;
            this.mWidth = _width;
            mArea = mLength * mWidth;
			OnShapeChanged(new ShapeEventArgs(mArea));
        }

        protected override void OnShapeChanged(ShapeEventArgs _e)
        {
            // Call the base class event invocation method.
            base.OnShapeChanged(_e);
        }

        public override void Draw()
        {
            Console.WriteLine("Drawing a ractangle");
        }
    }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂3. 도형 보관함 : 구독자(Subscriber)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
namespace EventDrivenExample_5
{
	public class ShapeContainer
	{
		private readonly List<Shape> mList;
		public ShapeContainer()
		{
			mList = new List<Shape>();
		}

		public void AddShape(Shape _shape) {
			mList.Add(_shape);
            // Subscribe to the base class event.
            _shape.ShapeChangedEvnet += HandleShapeChanged;
        }

		private void HandleShapeChanged(object _sender, ShapeEventArgs _e) {
			if (_sender is Shape shape) {
				Console.WriteLine($"Received event. Shape area is now {_e.NewArea}");

				shape.Draw();
			}
		}
	}
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂4. 클라이언트(Client)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Drawing;

namespace EventDrivenExample_5
{
	public class Test
	{
        static void Main()
        {
            //Create the event publishers and subscriber
            var circle = new Circle(54);
            var rectangle = new Rectangle(12, 9);
            var container = new ShapeContainer();

            // Add the shapes to the container.
            container.AddShape(circle);
            container.AddShape(rectangle);

            // Cause some events to be raised.
            circle.Update(57);
            rectangle.Update(7, 7);

            // Keep the console window open in debug mode.
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
```
</details>


### 📄 5. 인터페이스 이벤트
#### 인터페이스는 사실.. 추상메서드 말고도 인터페이스도 선언할 수 있었다..

클래스에서 인터페이스 이벤트를 구현하는 방법을 보자.

각 인터페이스에는 이름이 같은 이벤트가 있는 상황을 처리해준다.
Circle도 ShapeChanged가 있으며
Ractangle도 ShapeChanged가 있다.

고유한 접근자를 제공하면 클래스에서 두 이벤트를 같은 이벤트로 표시할지 아니면 다른 이벤트로 표시할지를 지정할 수 있습니다. 
예를 들어 인터페이스 사양에 따라 이벤트가 서로 다른 시간에 발생해야 하는 경우에는 각 이벤트를 클래스의 개별 구현과 연결할 수 있습니다.

<details>
   <summary style="cursor:pointer; text:bold"><b>📂1. 이벤트 인터페이스📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Drawing;

namespace EventDrivenExample_6
{
    public interface IDrawingObject {
        //Raise this event before drawing
        event EventHandler OnDraw;
    }
    public interface IShape {
        //Raise this event after drawing
        event EventHandler OnDraw;
    }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂2. 도형 클래스 : 발행자(Publisher)</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
namespace EventDrivenExample_6
{
	public class Shape : IDrawingObject, IShape{
		event EventHandler preDrawEvent;
		event EventHandler postDrawEvent;

		object objectLock = new Object();

		#region IDrawingObjectOnDraw
		// Explicit interface implementation required.
        // Associate IDrawingObject's event with
        // PreDrawEvent
		event EventHandler IDrawingObject.OnDraw {
			add {
				lock(objectLock) {preDrawEvent += value;}
			}
			remove {
				lock(objectLock) {preDrawEvent -= value;}
			}
		}
		#endregion
		// Explicit interface implementation required.
        // Associate IShape's event with
        // PostDrawEvent
		event EventHandler IShape.OnDraw {
			add {
				lock(objectLock) {postDrawEvent += value;}
			}
			remove {
				lock(objectLock) {postDrawEvent -= value;}
			}
		}
		
		// For the sake of simplicity this one method
        // implements both interfaces.

		public void Draw(){
			preDrawEvent?.Invoke(this, EventArgs.Empty);
			Console.WriteLine("Drawing a shape.");
			postDrawEvent?.Invoke(this, EventArgs.Empty);
		}
	}
}
```
</details>


<details>
   <summary style="cursor:pointer; text:bold"><b>📂3. 구독자(Subscriber)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Drawing;

namespace EventDrivenExample_6
{
    public class Subscriber1
    {
        // References the shape object as an IDrawingObject
        public Subscriber1(Shape shape)
        {
            IDrawingObject d = (IDrawingObject)shape;
            d.OnDraw += d_OnDraw;
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub1 receives the IDrawingObject event.");
        }
    }
    // References the shape object as an IShape
    public class Subscriber2
    {
        public Subscriber2(Shape shape)
        {
            IShape d = (IShape)shape;
            d.OnDraw += d_OnDraw;
        }

        void d_OnDraw(object sender, EventArgs e)
        {
            Console.WriteLine("Sub2 receives the IShape event.");
        }
    }
}
```
</details>

<details>
   <summary style="cursor:pointer; text:bold"><b>📂4. 클라이언트(Client)📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
```cs
using System;
using System.Drawing;

namespace EventDrivenExample_6
{
	public class Test
	{
        static void Main(string[] args)
        {
            Shape shape = new Shape();
            Subscriber1 sub = new Subscriber1(shape);
            Subscriber2 sub2 = new Subscriber2(shape);
            shape.Draw();

            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}
```
</details>
### 📄 참조
https://learn.microsoft.com/ko-kr/dotnet/csharp/events-overview
https://learn.microsoft.com/ko-kr/dotnet/standard/events/
https://learn.microsoft.com/ko-kr/dotnet/standard/asynchronous-programming-patterns/event-based-asynchronous-pattern-eap

https://bora-game-develop-history.tistory.com/6

https://bloodstrawberry.tistory.com/630

https://drehzr.tistory.com/1274 
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

    h2 { border-top: 12px solid #67CCCF; border-left: 5px solid #67CCCF; border-right: 5px solid #67CCCF; background-color: #67CCCF; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #0075C4 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## 💡 2. Event 델리게이트

### 📄 1. 델리게이트란?
> 대리자는 함수를 런타임에 바인딩하는 매커니즘을 제공한다.
> 대리자는 특정 매개 변수 목록 및 반환 형식이 있는 메서드에 대한 참조를 나타내는 형식입니다.
> C++의 함수 포인터와 유사하다. 다만 메서드를 안전하게 캡슐화하는 형식이다.
#### 1). 특징

<div align="center"> 
    <h4>함수를 변수처럼 사용할 수 있다.</h4>
</div>

1. **함수를 담는 타입**(int, float, bool 등등..)을 정의한다. 
   * "Delegate Type"
2. 함수를 담는 *Delegate Type*에 대한 **변수**를 만들 수 있다.
   * "Delegate Instance"
3. 그 변수에 **함수를 대입**할 수 있다.
4. Delegate Type 변수는 **다른 함수의 패러미터**로 사용될 수 있다.
5. Delegate Type **배열**
   * 그말은 즉슨 인덱스에 따라 함수가 달라지게 할 수 있다.
     ```
     DelegateInstance[0] = 인덱스는 공격하기
     DelegateInstance[1] = 인덱스는 점프하기
     DelegateInstance[2] = 인덱스는 이동하기
     ```
6. 하나의 델리게이트로 **각기 다른 함수들을 그룹(래핑)** 시키게 하는 **체이닝** 기법도 가능하다.
7. 비동기 콜백 메서드를 정의할 수 있다.
   * 긴 프로세스 완료 시 호출자에게 알림을 제공하는 일반적인 방법입니다.

#### 2). 왜쓰는건가?
<div align="center"> 
    <h4>함수에 대해 다형성을 부여하는 강력한 문법이다. 재사용성과 확장성을 제공한다.</h4>
</div>

멀티캐스트 대리자는 이벤트 처리에서 광범위하게 사용됩니다. 이벤트 소스 개체는 해당 이벤트를 받도록 등록된 받는 사람 개체에 이벤트 알림을 보냅니다. 
이벤트를 등록하기 위해 받는 사람은 이벤트를 처리하도록 설계된 메서드를 만든 다음 해당 메서드의 대리자를 만들어 이벤트 소스로 전달합니다.

#### 3). 키워드 
\#델리게이트 타입 \#델리게이트 변수 \#함수 대입 \#각기 다른 함수를 그룹(래핑)

### 📄 2. 함수를 담는 타입 : (Delegate types)
#### 1). 델리게이트 Type선언 예시
```cs
public delegate int Comparsion<int T>(T left, T right);

* 여기서 Comparsion은 변수가 아니라 int, float, bool 같은 타입이라고 생각하자.
따라서 위 과정은 타입을 만든것이다.

* 이 Comparsion 타입은 다음과 같은 함수를 받는 타입이다.
    1. 함수의 리턴값이 int여야 한다.
    2. 함수의 매개변수는 T left, T right 같은 패러미터를 받는 함수여야 한다.
```

### 📄 3. Delegate Type 변수 : (Delegate Instance)
#### 1). 델리게이트 변수 만들기 예시
```cs
public Comparsion<T> comp;

* 여기서 comp는 Comparsion은 타입 변수다.
```

##### 이 델리게이트 변수는 함수처럼 사용될 수 있다.

### 📄 4. 변수(Delegate Instance)에 함수 대입 : (Invoke delegates)
#### 1). 델리게이트 변수에 함수 대입 예시
```cs
int compareFunction(string left, string right) {
     if      (left < right)  return -1;
     else if (left == right) return 0;
     else                    return 1;
}
* left.Length.CompareTo(right.Length); 와 동일함

comp = new Comparsion(compareFunction());
int result = comp;
```

#### 2). 델리게이트 람다함수 대입 예시
```cs
 public Comparsion<T> comp = (left, right) => { 
     left.Length.CompareTo(right.Length);
 }
```

### 📄 5. 대리자 배열
#### 1). 대리자를 배열처럼 사용하는 예시
```cs
delegate int intOp(int a, int b);

public static int Add(int a, int b) {return a + b;}
public static int Mul(int a, int b) {return a * b;}

intOp[] arOp = new intOp(2);
arOp[0] = Add; arOp[1] = Mul;

int num1 = 10, num2 = 29;

int addResult = arOp[0](10, 20);
int mulResult = arOp[1](10, 20);
```

### 📄 6 대리자 타입을 패러미터로 사용
#### 1). 함수의 인풋을 대리자 타입으로 해보자.
 ```cs
 1. 대리자 타입 만들기
 delegate bool Compare<T>(T left, T right);

 1. 대리자 타입에 넣을수 있는 "그냥" 함수
 static bool lessFunction(int left, int right) {return l > r;}
 static bool greaterFunction(int left, int right) {return l < r;}

 1. 대리자 변수 선언 & 함수 대입
 static Compare<int> less = new Compare<int>(lessFunction);
 static Compare<int> greater = new Compare<int>(greaterFunction);

 1. 대리자 타입을 패러미터로 사용하는 정렬함수
    * 여기서는 Compare 함수에 따라서 오름차순, 내림차순 결정
 static Sort(Compare<int> _c){
      /*대충 삽입 정렬*/
 }

 static void Main(){
      Sort(less);
      * 오름차순 : 1 2 3 4 5 6 7
      Sort(greater);  
      * 내림차순 : 7 6 5 4 3 2 1
 }
 ```

<details>
   <summary style="cursor:pointer; text:bold"><b>📂상세 펼치기 : Comp함수를 전달해 삽입정렬📂</b></summary>

   <!-- summary 아래 한칸 공백 두어야함 -->
 ```cs
using System;

namespace DelegateExample
{

    public delegate bool Compare<T>(T left, T right);
    class Program
    {

        static bool lessFunction(int left, int right) { return left > right; }
        static bool greaterFunction(int left, int right) { return left < right; }

        static Compare<int> less = new Compare<int>(lessFunction);
        static Compare<int> greater = new Compare<int>(greaterFunction);

        static List<int> L = new List<int>();
        static void Insertion(Compare<int> _C)
        {
            int insertNum = 0;
            for (int sortedSize = 1; sortedSize < L.Count; sortedSize++)
            {
                insertNum = L[sortedSize];
                int searchStart = sortedSize;
                while (searchStart > 0 && !_C(L[searchStart-1] ,insertNum)) {
                    L[searchStart] = L[searchStart-1];
                    searchStart--;
                }
                L[searchStart] = insertNum;
            }
        }

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++) {
                Console.WriteLine($"ADD : {args[i]}");
                L.Add(int.Parse(args[i]));
            }

            Insertion(less);

            foreach (int E in L) {
                Console.Write(E + " ");
                Console.WriteLine();
            }


            Insertion(greater);

            foreach (int E in L)
            {
                Console.Write(E + " ");
                Console.WriteLine();
            }
        }
    }
}
 ```
</details>

### 📄 7 델리게이트 체인 (Multicast Delegates)
#### 1). 하나의 대리자로 "여러개의 함수를 그룹(래핑)화" 시키는 예시
```cs
delegate void ThereIsAFire(string location);

void Call119(string location)
{
   Console.WriteLine("소방서죠? 불났어요! 주소는 {0}", location);
}

void ShoutOut(string location)
{
   Console.WriteLine("피하세요 {0}에 불이 났어요!", location);
}

void Escape(string location)
{
   Console.WriteLine("{0}에서 나갑시다!", location);
}

1. + 연산자로 델리게이트 체이닝
ThereIsAFire Fire = new ThereIsAFire(Call119)
                 + new ThereIsAFire(ShoutOut)
                 + new ThereIsAFire(Escape);

1. 델리게이트 객체의 Combine을 통해 델리게이트 체이닝           
ThereIsAFire Fire = (ThereIsAFire) Delegate.Combine(
                       new ThereIsAFire(Call119),
                       new ThereIsAFire(ShoutOut),
                       new ThereIsAFire(Escape)
                   );
```

#### 2). 객체 매서드를 "그룹(래핑)화" 시키는 예시
```cs
var obj = new MethodClass();
Del d1 = obj.Method1; Del d2 = obj.Method2;

void DelegateMethod() {...}
Del d3 = DelegateMethod;

//Both types of assignment are valid.
Del allMethodsDelegate = d1 + d2;
allMethodsDelegate += d3;
```

#### 3). 반대로 호출 목록에서 메서드를 제거하려면 - 또는 -=를 사용합니다.

### 📄 같이 읽어볼 사실
#### 1). Delegate 및 MulticastDelegate 클래스
1. delegate 한정자는 Delegate 및 MulticastDelegate를 기반으로 빌드됩니다.
2. 모든 대리자는 MulticastDelegate에서 파생된다.

### 3. Invoke & BeginInvoke / EndInvoke
https://m.blog.naver.com/isaac7263/222162479809
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


## 💡 3. Event Action & Func

### 📄 1. Action 대리자
> 리턴값이없는 프로스저를 캡슐화 하는대리자를 정의한다.

<div align="center">
  <h4>즉, 리턴값이 없는 함수를 대리자 사용하고 싶으면? Action Type을 사용하면 된다.</h4>
</div>

#### 1). Action 대리자 종류
**① Action 대리자는 다음 종류가 있다.**
1. 리턴도, 매개변수도 없는 대리자 
   * ```Action _DelegateInstance_```
2. 매개변수 하나정도 있는 대리자 
   * ```Action<T type> _DelegateInstance_```
3. 매개변수 N개 있는 대리자 
   * ```Action<T1, T2, .... T16> _DelegateInstance_```
![](2023-02-03-12-25-43.png)
### 📄2. Action
#### 1). Action 사용 안했을때,
```cs
public delegate void Del();

public static HelloWolrd() {
  Console.WriteLine("Hello World!");
}

public static void Main() {
  Del delInstance = HelloWorld;
  delInstance();
}
```

#### 2). Action 사용했을떄.

```cs
public static HelloWolrd() {
  Console.WriteLine("Hello World!");
}

public static void Main() {
  Action delInstance = HelloWorld;
  delInstance();
}
```

#### 3). 익명함수까지 사용했을때.

```cs
public static void Main() {
  Action delInstance = () => Console.WriteLine("Hello World!");
  delInstance();
}
```

### 📄 3. Func 대리자
> 리턴값이 있는 프로스저를 캡슐화 하는대리자를 정의한다.

<div align="center">
  <h4>즉, 리턴값이 있는 함수를 대리자 사용하고 싶으면? Func Type을 사용하면 된다.</h4>
</div>

#### 1). Func 대리자 종류
**① Func 대리자는 다음 종류가 있다.**

1. 매개변수가 없는 대리자 
   * ```Func<out TResult> _DelegateInstance_```
2. 매개변수 하나정도 있는 대리자 
   * ```Action<T type, out TResult> _DelegateInstance_```
3. 매개변수 N개 있는 대리자 
   * ```Action<T1, T2, .... T16, out TResult> _DelegateInstance_```

### 📄 4. Func 
#### 1). Func 사용 안했을때,
```cs
public delegate string Del();

public static string HelloWolrd() {
  return "Hello World!";
}

public static void Main() {
  Del delInstance = HelloWorld;
  Console.WriteLine(delInstance);
}
```

#### 2). Action 사용했을떄.

```cs
public static string HelloWolrd() {
  return "Hello World!";
}

public static void Main() {
  Func<string> delInstance = HelloWorld;
  Console.WriteLine(delInstance);
}
```

#### 3). 익명함수까지 사용했을때.

```cs
public static void Main() {
  Func<string> delInstance = () => {return "Hello World!";}
  Console.WriteLine(delInstance);
}
```
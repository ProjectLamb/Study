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

## 💡 3. Event Action 대리자

### 📄 1. Action 대리자
> 리턴값이없는 프로스저를 캡슐화 하는대리자를 정의한다.

<div align="center">
  <h4>즉, 리턴값이 없는 함수를 대리자 사용하고 싶으면? Action Type을 사용하면 된다.</h4>
</div>

#### 1). Action 대리자 종류
**① Action 대리자는 다음 종류가 있다.**
1. 리턴도, 매개변수도 없는 대리자 ```Action _DelegateInstance_```
2. 매개변수 하나정도 있는 대리자 ```Action<T type> _DelegateInstance_```
3. 매개변수 N개 있는 대리자 ```Action<T1, T2, .... T16> _DelegateInstance_```
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
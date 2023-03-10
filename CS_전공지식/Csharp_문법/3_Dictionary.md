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

    h2 { border-top: 12px solid #bf8bff; border-left: 5px solid #bf8bff; border-right: 5px solid #bf8bff; background-color: #bf8bff; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #5b0d7c !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## 🧑🏻‍💻 1. Dictionary
---

#### key를 통해 value를 가져오는 자료구조 마치 해쉬테이블 같다.
Dictionary의 key와 value는 Generic으로 선언 가능하다.
기본 타입뿐만 아니라, 리스트 등 다양한 자료구조, 클래스등 다된다.

---

### 📄 2. 사용법
#### 1). 딕셔너리 생성

```cs
using System;
using System.Generic;
using System.Collection.Generic;

Dictionary<T Key, T Value> _dictionary = new Dictionary<T Key, T Value>();

> 예시
Dictionary<string, string> openWith = new Dictionary<string, string>();
```

---

#### 2). 엘리먼트 추가
```cs
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");
openWith.Add("jpg", "image.jpg");

openWith["md"] = "notion.exe"; //키 add 안해도 자동 추가된다.
```

---

#### 3). 값 접근

**① 일반적인 접근**

1. 
    ```cs
    string A = openWith["txt"];
    openWith["txt"] = "vscode.exe";
    ```
2. 안전하게 접근
    ```cs
    dicTest2.TryGetValue("비트", out mapValue)
    Console.WriteLine(mapValue);
    ```

#### 3-1). Key를 검색하는 방법 (key 할당 상태 확인)
```cs
if(openWith.ContainsKey(str).Equals(true)) {
    Console.WriteLine("{0}은(는) 이미 Key로 사용되고 있습니다.", str);
} 
else {
    Console.WriteLine("{0}은(는) Key로 사용되지 않고 있습니다.", str);
}
```

#### 3-2). Value를 검색하는 방법 (value 할당 상태 확인)
```cs
if(myTable.ContainsValue(str).Equals(true)) {
    Console.WriteLine("{0}은(는) 이미 Key로 사용되고 있습니다.", str);
} 
else {
    Console.WriteLine("{0}은(는) Key로 사용되지 않고 있습니다.", str);
}
```

---

#### 4). 순회

**① 딕셔너리 전부 순회**

```cs
foreach ( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}
```

**② key만 순회**

* 
    ```cs
    foreach(string Key in openWith.Keys) {
        Console.WriteLine(Key);  
    }
    ```

**③ value만 순회**

*
    ```cs
    foreach(string Value in openWith.Values) {
        Console.WriteLine(Value);  
    }
    ```

---

#### 5). 값 삭제
```cs
openWith.Remove("dib"); 
```

---

#### 6). Dictionary 복사
```cs
// 생성자 인수에 원본의 객체를 지정
var openWith2 = new Dictionary<string, string>(openWith);      
```

----

#### 7). Dictionary 정렬
LINQ
```cs
var newTable = openWith.OrderBy(x => x.Value);
var newTable = openWith.OrderBy(x => x.key);
```


#### 8). List와 Dictionary 상호 교환

1. Dictionay -> List
    ```cs
    var kList = new List<string>(myTable.Keys);
    var vList = new List<string>(myTable.Values);
    ```

2. List -> Dictionary
    ```cs
    Dictionary<string, string> myTable = 
            kList.Zip(vList, (k, v) => new { k, v }).ToDictionary(a => a.k, a => a.v);
    ```

https://riucc.tistory.com/602

https://engineer-mole.tistory.com/174


5
1 -1 2
2 -1 3
3 -1 4
4 -1 5
5 -1 -1
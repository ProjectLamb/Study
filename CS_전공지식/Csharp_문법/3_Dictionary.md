---
ebook:
  theme: one-dark.css
  title: ๊ฐ์ฒด์งํฅ
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

## ๐ง๐ปโ๐ป 1. Dictionary
---

#### key๋ฅผ ํตํด value๋ฅผ ๊ฐ์ ธ์ค๋ ์๋ฃ๊ตฌ์กฐ ๋ง์น ํด์ฌํ์ด๋ธ ๊ฐ๋ค.
Dictionary์ key์ value๋ Generic์ผ๋ก ์ ์ธ ๊ฐ๋ฅํ๋ค.
๊ธฐ๋ณธ ํ์๋ฟ๋ง ์๋๋ผ, ๋ฆฌ์คํธ ๋ฑ ๋ค์ํ ์๋ฃ๊ตฌ์กฐ, ํด๋์ค๋ฑ ๋ค๋๋ค.

---

### ๐ 2. ์ฌ์ฉ๋ฒ
#### 1). ๋์๋๋ฆฌ ์์ฑ

```cs
using System;
using System.Generic;
using System.Collection.Generic;

Dictionary<T Key, T Value> _dictionary = new Dictionary<T Key, T Value>();

> ์์
Dictionary<string, string> openWith = new Dictionary<string, string>();
```

---

#### 2). ์๋ฆฌ๋จผํธ ์ถ๊ฐ
```cs
openWith.Add("txt", "notepad.exe");
openWith.Add("bmp", "paint.exe");
openWith.Add("dib", "paint.exe");
openWith.Add("rtf", "wordpad.exe");
openWith.Add("jpg", "image.jpg");

openWith["md"] = "notion.exe"; //ํค add ์ํด๋ ์๋ ์ถ๊ฐ๋๋ค.
```

---

#### 3). ๊ฐ ์ ๊ทผ

**โ  ์ผ๋ฐ์ ์ธ ์ ๊ทผ**

1. 
    ```cs
    string A = openWith["txt"];
    openWith["txt"] = "vscode.exe";
    ```
2. ์์ ํ๊ฒ ์ ๊ทผ
    ```cs
    dicTest2.TryGetValue("๋นํธ", out mapValue)
    Console.WriteLine(mapValue);
    ```

#### 3-1). Key๋ฅผ ๊ฒ์ํ๋ ๋ฐฉ๋ฒ (key ํ ๋น ์ํ ํ์ธ)
```cs
if(openWith.ContainsKey(str).Equals(true)) {
    Console.WriteLine("{0}์(๋) ์ด๋ฏธ Key๋ก ์ฌ์ฉ๋๊ณ  ์์ต๋๋ค.", str);
} 
else {
    Console.WriteLine("{0}์(๋) Key๋ก ์ฌ์ฉ๋์ง ์๊ณ  ์์ต๋๋ค.", str);
}
```

#### 3-2). Value๋ฅผ ๊ฒ์ํ๋ ๋ฐฉ๋ฒ (value ํ ๋น ์ํ ํ์ธ)
```cs
if(myTable.ContainsValue(str).Equals(true)) {
    Console.WriteLine("{0}์(๋) ์ด๋ฏธ Key๋ก ์ฌ์ฉ๋๊ณ  ์์ต๋๋ค.", str);
} 
else {
    Console.WriteLine("{0}์(๋) Key๋ก ์ฌ์ฉ๋์ง ์๊ณ  ์์ต๋๋ค.", str);
}
```

---

#### 4). ์ํ

**โ  ๋์๋๋ฆฌ ์ ๋ถ ์ํ**

```cs
foreach ( KeyValuePair<string, string> kvp in openWith )
{
    Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
}
```

**โก key๋ง ์ํ**

* 
    ```cs
    foreach(string Key in openWith.Keys) {
        Console.WriteLine(Key);  
    }
    ```

**โข value๋ง ์ํ**

*
    ```cs
    foreach(string Value in openWith.Values) {
        Console.WriteLine(Value);  
    }
    ```

---

#### 5). ๊ฐ ์ญ์ 
```cs
openWith.Remove("dib"); 
```

---

#### 6). Dictionary ๋ณต์ฌ
```cs
// ์์ฑ์ ์ธ์์ ์๋ณธ์ ๊ฐ์ฒด๋ฅผ ์ง์ 
var openWith2 = new Dictionary<string, string>(openWith);      
```

----

#### 7). Dictionary ์ ๋ ฌ
LINQ
```cs
var newTable = openWith.OrderBy(x => x.Value);
var newTable = openWith.OrderBy(x => x.key);
```


#### 8). List์ Dictionary ์ํธ ๊ตํ

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
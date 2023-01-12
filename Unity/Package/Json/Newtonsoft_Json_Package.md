# Unity Json

---

## 목차

1. #### [Json 설명](#1-json-설명)

2. #### [C# 객체 팁](#c-객체-팁)

3. #### [NewtonSoft.json](#newtonsoftjson)

---

## 🟢 1.Json 설명 🟢

### 1. Json이 뭔데 ❔

**J**ava**S**cript **O**bject **N**otation

* 자바스크립트 객체 표현식이다.
* **key - value** 로 구성된 점에서 해시 테이블 자료구조랑 비슷하다

    ```json
    { 
        key : value, 
        :
    }
    ```

    ```json
    {
      "id":"1",
      "date":"2002-12-07",
      "number":[10,23,29,33,37,40],
      "bonus":16
    }
    ```

### 2. 왜 쓰는건가? 🤔

#### 장점 👍

* **1. 직렬화 (Serialize) & 역직렬화 가능하다**

    1. 직렬화 : 
    객체를를 **문자열** or Byte 데이터로 변환하는것
    *그럼 직렬화는 왜하는거지..*
       * 객체를 문자열로 저장하고 (파일이든, DB든), 전송하기 (데이터를 주고 받기) 위해
         * *네트워크에서도 http 전송할때 사용하는 형식들중 json을 사용한다.*

    2. 역직렬화 :
    직렬화의 반대과정
    .json으로 된것을 불러올 수 있다.

* **2. json은 언어의 장벽이 없다**

  * Json형식의 데이터는 거희 모든 언어에서 지원하기 때문에. <br> 타 언어간 데이터를 주고받을때 유용하다

  * 예시

    ```text
    1. 
         * A 와 B 컴퓨터가 있다
         * 이둘은 언어, OS, 하드웨어가 전부 다르다
         * 하지만 이 둘은 Byte 데이터를 사용한다는 공통점이 있다.
         * Json으로 직렬화 된 데이터가 있다면 데이터를 주고받을수 있다
    2. 
         * 브라우저(Javascript)와 서버(Java or C#)간 데이터 교한
    ```

---

## 🟢 C# 객체 팁 🟢

### 1. 객체 생성시, 중괄호 초기화

1. class 중괄호 연산자.

    ```cs
    class Data{
        public string name;
        public int level;
        public bool skill;
    }

    public class Test : M
    {
        Data player = new Data() {name : "abc", level = 10, skill = false} 
    }
    ```

2. struct 중괄호 초기화
    
    ```cs
    struct TempData
    {
        int StationId;
        time_t timeSet;
        double current;
        double maxTemp;
        double minTemp;
    };

    public class
    ```
* 생성자 정의 가능
* new 연산자를 이용해 객체 생성 가능
------------------------

## 🟢 [NewtonSoft.json](https://www.newtonsoft.com/json) 🟢

![](./img/2022-12-01-17-42-16.png)
> 2.6B라니, 엄청 사랑받는중이다. 😨

## 개요

#### JsonUtility으로 Json 다룰수는 있는데 후졌다.. 😈

* LitJson || newtonsoft.json

* JSON .NET for Unitys

### 1. 설치 

##### [Add Package by Name || from git URL](https://docs.unity.cn/kr/2021.1/Manual/upm-ui-quick.html)

Add Package by Name(없다면 from git URL)으로

* com.unity.nuget.newtonsoft-json

### 2. 설정

project setting -> player .NET 4.x

* ![](./img/2022-08-17-12-29-56.png)

### 3. 장점

1. **(key-value)에서 Json이 변환할 수 있는 value의 자료형이 다양해진다.**

* JsonUtility vs NewtonSoft.json
    | 가능여부 | JsonUtility | NewtonSoft.json |
    |---|---|---|
    |***1. 기본타입*** <br> int, float, bool, string, array[]|⭕|⭕|
    |***2. More 자료구조 & 컨테이너*** <br> List<> , Dictionary<>|❌|⭕|
    |***3. 사용자가 선언한 오브젝트*** <br> Class|❌|⭕|

#### 1. 예시

|사진|결과|
|---|---|
|<img src="./img/2022-08-17-15-30-39.png">|<img src="./img/2022-08-17-15-39-24.png">|

#### 2. 예시 2 
##### 실제 GearHeart에서 사용한 코드중 일부 내용이다.
|사진|결과|
|---|---|
|<img src="./img/2022-08-17-15-18-07.png">|<img src="./img/2022-08-17-15-19-53.png">|

##### 시행착오

* Json할 클래스 내부 멤버가 Public의 보호수준이라면
* 변수도, 프로퍼티(get,set)도 Json화 시키기떄문에. **예시 3**을 참조하자.

#### 3. 에시 3 ⭐FINAL⭐

* Json할 클래스 프로퍼티를 제외하고 Private 변수로 접근 한정자를 설정했다.
* 결과는 한층 컴팩트 해졌다.

|사진|결과|
|---|---|
|<img src="./img/2022-08-17-15-43-10.png">|<img src="./img/2022-08-17-15-44-35.png">|


### 4. Serialize 예시
```cs
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

public class ㅇㅇㅇ : MonoBehaviour{
    string json = JsonConvert.SerializeObject( _object_, Formatting.Indented);
    //Formatting.Indented : 이쁘게 저장하기
}
```

### 5. 저장 & 불러오기

#### 1. 저장
```cs
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
public class ㅇㅇㅇ : MonoBehaviour{
    string json = JsonConvert.SerializeObject( _object_, Formatting.Indented);
    ⭐PATH = Path.Combine(Application.dataPath, "디렉토리1" ,"디렉토리2" , "무수히많은",...,"디렉토리", "파일이름.json");⭐
    ⭐File.WriteAllText(PATH, json);⭐
}
```

#### 2. 불러오기 & DeserializeObject
```cs
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
public class ㅇㅇㅇ : MonoBehaviour{
    ⭐PATH = Path.Combine(Application.dataPath, "디렉토리1" ,"디렉토리2" , "무수히많은",...,"디렉토리", "파일이름.json");⭐
    ⭐json = File.ReadAllText(PATH);⭐
    menuDataFrom.Instance = JsonConvert.DeserializeObject<menuDataFrom>(json);
    Debug.Log(JsonConvert.SerializeObject(menuDataFrom.Instance, Formatting.Indented));
}
```
|인풋|설명|아웃풋|
|---|---|---|
|<img src="./img/2022-08-17-16-21-46.png">|▶▶▶▶▶▶<br> 보이는것 처럼 <br> **프로퍼티가** <br> 적용되어 <br> 일정값이<br> 들어오면 <br> **자동처리** 되었다<br>▶▶▶▶▶▶|<img src="./img/2022-08-17-16-22-10.png">|

### 7. 주의점

3. 자기 참조 루프에 빠지지 않게 Mono클래스를 상속하는 클래스는 직렬화하지 말자.

### 8. 팁

1. Vector3도 Json 하면 별로 안좋다 그래서 필요한거만 담는 새로운 클래스를 만드는것을 추천한다.
2. 직렬화 하고싶은것, 안하고 싶은것을 정할 수 있다
   1. [ JsonIgnore] 을 통해서 직렬화 안하고 싶은것을 선택할 수 있다.

----

## 참고한 블로그
Newtonsoft Json의 특징
: <https://json2csharp.com/>
: <https://www.newtonsoft.com/json/help/html/JsonObjectAttributeOptIn.htm>
: <https://stackoverflow.com/questions/32008869/json-net-serialize-specific-private-field>
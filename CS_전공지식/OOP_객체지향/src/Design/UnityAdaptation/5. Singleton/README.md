## ClassDiagram
![](./image/SingletonDiagram.png)
|1|2|3|
|---|---|---|
|![](./image/GameController.png)|![](./image/SingletonCSharp.png)|![](./image/SingletonUnity.png)|

## SingletonCSharp

![](./image/2023-01-31-11-20-54.png)
![](./image/2023-01-31-11-21-31.png)
```
1. new는 안했지만은
2. 왠지 랜덤 숫자가 instance1,2 에따라서 달라보여야 할것 같은데.. 
```
결과는 다음과 같다
![](./image/2023-01-31-11-25-07.png)

랜덤 숫자가 같은것을 확인 가능

## SingletonUnity
```
DontDestroyOnLoad(obj) 을 사용해서
씬간 이동에도 파괴되지않는 오브젝트를 만들 수 있다.
```
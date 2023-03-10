#### 개요
```
Anchor Pivot
    1. 크기와 늘려짐 위치를 잘 맞출수 있게.
    2. 윈도우 크기에 비례하도록.
Screen
Canvas
    Scaler
Lock
```
URP로 시작해보자.


Notice that the rectangular outlined frame will change if you resize the Game window. 
Game Window가 변할때 같이 바뀐다.

To take advantage of how the UI Image will fit in proportion to the Game window’s size, 
you will need to adjust the Image’s Anchor points.

게임 윈도우 사이즈에 맞게끔 변하게 하려면 Image’s Anchor points을 조정해야한다.

### Anchor Pivot
![](2023-02-27-11-01-52.png)
![](https://connect-prd-cdn.unity.com/20201210/learn/images/3f285855-02c8-4875-9e63-c550f1ed7627_99.gif)

피봇과 캔버스스케일러
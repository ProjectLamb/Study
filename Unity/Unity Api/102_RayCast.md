# bool Physics.Raycast()

---

### 1. Ray 구조체
반직선 구조체다.

#### 1. "origin" → "Direction"
```cs
Ray ray = new Ray(Vector3 origin, Vector3 Direction);
```

#### 2. 카메라 Ray
```cs
Ray ray = Camera.main.ViewportPointToRay(Vector3 origin);
Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
```

#### Ray의 시작점과 방향이 매 프레임마다 달라지는 경우 Ray도 매 프레임 마다 갱신되어야 한다.

---

### 2. RaycastHit 구조체
이렇게 Ray가 시작되는 위치와 방향을 결정했으면 Ray로 부터 얻은 데이터를 RaycastHit 변수에 저장한다.
RaycastHit은 객체와 Ray의 충돌에 대한 결과 정보를 저장하는 구조체다.
Raycast 함수의 out 파라메터로 사용

```cs
RaycastHit hitdata;
hitdata.point;
hitdata.distance;
hitdata.colider.tag;
hitdata.transform.gameObject;
```
---

### 3. Raycast 함수
1. Ray & 2. RaycastHit & 3. Function
```cs
Ray ray = new Ray(origin , forward);
RaycastHit hitData;

Physics.Raycast(ray, out hitdata);
```
위와 같이 하면 생성된 Ray가 씬으로 발사되고 Ray에 충돌한 어떤 것이든 그것에 관한 충돌 정보가 RaycastHit 변수에 저장된다.
Ray에 어떠한 오브젝트라도 걸리면 true를 리턴한다. 

#### 최대거리를 지정하여 Raycast 범위 제한
```Physics.Raycast(ray, 10)```

----

### 4. Raycast에 Layer Mask 사용하기

Raycast 함수의 유용한 기능 중의 하나는 레이어에 따라 충돌체를 필터링하는 기능이다. 
이를 통해 레이캐스팅에서 무시해야하는 객체를 쉽게 구분할 수 있다. 

해당 레이어의 객체들만 레이캐스팅을 이용해 감지하려고 한다고 가정해보자. 당신이 가장 먼저 해야할 일은 퍼블릭 LayerMask 변수를 생성하는 것이다.

#### 인스펙터에서 불러오기
```cs
public LayerMask worldLayer;
이렇게 public으로 선언된 LayerMask 변수는 인스펙터에서 셋팅이 가능하다.
```

#### LayerMask를 사용할 때 레이어 번호를 직접 입력하는 방법
각 레이어를 구분하기 위해 32bit 비트 마스크를 사용한다. 
만일 9번과 4번 레이어를 동시에 선택하고 싶다면 아래와 같이 528을 넘겨야 한다.
```cs
Physics.Raycast(ray, 10, 528);
528은
512 = 9, 16 = 4
```
![](./image/2023-02-08-17-47-49.png)

#### 하나를 제외한 모든 레이어에서 Raycast 감지
```cs
Physics.Raycast(ray, 10, ~(1<<9));
9번 레이어 제외
```

----

### 5. 하나의 Ray로 여러 객체에 대한 충돌을 검사하고 싶을 때는 RaycastAll을 사용한다.

```cs
public RaycastHit[] hits;
Ray ray = new Ray(transform.position, transform.forward);
hits = Physics.RaycastAll(ray);

거리에 따라 배열을 정렬하는 방법도 있다.
Array.Sort(hits, (RaycastHit x, RaycastHit y) => x.distance.CompareTo(y.distance));
```

---

https://kukuta.tistory.com/391

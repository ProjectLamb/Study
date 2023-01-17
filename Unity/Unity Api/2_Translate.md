# Translate()

## 1. 정의

**자신을 기준으로 상대적으로 이동할때는 transform.Translate 메서드를 사용한다.**

## 2. 사용 예시

```csharp
void Update(){
	if(Input.GetKeyDown(KeyCode.A){ //A키를 누르면
		this.Transform.Translate(new Vector3(0.0f,0.0f,3.0f*Time.deltaTime)); //Z축방향으로 3의 속도로 이동
	}
}
```

## 3. transform.position과의 차이

- **Translate는 지금 있는 장소에서 지정한 방향으로 지정한 거리만큼 움직이며, Translate() 메서드에는 Vector3형으로 된 값을 인수로서 건네주어야 한다.**

- **반면  position은 지정한 위치로 순간이동하는 것과 같으며, transform.position은 값이므로 여기에는 Vector3형을 대입하면 된다.**

### #Time.deltaTime이란?

- **게임을 플레이하는 유저들의 pc,스마트폰 등의 기기 속도(갱신 빈도)가 각각 다른데, 기기의 속도에 영향을 받는 이동이나 회전 등에 값을 그대로 작성하면 속도가 빠른 기기에서는 빨리 움직이고 느린 기기에서는 느리게 이동하게 된다.**
  

- **이러한 성능의 차이를 메워주는 기능을 하는 것이 바로 Time.deltaTime으로 이 값을 이동 속도 등에 곱하면 초당 이동속도를 어느 기기에서나 똑같이 할 수 있다.(Time.deltaTime에는 지금 실행 중인 기기의 1회당 갱신 시간이 들어 있다고 생각하면 편하다)**
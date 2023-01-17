# GetComponent()

## 1. 정의

**GetComponent() 메서드는 원하는 타입의 컴포넌트를 자신의 게임 오브젝트에서 찾아오는 메서드이다. GetComponent() 메서드는 꺾쇠 <>로 가져올 타입을 받는다.**

## 2. 예시

 ```public class Hobak : MonoBehaviour
{
private Rigidbody hobakRigidbody;
// Start is called before the first frame update
void Start()
{
hobakRigidbody = GetComponent<Rigidbody>();
} 
```

- **게임 오브젝트에서 리지드바디 컴포넌트를 찾아서 hobakRigidbody 변수에 할당하는 과정**

- **하나의 GetComponent() 메서드로 모든 타입의 컴포넌트에 대응이 가능하다.**

**#Rigidbody를 Private로 선언한 이유?**

* <img src="./image/1.PNG">

1. **public으로 선언할 경우 Rigidbody를 Hobak 스크립트에
Hobak Rigidbody 변수에 드래그해서 할당해야 한다.**

1.  **하지만 이렇게 변수에 컴포넌트를 직접 드래그&드롭하는 방식은
불편하고 잘못된 값을 할당할 위험이 있다.**

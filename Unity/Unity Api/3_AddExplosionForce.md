# AddExplosionForce()

## 1. 정의

**AddExplosionForce는 대상이 되는 리지드바디에 폭발력을 적용한다.**

## 2. 사용 예시

```csharp
void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Rigidbody otherRB = collision.rigidbody;
            otherRB.AddExplosionForce(300, collision.contacts[0].point, 10);
        }
    }
```

▲ **충돌한 상대에게 AddExplosionForce를 사용해 폭발력을 부여하는 과정이다.**

## 3. AddExplosionForce의 인자

- **AddExplosionForce는 4개의 인자를 가진다.**
- **폭발력**
- **폭발 위치**
- **폭발 반경**
- **위로 솟구치는 힘**

```csharp
otherRB.AddExplosionForce(300, collision.contacts[0].point, 10);
```

- **위 코드는 300의 폭발력을 충돌 접점에 10만큼의 반경만큼 주는 것과 동일하다.**

## 4. 게임에서의 적용 방법

  <p align="center"><img src="./image/fall_guys_obstacle.jpg"></p>

  ▲게임 Fall guys의 인게임 장면

 

- **AddExplosionForce를 사용하여 플레이어를 밀어내는 기능을 가진 장애물을 만들 수 있다.**
- **또는 폭발력을 가진 오브젝트를 만드는 데 활용하는 것도 가능하다.**
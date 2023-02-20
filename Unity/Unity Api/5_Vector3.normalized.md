# Vector3.normalized

## 1. 정의

**Vector3.normalized를 사용하여 대상이 되는 벡터를 정규화시킬 수 있다.**

### 1.1 정규화란?

**어떤 한 벡터를 벡터의 길이로 나누어서 그 벡터의 길이를 1로 만드는 것이다.**

## 2. 사용 예시

**벡터의 정규화는 게임에서는 주로 캐릭터의 이동과 방향에 사용된다.**

- **게임에서 이동하는 캐릭터를 구현한다고 생각해보자**
    
    **그렇다면 다음과 같은 코드를 작성할 수 있을 것이다.**
    
    ```csharp
    void Update(){
        float dirX = Input.GetAxis("Horizntal");
        float dirY = Input.GetAxis("Vertical");
     
        Vector3 dirXY = Vector3.right * dirX + Vector3.forward * dirY; 
     
        transform.position += dirXY * 5 * Time.deltaTime;
    }
    ```
    
  <img src="./image/대각선.PNG">

    - **한쪽 방향으로 이동할 때는 문제가 없지만, 대각선으로 이동할 때 문제가 발생한다.**
    - **좌우 방향의 벡터보다 대각선 벡터의 길이가 더 길기 때문에 플레이어가 대각선으로 이동할 때  더 빨라지게 된다.**
    - **이러한 문제를 해결하기 위해 벡터의 정규화, 즉 normalized를 활용하여 대각선 벡터 또한 1의 길이를 가지도록 해야 한다.**
    
    ```csharp
    void Update(){
        float dirX = Input.GetAxis("Horizntal");
        float dirY = Input.GetAxis("Vertical");
     
        Vector3 dirXY = Vector3.right * dirX + Vector3.forward * dirY;
    		
    		//normalized를 통해 대각선 벡터를 정규화하여 이동속도를 동일하게 한다. 
        transform.position += dirXY.normalized * 5 * Time.deltaTime;
    
    }
    ```
    
    ### 2-1. Normalize()
    
    - **normalized 대신 Normalize를 활용할 수도 있다.**
    
    ```csharp
    
    void Update(){
        float dirX = Input.GetAxis("Horizntal");
        float dirY = Input.GetAxis("Vertical");
     
        Vector3 dirXY = Vector3.right * dirX + Vector3.forward * dirY;
    
    		//Normalize로 dirXY 자체를 정규화시킨다. 
    		dirXY.Normalize();
    		
        transform.position += dirXY * 5 * Time.deltaTime;
    
    }
    
    ```
    
    ### * 참고문헌
    
    [Unity - 키보드 방향키로 Object이동](https://backback.tistory.com/422)
    
    [Unity - Scripting API: Vector3.normalized](https://docs.unity3d.com/ScriptReference/Vector3-normalized.html)
    
    [Unity - Scripting API: Vector3.Normalize](https://docs.unity3d.com/ScriptReference/Vector3.Normalize.html)
    
    [벡터 크기와 정규화 (개념 이해하기) | 심화 JS: 내추럴 시뮬레이션 | Khan Academy](https://ko.khanacademy.org/computing/computer-programming/programming-natural-simulations/programming-vectors/a/vector-magnitude-normalization)
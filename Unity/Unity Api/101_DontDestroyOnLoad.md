# DontDestroyOnLoad()

## 1. 정의
**object shouldn't be destroyed when we switch between scenes
즉, 씬간 이동에서도 파괴되지 않는 하이럴키에 올라온 오브젝트이다.**

## 2. 사용 예시

```csharp
//A public static means of getting the reference to the single created instance, creating one if necessary
public static SingletonUnity Instance
{
    get
    {
        if (instance == null)
        {
            // Find singleton of this type in the scene
            var instance = GameObject.FindObjectOfType<SingletonUnity>();
            // If there is no singleton object in the scene, we have to add one
            if (instance == null)
            {
                GameObject obj = new GameObject("Unity Singleton");
                instance = obj.AddComponent<SingletonUnity>();
                //Init the singleton
                instance.FakeConstructor();
                // The singleton object shouldn't be destroyed when we switch between scenes
                DontDestroyOnLoad(obj);
            }
        }
        return instance;
    }
}
```

▲ **전역적인 데이터를 담는 싱글톤을 GameObject로 적용할시, 씬간 이동시에도 삭제되면 안된다.**

## 3. DontDestroyOnLoad 인자

- **DontDestroyOnLoad는 1개의 인자를 가진다.**
- **객체타겟**

    ```csharp
    GameObject obj = new GameObject("Unity Singleton");
    :
    DontDestroyOnLoad(obj);
    ```

## 4. 게임에서의 적용 방법

  <p align="center"><img src="./image/DontDestroyOnLoad.png"></p>

  ▲게임 런타임중 파괴되지 않는 객체에 UnitySingleton이 생김을 확인 할 수 있다.

```text
1. 환경설정 : Audio Manager
2. Save & Load : 단 동기화 문제가 없을시.
3. Camera : 이미 유니티에 Camera.main으로 구현되어있음
4. EventSystem : 사실 이미 유니티에 구현되어 있음
5. Pool : 싱글톤 GameObject를 생성해서 사용. 
  GameLoop가 없는 객체로만.

이러한 것들이 씬간 이동에서도 유지되는 객체가 된다.
```
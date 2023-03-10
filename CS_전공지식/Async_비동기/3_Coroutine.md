---
ebook:
  theme: one-dark.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F !important;}

    h2 { border-top: 12px solid #45C1A4; border-left: 5px solid #45C1A4; border-right: 5px solid #45C1A4; background-color: #45C1A4; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #45C1A4 !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## ⏱️ 3. Coroutine

### 📄 1. 개요

#### 동시접근에서 부터 안전한 비동기 문법

코루틴이 이점을 가지는것은 바로 멀티스레드가 아니라 싱글 스레드에서 돌아가기에
공유 메모리에 대해 동시 접근이 되는 일이 없다. Thread Safe 한 방식

메인 스레드에서 돌아가지만 비동기 작업을 할때 유용
코루틴은 HTTP 전송, 에셋 로드, 파일 I/O 완료 등을 기다리는 것과 같이 긴 비동기 작업을 처리해야 하는 경우 코루틴을 사용하는 것이 가장 좋습니다.


### 📄 2. 사용법

```cs
/*
* 시간 기다리기
*/
public IEnumerator WaitSecond(float _time){
    yield return new  WaitForSeconds(_time);
    Debug.Log($"{_time} 초가 지났다.");
}
```


```cs
/*
* 타임 스케일 무시
*/
public IEnumerator ScaleWaitSecond(float _time){
    yield return new WaitForSecondsRealtime(_time);
    Debug.Log($"{_time} 초가 지났다.");
}
```

```cs
/*
* 특정 조건에서
*/
public int mCount = 0;

public IEnumerator WaitCount(int _count){
    yield return new WaitUntil(()=> mCount == _count);
    Debug.Log($"카운트가 {_count} 가 되었다.");
}
```


```cs
/*
* 이미지 가져오기
*/
private const string imgur= "https://imgur.com/hdfybMO.png";
public RawImage profileImage;

private IEnumerator WaitGetWebTexture(UnityAction<Texture2D> action){
    UnityWebRequest request = UnityWebRequestTexture.GetTexture(imgur);
    yield return request.SendWebRequest();

    if(request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError){
        Debug.LogError(request.error);
    }
    else {
        Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
        action.Invoke(texture);
    }
}

UnityAction<Texture2D> callback = (Texture2D _texture) => {
 setProfileImage = _texture; 
}

UnityAction<Texture2D> SetProfileImage;
private void Start(){
  StartCoroutine(WaitGetWebTexture(callback));
}
```

```cs
/*
* 코루틴 루프
*/
private IEnumerator CoroutineLoop(float num){
    float passedTime = 0f;
    while(passedTime < num){
        pssedTime += Time.deltaTime();
        yield return;
    }
}
```

### 📄 3. 최적화

#### 1. yield 캐싱
YieldInstruction을 캐싱하면 new 때문에 생기는 가비지를 최소화 할 수 있다;
```cs
YieldInstruction Wait;
CustomYieldInstruction untilCondition;

Awake(){
  Wait = new WaitForSeconds(iTime);
  untilCondition = new WaitUntil(() => {Count == iCount});
}
```

#### 2. 코루팅 저장
IEnumerator을 저장하면 매개변수 넣는것, StopCoroutine에 유용하다.
다만, StartCoroutine하고 난 후에 다시 초기화 해줘야한다.
```cs
IEnumerator coWait;

private void Update()
{
    if (Input.GetKeyDown(KeyCode.Q))
    {
        coWait = CoWaitSecond();
        StartCoroutine(coWait);
    }
    if (Input.GetKeyDown(KeyCode.W)){
        StopCoroutine(coWait);
    }
}

public IEnumerator CoWaitSecond()
{
    meshRenderer.enabled = true;
    yield return wait;
    Debug.Log($"{iTime} 초가 지났다.");
    meshRenderer.enabled = false;
}

```

### 참고
https://docs.unity3d.com/ScriptReference/WaitUntil.html

https://waterbeetle.tistory.com/2
https://ansohxxn.github.io/unitydocs/coroutine/
https://docs.unity3d.com/ScriptReference/WaitForSeconds.html

https://blog.naver.com/torghan/220680437395

https://wergia.tistory.com/63

https://knightk.tistory.com/3
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

## ⏱️ 4. UniTask

---

### 📄 1. UniTask는 Thread-Safe?
<div align="center">
	<img src="./img/2023-03-02-19-19-11.png" width=625px>
	<h4>Chat-GPT 말마따나 세이프 하다네요 ㅋㅋ</h4>
</div>


> UniTask does not use threads and SynchronizationContext/ExecutionContext 
> because Unity's asynchronous object is automaticaly dispatched by Unity's engine layer. 

유니티 레이어단에서 자동으로 비동기 할당을 한다고 하네요 (Job System에 대해 배워야할듯)



### 📄 2. UniTask Basic
#### 1). 장점 
**C#라이브러리와 비교할떄**
1. 빠르고
2. 낮은 할당, 
3. 싱글 스레드인 유니티와 호완이 좋다.

#### 2). Async 가능한것

1. AsyncOperation
   * 유니티 비동기 장면 전환
   * 리소스를 렉 없이 비동기적으로 불러옴
        ```cs
        https://kumgo1d.tistory.com/11
        https://m.blog.naver.com/pxkey/221307916592
        IEnumerator LoadScene(string sceneName) {
            AsyncOperation asyncOper = SceneManager.LoadSceneAsync(sceneName);
            while(!asyncOper.isDone) {
                yield return null;
                Debug.Log(asyncOper.progress);
                //progress 는 0 ~ 1 사이 값으로 반환되고 흔히 로딩 바를 만들 수 있다.

                만약 데이터를 가져왔다고 해도 바로 장면을 활성화 시키지 않고 싶다면
                allowSceneActivation을 false라고 하자
            }
        }
        ```
2. ResourceRequest
   * 이것을 통해 파일을 메모리에 올리거나 직접 해제할 수 있다.
   * 근데 성능이 안좋아서 잘 쓰지 말라고..
        ```cs
        https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=2983934&logNo=221427732658
        ```
3. AssetBundleCreateRequest, AssetBundleRequest
   * 에셋번들에 들어있는 에셋을 불러올떄 사용
        ```cs
        https://ssabi.tistory.com/13
        ```
4. UnityWebRequestAsyncOperation, 
5. AsyncGPUReadbackRequest, 
6. IEnumerator
   1. 열거자는 마치 파이썬의 명령실행처럼 Yield 단위로 한줄한줄 실행
        ```cs
        https://waterbeetle.tistory.com/2
        ```


#### 3). UniTask패턴 
3가지 패턴을 제공하는데 다음과 같다.

```cs
await asyncOperation;
.WithCancellation(CancellationToken);
.ToUniTask(IProgress, PlayerLoopTiming, CancellationToken);
```

키워드
1. WithCancellation 
   * Cancellation
   * Exception handling
2. PlayerLoop
   * timing 
   * ToUniTask
   * PlayerLoopTiming

#### 4). UniTask
* UniTask.WhenAll, UniTask.WhenAny. 를 제공하며
Task.WhenAll, Task.WhenAny 와 1대1 대응 된다.

* 이 두 메서드의 특징은 지정된 조건에 도달할 때까지 호출 스레드를 블럭시킨다는 것이다.
  * WaitAll() 은 한 꺼번에 비동기로 수행하고 전달된 Task가 모두 완료될 때까지 호출 스레드를 블럭시키고
  * WaitAny() 는 전달된 Task 중 가장 먼저 완료되는 Task 나올 때까지 호출 스레드를 블럭시킨다.

* await 키워드를 이용해 제어권을 넘겨주는 방식으로 사용하면 된다.
* await WhenAll은 Task리스트를 모두 병렬 실행

```cs
public async UniTaskVoid LoadManyAsync()
{
    // parallel load.
    var (a, b, c) = await UniTask.WhenAll(
        LoadAsSprite("foo"),
        LoadAsSprite("bar"),
        LoadAsSprite("baz"));
}

async UniTask<Sprite> LoadAsSprite(string path)
{
    var resource = await Resources.LoadAsync<Sprite>(path);
    return (resource as Sprite);
}
```

만약 콜백을 UniTask으로 치환하고 싶다면
UniTaskCompletionSource 를 사용하면 된다.

```cs
public UniTask<int> WrapByUniTaskCompletionSource()
{
    var utcs = new UniTaskCompletionSource<int>();

    // when complete, call utcs.TrySetResult();
    // when failed, call utcs.TrySetException();
    // when cancel, call utcs.TrySetCanceled();

    return utcs.Task; //return UniTask<int>
}
```

치환가능은 다음과 같다. 변환 비용은 거희 없다.
```cs
AsUniTask
    Task -> UniTask;
    UniTask<T> -> UniTask

AsAsyncUnitUniTask
    UniTask -> UniTask<AsyncUnit>

.ToCoroutine()
    async to Coroutine
```

하지말아야할것
* await을 두번이상 사용하면 안된다.
* 아직 완료되지 않았을때, .Result or .GetAwaiter().GetResult()를 하면 안된다.
  * 또는 2번 이상 사용하면 안된다

```cs
var task = UniTask.DelayFrame(10);
await task;
await task; // NG, throws Exception
```

클래스 필드에 저장하고 싶다면
UniTask.Lazy를 사용하여 
여러번 테스크를 호출 할 수 있다.

UniTaskCompletionSource는 여러번 await할 수 있다.

### 📄 2. 설치

 ```https://github.com/Cysharp/UniTask.git?path=src/UniTask/Assets/Plugins/UniTask```

![](./img/2023-02-19-18-33-12.png)


### 📄 3. 사용
```cs
using System;
using System.Threading;
using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Events;
using UnityEngine.UI;
```

```cs
/*
* 시간 기다리기
*/

public async UniTaskVoid AsyncWaitSecond(float _time){
    await UniTask.Delay(TimeSpan.FromSeconds(_time));
    Debug.Log($"{_time} 초가 지났다.");
}
```

```cs
/*
* 타임 스케일 무시
*/

public async UniTaskVoid AsyncScaleWaitSecond(float _time){
    await UniTask.Delay(TimeSpan.FromSeconds(_time), DelayType.UnscaledDeltaTime);
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

public async UniTaskVoid AsyncWaitCount(int _count){
    await UniTask.WaitUntil(()=> mCount == _count);
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
private async UniTask<Texture2D> AsyncWaitGetTexture(){
    UnityWebRequest request = UnityWebRequestTexture.GetTexture(imgur);
    await request.SendWebRequest();

    if(request.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError){
        Debug.LogError(request.error);
        return null;
    }
    
    Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    return texture;
}


private async UniTaskVoid AsyncGetImage(){
    Texture2D texture = await AsyncWaitGetTexture();
    profileImage.texture = texture;
}

UnityAction<Texture2D> SetProfileImage;
private void Start(){
    AsyncGetImage().Forget();
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

private async UniTask AsyncLoop(float num){
    float passedTime = 0f;
    while(passedTime < num){
        pssedTime += Time.deltaTime();
        await UniTask.Yield();
    }
}
private async UniTask AsyncLoop(float num){
    float passedTime = 0f;
    while(passedTime < num){
        pssedTime += Time.deltaTime();
        await UniTask.NextFrame();
    }
}
```
```cs
/*
* 값 감시
    // special helper of WaitUntil
*/
private async UniTask AsyncWaitVauleChanged(){
    await UniTask.WaitUntilValueChanged(this, x => x.isActive);
}
```

```cs
/*
* 비동기 일시정지
* 단 StopCoroutine을 사용 안하고.
    1. CancellationTokenSource
    2. 삭제되면 테스크도 삭제되도록
    3. this.GetCancellationTokenOnDestroy();
*/
private CancellationTokenSource cts = new CancellationTokenSource();

public async UniTaskVoid AsyncWaitSecondCancel(float _time){
    //await UniTask.Delay(TimeSpan.FromSeconds(_time), cancellationToken : this.GetCancellationTokenOnDestroy());
    await UniTask.Delay(TimeSpan.FromSeconds(_time), cancellationToken : cts.Token);
    Debug.Log($"{_time} 초가 지났다.");
}

private void Start() {
    AsyncWaitSecondCancel(5).Forget();
}

private void Update() {
   if(Input.GetKeyDown(KeyCode.Space)){
       cts.Cancel();
       cts.Dispose();
   }
}

private void OnDisable() {
    cts.Cancel();
}
```

Task가 모두 끝나면 자동으로 해제되기 때문에 상관없지만, Task가 종료되기전 오브젝트가 삭제되거나 어플리케이션이 종료된다면 해제되지 않은 메모리가 계속 남아 있다는 점이 있습니다.

### 참조


https://www.youtube.com/watch?v=j3hpuVB2cLk&list=PLNfnSiTQHkLrTTIJsy23AogPAKb7dpXqV&index=33

https://velog.io/@jinuku/UniTask-%EC%95%8C%EC%95%84%EB%B3%B4%EA%B8%B0

https://github.com/Cysharp/UniTask

https://neuecc.medium.com/unitask-a-new-async-await-library-for-unity-a1ff0766029

https://www.youtube.com/watch?v=WY-mk-ZGAq8

https://gall.dcinside.com/mgallery/board/view/?id=game_dev&no=67752

https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=vactorman&logNo=220340604389

https://velog.io/@anzsoup/%EC%9C%A0%EB%8B%88%ED%8B%B0%EC%97%90%EC%84%9C-async-await-%EC%82%AC%EC%9A%A9%ED%95%98%EA%B8%B0

https://gall.dcinside.com/mgallery/board/view/?id=game_dev&no=109288
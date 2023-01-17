# Unity 

### 설치

Unity 에서는 누겟으로 Package 를 다운 받아 사용할수 없고 **Package Manager**를 이용해야한다.

#### **1. nuget package dll**

##### [.Net 4.x](https://docs.microsoft.com/ko-kr/visualstudio/gamedev/unity/unity-scripting-upgrade)

1. [Newtonsoft.Json : Nuget](https://www.nuget.org/packages/Newtonsoft.Json/)
2. <img src="./img/2022-08-17-10-38-37.png" width=600px>
3. 다운로드한 파일을 찾아서 확장자를 .nupkg에서 .zip으로 변경합니다.
4. zip 파일 내에서 lib/netstandard2.0 디렉터리로 이동하여 Newtonsoft.Json.dll 파일을 복사합니다.
5. <img src="./img/2022-08-17-10-41-22.png" width=600px>
6. <https://docs.unity3d.com/kr/current/Manual/Plugins.html>
7. ![](2022-08-17-10-43-48.png)
   * 위의 플러그인 규칙을 근거해
   * 루트 Assets 폴더에서 Plugins라는 새 폴더를 만듭니다. 플러그 인은 Unity의 특수 폴더 이름입니다.

#### **2. Package Manager**

##### [Add Package by Name || from git URL](https://docs.unity.cn/kr/2021.1/Manual/upm-ui-quick.html)

1. 패키지 매니페스트

    ```json
    {
      ⭐"name": "com.unity.example",⭐ [이것이 Name으로 패키지를 추가할때 사용하는 name이 된다]
      "version": "1.2.3",
      "displayName": "Package Example",
      "description": "This is an example package",
      "unity": "2019.1",
      "unityRelease": "0b5",
      "documentationUrl": "https://example.com/",
      "changelogUrl": "https://example.com/changelog.html",
      "licensesUrl": "https://example.com/licensing.html",
      "dependencies": {
        "com.unity.some-package": "1.0.0",
        "com.unity.other-package": "2.0.0"
     },
     "keywords": [
        "keyword1",
        "keyword2",
        "keyword3"
      ],
      "author": {
        "name": "Unity",
        "email": "unity@example.com",
        "url": "https://www.unity3d.com"
      }
    }
    ```

2. 범위 지정 레지스트리
   * 이름으로 패키지를 추가할 수 있는것은 "범위 지정 레지스트리"에서 호스팅 되는 패키지만 지원한다.
   * custom package registry server 의 위치를 Package Manager 에 전달하여 <br> 사용자가 동시에 여러 패키지 컬렉션에 액세스하도록 지원합니다.
     * registry server (?)
       * 레지스트리를 서버임대를 해주는 서비스를 제공(호스팅) 하는 것이 있다.
       * 서버는 위의 역활을 해준다는것
       * 즉 인터넷을 통해서 패키지를 다운받을수 있다는 말인것 같다.
    * 상세한 용어 정리
       1. Package Manger :
          * 패키지를 다운로드하고 설치하는 애플리케이션입니다.  
       2. Unity Registry :
          * Package Manager 에서 프로젝트에 이미 설치되었는지 여부에 관계없이
          * Unity 패키지 레지스트리에 있는 모든 패키지를 표시합니다.
          * 여기에는 다른 위치 또는 범위 지정 레지스트리에서 설치된 패키지가 포함되지 않습니다.
       3. 범위 :
          * com.example.mycompany.animation 또는 com.example 등을 비롯한
          * 패키지 이름 또는 네임스페이스(역 도메인 포맷)를 정의합니다.
          * 해당 범위와 가장 일치하는 패키지를 레지스트리에서 Fetch 한다.
       4. 패키지 레지스트리 서버
          1. 패키지를 추적하고 저장할 장소를 제공하는 애플리케이션입니다.

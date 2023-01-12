<h1 align="center"> 테크니컬 아트를 위한 툴 </h1>

---

## 개요

* Ta가 배워야할 목차를 정리함.
* 그래픽, 이펙트, Audio에 대해 정리

## 목차 

1. ### [타임라인]()
```
쉐이더, lookdev, 최적화, 문제해결

책 목차
1. 수학에 대한 난이도

2. 셰이더란?
   랜더링과 셰이더란?
   버텍스 셰이더 & 픽셀 셰이더
   보간기
   픽셀 셰이더 프래그먼트 셰이더

3. 빛과 HDR
   * 라이트맵 라이트 프롭스
       * Light의 종류
       * Light Map 이론
       * Light Map 실습
       * Light Probes에 대한 이해
       * Light Probes 활용 실습
   * prograssive, 라이트 매퍼, Global Illumination, 레이트레이싱, 인라이튼
   * 라이트 매핑 : 직접 조명과 간접 조명을 사전에 계산하고, 나중에 사용할 수 있도록 해당 결과를 라이트맵이라는 텍스처에 저장할 수 있습니다. 

4. 셰이더 그래프의 기초
   * 랜더 파이프라인 : 리얼 타임 랜더링
       URP 
       HDRP
   * 노드방식
       * FSM
   * 프레임마다 변하는 빛의 색과 형태! 여러 시각적 효과를 만들기 위한 가장 중요한 개념인 셰이더와 렌더링 기능을
       * 셰이더 그래프 입문
       * 셰이더 그래프 예제
       * 셰이더 프로그래밍 입문
       * 셰이더 프로그래밍 예제
   * 서브그래프
   * 셰이더 그래프 커스텀 라이팅

5. 스크립트
   * ShaderLab 
   * HLSL
   * GLSL

6. 벡터 행렬 MVP 변환 아웃라인

7. 에셋
   * 에셋 작업 : 
       비파괴 파이프라인 제작 
       에셋 임포트
       DCC
       텍스처
       머티리얼
       프리팹 배리언트
       Addictive와 Blend의 차이: Alpha 텍스처
       메시 머티리얼 텍스쳐 셰이더

9 패키지
   * TextMeshPro
   * Progrid : 애니메이션
       그리드 평면을 더 섬세하게
   * 트위닝(tweening) 함수를 만들거나, 타사 라이브러리(예: DOTween)
   * 프로파일링
   * Ragdoll 이벤트
   * 포스트 프로세싱

10.  이펙트
   * FBX 에셋
   파티클 시스템 : https://www.youtube.com/watch?v=FEA1wTMJAR0&t=234s
       * Spawn Burst와 Spawn Rate의 차이와 사용법
       * Velocity, Force, Limit
       * Looping
       * Particle Trail과 Noise
       * Velocity - Orbital
       * Texture Sheet Animiation Single Row
   * 디졸브
   * Rim 셰이더 
   * UV 에디터, 텍스쳐, 애니메이션

11 이펙트 & 쉐이더 노드 
    1. https://www.youtube.com/watch?v=X5AJW1l73DE
    2. https://www.youtube.com/watch?v=PFppBIOEBW4

12.  애니메이션
   * FSM
   * 스내핑으로 신속한 트랜스폼 설정 : 그리드로 작업하면 더 정확하고 일관성 있게 프리팹을 결합할 수 있습니다. 각 요소가 유기적으로 연결되도록 레벨을 디자인하면 보다 쉽게 재정렬과 재조합이 가능합니다.
   * Animation Rigging 패키지를 사용하면 기능을 더욱 확장할 수 있습니다. 이 패키지는 절차적 모션을 생성할 수 있는 역운동학적(inverse kinematic)
   * 최적화 팁
       * UI나 단순한 애니메이션에는 항상 레거시 Animation 컴포넌트를 사용하세요.  
   * 블랜더
   * 리깅

후디니
https://product.kyobobook.co.kr/detail/S000001888139
```

```text
오디오싱크글1 : https://styly.cc/tips/unity-timeline-music-sync/
오디오싱크글2 : https://justenyc.medium.com/how-to-sync-actions-with-audio-in-unity-6cdb57dd02fb
오디오싱크글3 : https://christianfloisand.wordpress.com/2014/01/23/beat-synchronization-in-unity/

```
![](2023-01-03-16-28-53.png) 
### 참조
1. [유니티그래픽스](https://docs.unity3d.com/kr/2020.3/Manual/Graphics.html)
2. [그래픽스튜토리얼](https://learn.unity.com/search?k=%5B%22q%3AGraphics%22%5D)
3. [유니티서포트그래픽스와쉐이더](https://support.unity.com/hc/en-us/sections/201165155-Graphics-and-Shaders)
4. [테크니컬아티스르틀위한유니티툴워크플로](https://blog.unity.com/kr/technology/complete-overview-of-unity-toolsets-workflows-for-technical-artists)
5. [워크플로향상팁](https://blog.unity.com/kr/technology/speed-up-your-artist-workflows)
6. [클로소TA](https://coloso.co.kr/products/technicalartist-parksungkuk?utm_source=youtube&utm_medium=organic&utm_campaign=technicalartist-parksungkuk_auto_all&utm_content=game_technicalartist-parksungkuk_coloso_trailer_referrals_221206)
7. [어쩌다TA](https://www.youtube.com/watch?v=hwvRFAvQ5ww)
8. [영화품질의조명생성하기](https://blog.unity.com/technology/sherman-behind-the-screens-how-to-create-cinema-quality-lighting-in-unity)
9. [NDC 게임 이펙트 시작하는법](https://www.youtube.com/watch?v=2jlaUT5uGSI)
```
GameBeach
https://www.youtube.com/watch?v=pdMiuLpeT_A

LeiaRemote
Unity에 바로 연결하고 Unity의 3D 라이트필드 콘텐츠를 Leia 디스플레이에서 미리 보며 시간을 절약하세요. Unity SDK 패키지가 있는 곳과 동일한 폴더에 있는 remote APK를 다운로드하기만 하면 됩니다.

pixelwork
https://www.pixelworks.com/media/pixelworks-becomes-a-unity-verified-solutions-partner-to-improve-visual-display-for-mobile-gaming/
```

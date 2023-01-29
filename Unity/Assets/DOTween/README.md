# DOTween

### DOTween이란?

- **오브젝트의 이동** 혹은 **부드러운 값 변경**을 위해 기존의 유니티 내에서 제공하는 애니메이션 기능이나 번거로운 스크립트 작성 대신 **함수 몇개로 쉽고 다양한 모션을 줄 수 있는 간편한 API**이다.
- DOTween은 특정 변수 값들을 일정 시간동안 원하는 값으로 부드럽게 변화 시켜 주는 역할을 한다. <span style="color: #808080">(float, double, int, uint, long, ulong, Vector2/3/4, Quaternion, Rect, RectOffset, Color, string등) </span>

[에셋스토어 바로가기](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)

---
### 목차
1. [사용법](#-사용법)
2. [용어](#-용어)
3. [함수](#-함수)
---

### 1. 사용법

DOTween을 본격적으로 사용하기 앞서, **네임스페이스**로 추가할 필요가 있다. 다음과 같이 불러온다.
```C#
using DG.Tweening;
```

**오브젝트 컴포넌트**에 연결하여 접근하는 방식이 주로 쓰인다.
GameObject.Do~ 와 같은 방식으로 사용한다. <span style="color: #808080">ex) DoMove(), DoRotate(), DoColor(), ... </span>

1) Transform **:** 오브젝트의 기본적인 **이동, 회전, 크기**를 일정시간동안 변환한다.
```C#
transform.DOMove(Vector3 목표값, float 변화시간, bool 정수단위 이동);
transform.DORotate(Vector3 목표값, float 변화시간, RotateMode 회전방식);
transform.DOScale(Vector3 목표값, float 변화시간);

transform.DOLocalMove(Vector3 목표값, float 변화시간, bool 정수단위 이동);
transform.DOMoveX(Vector3 목표값, float 변화시간, bool 정수단위 이동);
transform.DOMoveY(...);
transform.DOMoveZ(...);

...

```

- DOMove()
![[DOMove.gif]]

- DORotate()
![[DORotate.gif]]

- DOShake()
![[DOShake.gif]]

2) Material : 오브젝트의 **컬러값, 알파값**등을 일정 시간동안 부드럽게 변환한다.
```C#
Renderer.Material.DOColor(Color 목표값, float 변화시간);
Renderer.Material.DOFade(float 목표값, float 변화시간);
```

- DOColor();
![[DOColor.gif]]

3) Text : 일정 시간동안 텍스트가 타이핑되는 효과를 준다.
```C#
Text.DoText(string 전체텍스트, float 변화시간);
```

<span style="color: #808080">UI나 텍스트 박스에 다음과 같이 활용할 수 있다. </span>
![[DOText.gif]]

### 2. 용어
#### 1) Tweener
트위너는 DOTween의 일하는 **개미**에 비유할 수 있다. **속성/필드**를 가져와 주어진 값을 향해 **애니메이션화**한다.

#### 2) Ease
![[DOTween Ease tablet.png]]

### 3. 함수
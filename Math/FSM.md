---
ebook:
  theme: github-light.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    @import url('https://fonts.googleapis.com/css2?family=Fredericka+the+Great&display=swap');
    @font-face {
        font-family: 'Humanbumsuk';
        src: url('https://cdn.jsdelivr.net/gh/projectnoonnu/noonfonts_2210-2@1.0/Humanbumsuk.woff2') format('woff2');
        font-weight: normal;
        font-style: normal;
    }
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A5F !important;}
    h2 { letter-spacing : 4px; font-family: 'Fredericka the Great', "Humanbumsuk"; border-top: 12px solid #40493c; border-left: 5px solid #40493c; border-right: 5px solid #40493c; background-color: #40493c; color: #FFD466D5 !important; font-weight: bold;}
    h3 { letter-spacing : 4px; font-family: 'Fredericka the Great', "Humanbumsuk"; border-top: 12px solid #40493c; border: 5px solid #40493c; background-color: #40493c; color: #FFFFFFDF !important;}
</style>

## FSM : 유한상태기계
![](2023-01-03-12-25-24.png)

### 1. 목차
1. DFA
2. NFA
3. NFA -> DFA 변환 알고리즘
4. FSM 변환 알고리즘
5. 유니티 코드


### 2. DFA
#### 1). 정의
결정적 유한 오토마타 (Determinstic Finite Automata)
5개로 구성된 튜플이다.

#### 2. 특징
* next state가 단 하나로 결정됨
* ε (empty input)에 대한 전이가 없음

#### 2). 수식
**${M = (Q, ∑, ∂, q0, F)}$**

1. Q : set of **state**
   * 노드, 상태를 의미
   * 인풋으로 들어가는 상태는 원소 하나일수도, 원소의 집합일 수 있다.
  
2. ∑ : set of symbols called **input** 
   * 간선(화살표), 전이함수의 인풋 매개변수로 사용

3. ∂ : 전이 함수 
   * ∂(상태, 인풋) -> 상태

4. q0 : inital state 
   * 초기 상태 *상태이므로 Q원소이다.*
   * 표현 방법은 1. 함수결과식 2. 상태 전이표
5. F : final state
   * 엔딩 상태이다.

### 4. 유니티 적용
#### 1. 기본 개념

1. 상태 : Q 에 해당하는것
   * 임의의 주어진 시간에 오직 하나의 상태만 Activate 해야한다.
2. 이벤트 : ∑ 에 해당하는것
   * 상태 전이를 위한 조건
3. 상태 전이 : ∂ 에 해당하는것
   * 현재 상태를 다른 상태로 변화 시키는것

|img|설명|
|:--|:--|
| <img src="2023-01-03-11-46-23.png" width=400px> | <ul> <li>Q = {공격, 배회, 접근}</li> <li>∑ = {<i>플레이어제거, 플레이어근접, 플레이어발견</i>}</li> <li>∂(공격, <i>플레이어제거</i>} = 배회<br>∂(배회, <i>플레이어발견</i>} = 접근<br>∂(접근, <i>플레이어근접</i>} = 공격</li></ul>|

#### 2. 왜 쓰는가?
1. 게임 AI에게 지능을 부여하기 위한 모델이다.
2. **상태** 라는것을 객체화 할 수 있다.
3. 오류 수정이 용이하다. 
4. 전이 상태를 한눈에 파악 가능
5. 확장 변경에 용이하다.

궁극적으로 Ai의 동작 행위를 유한 개수의 상태로 표현하기위해 사용되는 모델이다.

#### 3. 구현

**ⓐ : if-else & switch 👎 비추다 비추!**

**ⓑ : state 패턴 사용 😎 이걸 써야 상남자** <img src="./gigachad.png" width=30px>
  * 상태를 객체로 표현 가능
  * 상태 전이 규칙이 객체 내부에 있음

#### 4. 테크닉
**ⓐ : Enter Excute Exit**

* Enter은 상태 진입때 단 한번 호출된다
* Excute는 해당 상태일떄 계속 호출된다.
* Exit은 상태 퇴장때 한번 호출된다.
*
  ```cs
  public abstract class State {
    public abstract void Enter();
    public abstract void Excute();
    public abstract void Exit();
  }
  ```

**ⓑ : 싱글톤**
* new delete를 반복적으로 일으키므로
* State마다 싱글톤 패턴을 적용시키면 오버헤드와 메모리 낭비를 막을 수 있다.

**ⓒ : 전역상태**
* 어느 상태에서도 발생할 수 있는 상태 전이 집합체이다.
* 예를 들어 피격 애니메이션은 늘 어느순간에도 같은 애니메이션이 출력되야할 것이다.
* 전역 상태의 정의 
```cs
class StateMachine {
  private enity_type mpOwner;
  private State<enity_type> mpCurrentState;
  private State<enity_type> mpGlobalState;
}
```

**ⓓ 상태 블립**
* 특정 조건에 따라 이전 상태로 돌아가야 할 떄가 있다.
* 이전 상태로 돌아가는것을 상태 블립이라고 한다.
* 이전 상태를 저장할 수 있는 변수를 생성하고
* ChangeState에서 현재 상태 변경전에 이전 상태를 저장함
* ChangePreviousState 함수로 이전 상태로 돌아가도록 함


### . 참고
1. [인도인](https://www.youtube.com/watch?v=Qa6csfkK7_I)
2. [강승식](https://www.youtube.com/watch?v=TzXOj-XRC-U)
3. [이산수학](https://www.youtube.com/watch?v=-Xy2Zhe0kqU)
4. [블로그](https://dokhakdubini.tistory.com/451)
5. [FSM](https://m.blog.naver.com/PostView.naver?isHttpsRedirect=true&blogId=jerrypoiu&logNo=221235988023)
6. [고박사](https://www.youtube.com/watch?v=O_NJaHpbjaI&t=15s)
7. [곰돌](https://www.youtube.com/watch?v=MowE3moQ_Cw&t=3s)
8. [외국인](https://www.youtube.com/watch?v=5PTd0WdKB-4)
9. [소년코딩](https://www.youtube.com/watch?v=5PTd0WdKB-4)
10. [식빵맘](https://ansohxxn.github.io/unity%20lesson%201/chapter9-1/)
11. [백준](https://www.acmicpc.net/problem/1013)
---
ebook:
  theme: github-light.css
  title: 객체지향
  authors: Escatrgot
  disable-font-rescaling: true
  margin: [0.1, 0.1, 0.1, 0.1]
---
<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A5F !important;}
    h2 { border-top: 12px solid #D40; border-left: 5px solid #D40; border-right: 5px solid #D40; background-color: #D40; color: #FFF !important; font-weight: bold;}
    h3 { border-top: 12px solid #F90; border: 5px solid #F90; background-color: #F90; color: #FFF !important;}
</style>

## 📕 5. NDC의 협업 문화

#### 나의 업무 능력을 복제하는게 목표다.

### 📄 1. 코드 리뷰

#### 1). 업무 분할
1. **자신의 일을 잘라서 나누자**
   * 내가 충분히 알고 있는 일을 나누자 
2. **나눌때, How to를 자세히 설명하자.**
   * 개발 도구 세팅, 사용법
   * 코드를 어디를 봐야하는지
   * 어떤 구조로 문제를 풀면 되는지
   * 
   * 쉬운일 부터 완수해야하고 그걸 동료와 공유해야한다.
3. **결과물 확인과 검증 그리고 피드백**
   * 피드백은 일관성 있어야 하고, 근거도 명확해야된다.
   * 한번에 모든 규칙을 숙지하기 어렵기에 ***정리된 문서*** 가 필요하다.
      ```text
      1. 파일, 코드, 클래스명 등등 네이밍 컨벤션
      2. 실행 방법 & 깃허브 공유법 등등..
      3. 디자인 패턴
      4. 델리게이트 네이빙, 호출 컨벤션
      5. 에러메시지 컨벤션
      ```

### 📄 2. 설계 리뷰

1. 기획 사항과 제약 사항을 이해하고 작업을 설계(아키텍쳐) 해보자
2. 설계 근거를 확인하고 타당성을 검토한다
   * 예상되는 문제를 찾아내고 다른 의견을 제시해본다.
   * <img src="./image/2023-01-04-18-08-25.png">

3. 이렇게 함으로 사고의 흐름, 가치간의 우선순위를 매기고, 
성능 품질 기준의 설정과 비용분석이 가능하다.
4. 설계를 핑퐁하면서 설계를 완성해나가자.


## 6. 아키텍쳐 & 객체지향 분석 및 설계

[아키텍쳐](https://www.youtube.com/watch?v=saxHxoUeeSw)

### 

설계한 아키텍쳐에 신경쓰지 못한다면
시간이 지날수록 기능을 추가하기 힘들어 진다.
기능을 추가하기위해 기존 소스코드를 바꿔야 하기 때문이다.

Use Case
UML 다이어그램
State 다이어그램

```
개발 VS 아키텍트

기능적 요구사항
비기능적 요구사항

아키텍트 : 전체 시스템을 이해하고 물리구조를 설계해야한다.
최적의 솔루션을 내야한다.

1. 객체지향 분석
모델링을 하는 작업이다.
요구사항을 분석하여 요구된 문제와 관련된 
1. 클래스
2. 멤버와 메서드
3. 클래스간 관계를 정리하은

개발하기 위해서는 
1. 객체와 속성, 클래스와 멤버, 전체와 부분등으로 나눠서 분석한다.
2. 분석자는 모델링 구성요소인 클래스, 객체, 속성, 연산들을 표현해서 문제를 모형화 할 수 있어야 한다.

```
<img src="./image/2023-01-04-18-52-37.png">
방법론 


<img src="./image/2023-01-04-18-53-31.png">
럼바우
* 그래픽 표기법으로 
    1. 개체도
    2. 상태도
    3. 자료흐름도

CY 분석
E-R 다이어그램

람바우
<img src="./image/2023-01-04-18-55-08.png">

자료 흐름도 DFD
<img src="./image/2023-01-04-19-01-17.png">
<img src="./image/2023-01-04-19-01-31.png">

<img src="./image/2023-01-04-19-04-31.png">

![](2023-01-06-17-27-58.png)

https://www.youtube.com/watch?v=IzN9Vuoivrg&list=PL6XklZATqYx9dj72MKG6wLYjljeB2odra
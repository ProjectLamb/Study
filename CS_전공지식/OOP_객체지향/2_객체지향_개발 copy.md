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
    .quest { font-weight: bold; color: #A5F !important;}
    h2 { border-top: 12px solid #D40; border-left: 5px solid #D40; border-right: 5px solid #D40; background-color: #D40; color: #FFF !important; font-weight: bold;}
    h3 { border-top: 12px solid #F90; border: 5px solid #F90; background-color: #F90; color: #FFF !important;}
</style>
## 📕 2. 객체지향 개발

---

### 📄 2. 접근 한정자


#### 1). 한정자
* 
  |호출자의 위치| public | protected | internal | private |
  |:--|:--|:--|:--|:--|
  |**클래스** 내부 끼리            |✔️️|✔️️|✔️️|✔️️|
  |**파생** 클래스 끼리 (Same 어셈)|✔️️|✔️️|✔️️|❌|
  |**비파생** 클래스 끼리(Same 어셈)|✔️️|❌|✔️️|❌|
  |**파생** 클래스 끼리(diff 어셈)|✔️️|✔️️|❌|❌|
  |**비파생** 내부 끼리(diff 어셈)|✔️️|❌|❌|❌|

#### 2). *얜 뭐야?* : Internal

**ⓐ unity 에서 인스펙터 창에서 변수를 숨기고 싶을떄 사용 가능하기도 한다.**

* 근데 보통 [HideInInspector] 사용해야한다.

**ⓑ 개발 관점**

* public이랑 비슷한데 같은 어셈블리끼리 공유가 된다.
* 개발에서는 namespace가 다르다? 그렇다면 어셈블리가 다른것.
  * [어셈블리는 뭔 소리? ㅋㅋ](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-C-1-%EC%96%B4%EC%85%88%EB%B8%94%EB%A6%ACAssembly);

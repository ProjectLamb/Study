# OOP
다음은 Java, C#에서 통용되는 OOP 개발 패러다임에 대한 정리를 작성한 노트입니다.

~~스타일링된 PDF문서가 있으니 가능한 PDF 보시는게 가독성이 더 높을것 입니다.~~

일부 문서 한정으로 스타일링된 본인의 [블로그](https://felipuss.tistory.com/) 주소가 더 가독성에 도움이 되실것입니다.

---

## 목차

* ### [ⓐ 객체지향_개요](./1_객체지향_개요.md)
  * [1 객체지향 개요 블로그](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-1-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5-%ED%94%84%EB%A1%9C%EA%B7%B8%EB%9E%98%EB%B0%8D)
    ```text
    A : 객체지향 개요
      1. what is OOP
      2. Class & Instance
    B : 객체지향 개념
      3. 캡슐화
      4. 상속
      5. 다형성
      6. 연관성
    ```

* ### [ⓑ 객체지향_개발](./2_객체지향_개발.md)
    * [2 객체지향 개발 블로그](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-2-1-Class-Instance)
    * [Extra C#에서 어셈블리 개념](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-C-1-%EC%96%B4%EC%85%88%EB%B8%94%EB%A6%ACAssembly)
      ```text
      A : 주로 캡슐화에 대한 이야기
        1. new 를 통한 인스턴스 생성
        2. C# 접근 한정자
        3. Static
        4. this
        5. 구조체
        6. 생성자
        7. 객체 배열 생성
        8. 화살표 함수
      ```
    
* ### [ⓒ 객체지향_상속&다형성](./3_객체지향_상속.md)
  * [3 객체지향 상속&다형성](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-3-1-%EC%83%81%EC%86%8D)
  * [Extra 상속의 문제점](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-Extra-%EC%83%81%EC%86%8D%EC%9D%98-%EB%AC%B8%EC%A0%9C)
    ```text
    A : 주로 상속과 다형성에 대한 이야기
      1. 상속
      2. 메소드 오버라이딩
      3. 다형성
      4. 추상 클래스
      5. 인터페이스
    ```

* ### [ⓓ 객체지향_디자인패턴](./4_객체지향_디자인패턴.md)
  * [4 객체지향 디자인패턴](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-4-0-SOLID-%EC%9B%90%EC%B9%99)
  * [Extra 응집도, 결합도](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EA%B0%9D%EC%B2%B4%EC%A7%80%ED%96%A5OOP-Extra-%EC%9D%91%EC%A7%91%EB%8F%84-%EA%B2%B0%ED%95%A9%EB%8F%84)
  * [FSM](https://felipuss.tistory.com/entry/%EB%8B%88%EC%95%99%ED%8C%BD%EC%9D%B4-%EC%98%A4%ED%86%A0%EB%A7%88%ED%83%80-1-FSM-%EC%9C%A0%ED%95%9C%EC%83%81%ED%83%9C%EA%B8%B0%EA%B3%84)
    ```text
    A : 클래스간의 연관성 그리고 결합도 & 응집도에 대한 이야기 
      1. 결합도 & 응집도
      2. 디자인 패턴의 개요
      3. SOLID 원칙
      4. 생성패턴 
        - 싱글톤
      5. 구조패턴
        - 컴포지트 패턴
        - 데코레이터 패턴
        - 플라이웨이트 패턴
      6. 행동 패턴
        - 커맨드 패턴
        - 옵저버 패턴
        - 상태 패턴
      7. 그밖에 유용한 패턴
        - 서브클래스 샌드박스 패턴
        - 이벤트 큐
        - 오브젝트 풀
    ```
    
* ### [ⓔ 객체지향_아키텍처](./5_객체지향_아키텍처.md)
  * 5 아키텍처
    ```text
      1. 아키텍처 개요
      2. 아키텍처 용어 정리
      3. 실제 수립 과정
      4. 시나리오 도출
      5. 뷰 모델
      6. 뷰 설계
      7. 아키텍처 패턴
    ```
    
* ### [ⓕ 객체지향_다이어그램](./6_객체지향_다이어그램.md)
  * 6 다이어그램 작성
    ```text
      1. 객체지향 분석 방법론
      2. UML
      3. 다이어그램 툴
      4. 다이어그램의 관계
      5. 유스케이스 다이어그램
      6. 클래스 다이어그램
      7. 시퀸스 다이어그램
      8. 상태 다이어그램
    ```
# PCG

### 1. 사전적 의미
> [컴퓨팅](https://ko.wikipedia.org/wiki/%EC%BB%B4%ED%93%A8%ED%8C%85 "컴퓨팅")에서 **절차적 생성**(Procedural generation)은 데이터를 직접 제작하지 않고 [알고리즘](https://ko.wikipedia.org/wiki/%EC%95%8C%EA%B3%A0%EB%A6%AC%EC%A6%98 "알고리즘")을 이용해서 자동으로 생성하는 방법을 일컫는다. 주로 사람이 만든 에셋과 컴퓨터의 난수 및 처리능력을 사용한 알고리즘의 결합으로 구현한다. 절차적 생성은 [합성 매체](https://ko.wikipedia.org/w/index.php?title=%ED%95%A9%EC%84%B1_%EB%A7%A4%EC%B2%B4&action=edit&redlink=1 "합성 매체 (없는 문서)")의 일종이다.

### 2. 게임 개발에서의 의의
- 게임 개발 함에 있어서 개발자가 모든 맵을 일일이 디자인 하는 데에는 많은 시간과 노력이 필요하므로 절차적 생성 기법을 통해 수고를 덜 수 있다.
- 로그라이크와 같이 랜덤 요소와 다회차 플레이를 요구하는 장르일수록 해당 기법이 잘 부합한다.

### 3. 응용
#### 1. 스테이지 생성

##### 구상
[참고 사이트](https://www.boristhebrave.com/2020/09/12/dungeon-generation-in-binding-of-isaac/)
- 소피아 프로젝트가 아이작의 맵 생성 기법을 모티브로 함으로 아이작 원본 코드를 벤치마크했다. 
- 스테이지내 방이 절차적으로 생성되도록 아래와 같이 조건을 붙인다.
```
-   인접 칸이 이미 채워진 경우 포기합니다.
-   만약 인접 칸 인접 칸 자체에 둘 이상의 채워진 인접 칸이 있다면, 포기합니다.
-   이미 충분한 방을 생성하였다면 포기합니다.
-   50% 확률로 포기합니다.
-   그 외 경우, 인접 칸에 방을 만들고, 해당 칸을 큐에 넣습니다.
```

##### 구현

이를 소스코드로 구현하면 다음과 같다.
```C++
if (!room[num].vacancy)

                continue;

            if (amount == roomAmount)

                continue;

            if (random())

                continue;

  

            q.push(num);
```

[전체 소스코드](https://github.com/ProjectLamb/SourceCode/blob/neoskyclad/PCG/Stage/PCG_Stage.cpp)

##### 결과
![[PCG_Stage_Result.png]]
#### 2. 맵 생성

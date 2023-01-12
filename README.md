# 📖 StudyforGameMaking
## 소개
- 게임 개발을 위한 스터디 레포지토리입니다.
- 본인 ID명으로 브랜치를 따로 만들어 쓰되, 모두에게 공유할 정보는 main으로 머지하시면 됩니다.

---
## 목차

- [깃허브 관리](#깃허브-관리)
- [알고리즘 스터디](#알고리즘-스터디)
- [에셋 스터디](#에셋-스터디)

#### 폴더목차
- [CS 스터디](./CS_전공지식/README.md)
- [Unity 툴 스터디](./Unity/README.md)

---

## 😺 깃허브 관리
- 본인 ID명으로 브랜치를 따로 만들어 쓰되, 모두에게 공유할 정보는 main으로 머지하시면 됩니다.
#### 1. add commit push
```bash
git add *
git commit -m "_커밋 메세지ㅋ_"
git push origin ID명브랜치ㅋ
```

#### 2. *"내 작업 브랜치"* <sub>에서 커밋한 내용을</sub> *"main"*<sub>으로 병합</sub>

##### 1. Merge
- escatrgot_dev 커밋내용을 main으로 병합
    ```bash
    git checkout main               /*1. 메인이 되는 브랜치로 이동*/
    git merge escatrgot_dev         /*2. 현재 main브랜치, 다른 브랜치를 병합한다.*/
    git push origin main            /*3. 저장소에 푸쉬*/
    ```
 - push 완료 후 본인 계정의 github 저장소에 들어오면 Compare & pull reqeust 버튼이 활성화 되어 있다.

##### 2. 충돌! Merge abort
<img src="./image/Conflict.png" width=700px>

- 1. 충돌이 났고, 브랜치 이름이 **(main | MERGING)** 일때,
    ```bash
    git merge --abort               /*main에서 하던 병합을 취소한다.*/
    ```
- 2. 다시 브랜치가 **(main)** 으로 돌아오면 취소 성공 

#### 3. 자신의 브랜치를 최신화하는 방법

```bash
git checkout escatrgot_dev                      /*1. 최신화 할 내 작업 브랜치*/
git stash                                       /*2. 혹시 수틀리면 복귀상태 Save*/
git reset --hard origin/main                    /*3. 최신화*/
git commit -am "Fetch : escatrgot_dev <- main"  /*4. 커밋하기*/
```

---

## 🧠 알고리즘 스터디

#### 1. 절차적 맵 생성(PCG)
 - 로그라이크에서 주로 사용되는 맵 생성 기법에 대해서 배워본다.
#### 2. 

---
## 🔖 에셋 스터디
[필수 에셋 정리](https://tagilog.tistory.com/914)

#### 1.[DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
<img src="https://assetstorev1-prd-cdn.unity3d.com/key-image/d28cf7c5-1e07-4494-81e3-bc3ca7539da6.webp" width="300" height="150"/>

- object-oriented animation engine이다.
- 사물 움직임에 쓰이기 때문에 **중요!!**

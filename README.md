# ๐ StudyforGameMaking
## ์๊ฐ
- ๊ฒ์ ๊ฐ๋ฐ์ ์ํ ์คํฐ๋ ๋ ํฌ์งํ ๋ฆฌ์๋๋ค.
- ๋ณธ์ธ ID๋ช์ผ๋ก ๋ธ๋์น๋ฅผ ๋ฐ๋ก ๋ง๋ค์ด ์ฐ๋, ๋ชจ๋์๊ฒ ๊ณต์ ํ  ์ ๋ณด๋ main์ผ๋ก ๋จธ์งํ์๋ฉด ๋ฉ๋๋ค.

---
## ๋ชฉ์ฐจ

- [๊นํ๋ธ ๊ด๋ฆฌ](#-๊นํ๋ธ-๊ด๋ฆฌ)
- [์๊ณ ๋ฆฌ์ฆ ์คํฐ๋](#-์๊ณ ๋ฆฌ์ฆ-์คํฐ๋)
- [์์ ์คํฐ๋](#-์์-์คํฐ๋)
- [์ ๋ํฐ API ์คํฐ๋](#-์ ๋ํฐ-api-์คํฐ๋)

#### ํด๋๋ชฉ์ฐจ
- [CS ์คํฐ๋](./CS_์ ๊ณต์ง์/README.md)
- [Unity ํด ์คํฐ๋](./Unity/README.md)

---

## ๐บ ๊นํ๋ธ ๊ด๋ฆฌ
- ๋ณธ์ธ ID๋ช์ผ๋ก ๋ธ๋์น๋ฅผ ๋ฐ๋ก ๋ง๋ค์ด ์ฐ๋, ๋ชจ๋์๊ฒ ๊ณต์ ํ  ์ ๋ณด๋ main์ผ๋ก ๋จธ์งํ์๋ฉด ๋ฉ๋๋ค.
#### 1. add commit push
```bash
git add *
git commit -m "_์ปค๋ฐ ๋ฉ์ธ์งใ_"
git push origin ID๋ช๋ธ๋์นใ
```

#### 2. *"๋ด ์์ ๋ธ๋์น"* <sub>์์ ์ปค๋ฐํ ๋ด์ฉ์</sub> *"main"*<sub>์ผ๋ก ๋ณํฉ</sub>

##### 1. Merge
- escatrgot_dev ์ปค๋ฐ๋ด์ฉ์ main์ผ๋ก ๋ณํฉ
    ```bash
    git checkout main               /*1. ๋ฉ์ธ์ด ๋๋ ๋ธ๋์น๋ก ์ด๋*/
    git merge escatrgot_dev         /*2. ํ์ฌ main๋ธ๋์น, ๋ค๋ฅธ ๋ธ๋์น๋ฅผ ๋ณํฉํ๋ค.*/
    git push origin main            /*3. ์ ์ฅ์์ ํธ์ฌ*/
    ```
 - push ์๋ฃ ํ ๋ณธ์ธ ๊ณ์ ์ github ์ ์ฅ์์ ๋ค์ด์ค๋ฉด Compare & pull reqeust ๋ฒํผ์ด ํ์ฑํ ๋์ด ์๋ค.

##### 2. ์ถฉ๋! Merge abort
<img src="./image/Conflict.png" width=700px>

- 1. ์ถฉ๋์ด ๋ฌ๊ณ , ๋ธ๋์น ์ด๋ฆ์ด **(main | MERGING)** ์ผ๋,
    ```bash
    git merge --abort               /*main์์ ํ๋ ๋ณํฉ์ ์ทจ์ํ๋ค.*/
    ```
- 2. ๋ค์ ๋ธ๋์น๊ฐ **(main)** ์ผ๋ก ๋์์ค๋ฉด ์ทจ์ ์ฑ๊ณต 

#### 3. ์์ ์ ๋ธ๋์น๋ฅผ ์ต์ ํํ๋ ๋ฐฉ๋ฒ

```bash
git checkout escatrgot_dev                      /*1. ์ต์ ํ ํ  ๋ด ์์ ๋ธ๋์น*/
git stash                                       /*2. ํน์ ์ํ๋ฆฌ๋ฉด ๋ณต๊ท์ํ Save*/
git reset --hard origin/main                    /*3. ์ต์ ํ*/
git commit -am "Fetch : escatrgot_dev <- main"  /*4. ์ปค๋ฐํ๊ธฐ*/
```

---

## ๐ง  ์๊ณ ๋ฆฌ์ฆ ์คํฐ๋

### 1. [์ ์ฐจ์  ์์ฑ(PCG)](https://github.com/ProjectLamb/Study/tree/neoskyclad/PCG)


---
## ๐ ์ ๋ํฐ API ์คํฐ๋

[์ ๋ํฐ API ์ ๋ฆฌ](https://github.com/ProjectLamb/Study/tree/hobak/Unity/Unity%20Api)

---
## ๐ ์์ ์คํฐ๋
[ํ์ ์์ ์ ๋ฆฌ](https://tagilog.tistory.com/914)

#### 1.[DOTween](https://assetstore.unity.com/packages/tools/animation/dotween-hotween-v2-27676)
<img src="https://assetstorev1-prd-cdn.unity3d.com/key-image/d28cf7c5-1e07-4494-81e3-bc3ca7539da6.webp" width="300" height="150"/>

- object-oriented animation engine์ด๋ค.
- ์ฌ๋ฌผ ์์ง์์ ์ฐ์ด๊ธฐ ๋๋ฌธ์ **์ค์!!**

<style>
    h3.quest { font-weight: bold; border: 3px solid; color: #A0F !important;}
    .quest { font-weight: bold; color: #A0F;}
    h2 { border-top: 12px solid #06E; border-left: 5px solid #06E; border-right: 5px solid #06E; background-color: #06E; color: #FFF !important; font-weight: bold;}

    h3 { border-top: 3px solid #FFF; border: 2px solid #FFF; background-color: #FFF; color: #0AE !important;}

    h4 { font-weight: bold; color: #FFF !important; }
</style>

## ๐น C# ์ด์๋ธ๋ฆฌ ๐น 

---

### ๐ 1. ์ด์๋ธ๋ฆฌ๊ฐ ๋ญ์ฃ 

*์ด์๋ธ๋ฆฌ์ด๋ ์๋๋ค.*
์ปดํ์ผ๋์ ๋์จ ํ์ผ์. C# ์์๋ ์ด์๋ธ๋ฆฌ(Assembly) ๋ผ๊ณ  ๋ถ๋ฅธ๋ค 
* **.exe, .dll**

  > exe ๋ Main() ๋ฉ์๋๋ฅผ ํฌํจํ๋(์ง์์ ) ํํ์ด๋ค.
  >   * ์ฝ์ ์คํ์ด ๊ฐ๋ฅํ๋ค.
  > dll ์ ๋ฐ๋๋ก ์ง์์ ์ด ์๋ ํํ์ด๋ค.

---

### ๐ 2. ...๊ทธ๋์? ๐ค

* #### โจ ์ด๊ฑฐ ํ๋๋ง ์ดํดํ์. โจ 
* #####  ์ด์๋ธ๋ฆฌ๊ฐ ๊ฐ์ ํ๋ก์ ํธ์ฌ์ผ internal ํ์ ์ ์ ๊ทผ์ด ๊ฐ๋ฅํ๋ค!!

> *...๋ญ๊ฐ ๋๋จํ๋ฐ*

---

### ๐ 3. ์ด์๋ธ๋ฆฌ๊ฐ ๋ค๋ฅธ [ํ๋ก์ ํธ & ํ์ผ]

<h4 style="text-align: center;"> GearHeart VS SoPhIA</h4>

|ํ์ผ๊ด์ |์ฝ๋๊ด์ |
|---|---|
|<img src="https://imgur.com/oYuHPjN.png">|<img src="https://imgur.com/YPAjRiL.png">|
|***๋ค๋ฅธ exe๋ผ์***|***๋ค๋ฅธ ํ๋ก์ ํธ๋ผ์***|

<h4 style="text-align: center;"> ์ฐ์ธก ์๋ฃจ์์ ๋๊ฐ์ ๊ฐ๊ฐ ์ฝ๋์ Namespace๊ฐ ๋ค๋ฅธ๊ฒ์ ํ์ธ ํ  ์ ์๋ค.</h4>

<p align="center">
    <img src="https://imgur.com/x6DGovP.png" width=700px>
</p>

---

### ๐ 4. ์ด์๋ธ๋ฆฌ๊ฐ ๊ฐ์ [ํ๋ก์ ํธ & ํ์ผ]

<h4 style="text-align: center;">Namespace๊ฐ ๊ฐ์๊ฒ์ด ๊ฐ์ ์ด์๋ธ๋ฆฌ์ด๋ค.</h4>

<p align="center">
    <img src="https://imgur.com/3BTOqUv.png">
</p>

### ๐ 5. ๊ฒฐ๋ก 
* #### 1. ํ๋ก์ ํธ(exe) ๊ฐ ๊ฐ๊ฐ ๋ค๋ฅธ๋์ Internal ์ ๊ทผ์ด ๋ถ๊ฐ๋ฅ.
* #### 2. namespace๊ฐ ๋ค๋ฅด๋ฉด Internal ์ ๊ทผ์ด ๋ถ๊ฐ๋ฅ

### ๐ 6. namespace๊ฐ ์์์๋ ์๋ค.
#### ํ๋ก์ ํธ์ ๊ตฌ์ ๋ฐ์ง ์๊ณ  ์ด๋์๋  ์ ๊ทผ ๊ฐ๋ฅํ๋ค๋๋ป์ด๋ค.


> **1. GearHeart์ ์๋ *Unit* ํด๋์ค๊ฐ ๋~๋ฌด ์๋ง๋ค์ด ์ก๋ค. ๐**
> **2. ๊ทธ๋์ ๋ค์ ํ๋ก์ ํธ(SoPhIA)์ Unit์ ์ฌ์ฉํด๋ณด๊ณ  ์ถ๋ค ๐ง**
> **3. ์์ธ! *Player*๋ฅผ *Unit* ํด๋์ค๋ก ๋ง๋ค์ด์ผ์ง~ ๐**
> *4. GearHeart์์ SoPhIA๋ก ๋ณต์ฌ ๋ถ์ฌ๋ฃ๊ธฐ ํ๋ฉด ๋๋๊ฑฐ ์๋๊ฐ? ใใ* ๐คทโโ๏ธ
> ***5. ์กฐ์ฉํ ํ์ธ์!!*** ๐คฌ  
> ์ง๊ธ **Public์ ์ ๋ง ์ด์ ์๊ด์์ด ์ด๋์๋  ์ ๊ทผ ๊ฐ๋ฅํ์ง** ์คํํ์์!!!

```cs
//namespace GearHaert { //namespace ์์ค๋ค
    public class Mobs   //public์ผ๋ก ๋ฐ๊ฟจ๋ค Internal ์ด๋ฉด ์ ๊ทผ ๋ชปํ๋ค. ํ๋ก์ ํธ๊ฐ ๋ค๋ฅด๋..
    {
        public interface IHitable { void GetHit(int _damage, String _hitBy); }
        public interface IInvincible { bool SetInvincibleState(); }
        public interface IDie{ void Die(); }

        public struct Coords 
        {
            public Coords(int x, int y) { this.x = x; this.y = y; }
            public int x {get;set;}
            public int y { get; set; }
        }

        public class Unit : IHitable, IDie
        {
            public int helthPoint = 0;
            public float forwardAngle = 0.0f;
            public bool invincibleState = false;
            public Coords position = new Coords(0, 0);

            public virtual void GetHit(int _damage, String _hitBy) {
                this.helthPoint -= _damage; //๋ฐ๋ฏธ์ง ๋ฐ๊ธฐ
                if (this.helthPoint < 0) { Die(); } 
            }
            public void Die() {
                Console.WriteLine("ํ ๋ ์ฃฝ์์ด ์ดํํธ ๋ปฅ~");
            }
        }
    }
//}
```

<p align="center">
    <img src="https://imgur.com/WtS8dDc.gif" width=900px>
</p>

|์ |ํ|
|---|---|
||<code>using static Mobs;<code> ๊ฐ ์๊น|
|<img src="https://imgur.com/z0WwPxD.png">|<img src="https://imgur.com/45i6aTG.png">|

#### namespace๊ฐ ์๊ณ , Public์ผ๋ก ์ ์๋ ํด๋์ค๋ ์ด๋์๋  ์ ๊ทผ์ด ์ง์ง ๊ฐ๋ฅํ๊ตฌ๋..
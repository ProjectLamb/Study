<p align="center">
  <img src="2022-12-30-17-19-34.png" width=500px>
</p>


<p align="center">
  <img src="2022-12-30-17-19-05.png" width=500px>
</p>

```cs
public class Monster {
    public Monster(){}

    protected int hp, damage, movespeed;
    protected Vector3 = new Vector3(0,0,0);
    protected abstract void attack();
    protected void walk(string animantion, int speed) {
        updateAnimation(animantion);
        setSpeed(speed);
    };

}

public class Ogre : Monster{
    public Ogre() {
        this.damage = 10;
        this.hp = 100;
        this.movespeed = 5;
    }
    public override void attack() {
        /*느리지만 존나 아픈 몽둥이 떄리맥이고~ */
    }
}
public class Skeleton : Monster{
    public Skeleton() {
        this.damage = 5;
        this.hp = 10;
        this.movespeed = 10;
    }
    public override void attack() {
        /* 와 샌즈! 블라스트!*/
    }
}
public class Ghoul : Monster{
    public Ghoul() {
        this.damage = 5;
        this.hp = 30;
        this.movespeed = 1;
    }
    public override void attack() {
        /*으어*/
    }
}
```
멈추는 방법을 도입하여 각 몬스터에게 좀 더 유연하게 움직일 수 있도록 합시다. 

<p align="center">
  <img src="2022-12-30-17-32-18.png" width=500px>
</p>

```cs
public class Movement {
    void walk(string animation, int speed) {
        updateAnimation(animation);
        setSpeed(speed);
    }
    void run(string animation) {
        updateAnimation(animation);
        setSpeed(speed);
    }
    void stop(string animation) {
        updateAnimation(animation);
        setSpeed(speed);
    }
}

public class Monster {
    public Monster(){}

    protected int hp, damage, movespeed;
    protected Vector3 = new Vector3(0,0,0);
    protected Movement movement;
    abstract void attack();
    protected void movement(string animation, int speed)
    {
        if(speed == movespeed*2) { movement.run(animation,speed); }
        else if(speed == movespeed) { movement.walk(animation,speed); }
        else { movement.stop(animation, speed); }
    }
    protected Movement GetMovement(return this.movement;)
}

public class Ogre : Monster{
    public Ogre() { this.damage = 10; this.hp = 100; this.movespeed = 5; }
    public override void attack() {
        /*느리지만 존나 아픈 몽둥이 떄리맥이고~ */
    }
}
public class Skeleton : Monster{
    public Skeleton() { this.damage = 5; this.hp = 10; this.movespeed = 10; }
    public override void attack() {
        /* 와 샌즈! 블라스트!*/
    }
}
public class Ghoul : Monster{
    public Ghoul() { this.damage = 5; this.hp = 30; this.movespeed = 1;}
    public override void attack() {
        /*으어*/
    }
}
```

<p align="center">
  <img src="2022-12-30-17-37-47.png" width=500px>
</p>

```cs
public class Movement
{
    public void walk(string animation, int speed) { }
    public void run(string animation) { }
    public void stop(string animation) { }
}

public abstract class Monster
{
    public Monster(Movement movement) { 
        this.movement = movement;
    }

    public abstract void Attack();

    protected int hp, damage, movespeed;
    protected int x, y, z;
    protected Movement movement;
    protected void Move(string animation, int speed)
    {
        if (speed == movespeed * 2) { movement.run(animation); }
        else if (speed == movespeed) { movement.walk(animation, speed); }
        else { movement.stop(animation); }
    }
    protected Movement GetMovement() { return this.movement; }
}

public abstract class ThingsThatFart : Monster
{
    public ThingsThatFart(Movement movement) : base(movement) { }
    public abstract void Fart();
}

public class Ogre : ThingsThatFart
{
    public Ogre(Movement movement) : base(movement) { this.damage = 10; this.hp = 100; this.movespeed = 5; }
    public override void Attack()
    {
        /*느리지만 존나 아픈 몽둥이 떄리맥이고~ */
    }
    public override void Fart()
    {
        /*푸드&*^&ㄲ*(@!*(!&*!#)(*%&(!)#%&#&득!*/
    }
}

public class Orc : ThingsThatFart
{
    public Orc(Movement movement) : base(movement) { this.damage = 10; this.hp = 100; this.movespeed = 5; }
    public override void Attack()
    {
        /*느리지만 존나 아픈 몽둥이 떄리맥이고~ */
    }
    public override void Fart()
    {
        /*푸득*/
    }
}
public class Skeleton : Monster
{
    public Skeleton(Movement movement) : base(movement) { this.damage = 5; this.hp = 10; this.movespeed = 10; }
    public override void Attack()
    {
        /* 와 샌즈! 블라스트!*/
    }
}
public class Ghoul : Monster
{
    public Ghoul(Movement movement) : base(movement) { this.damage = 5; this.hp = 30; this.movespeed = 1; }
    public override void Attack()
    {
        /*으어*/
    }
}
```
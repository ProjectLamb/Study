using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace SubclassSandbox
{
    //Superclass
    public abstract class Superpower
    {        
        //Active 함수는 서브클래스에서 상속받아 사용될 Sandbox 매소드다.
        public abstract void Activate();

        //이 클래스들은 이제 서브클래스에서 지지고 볶을수 있는 매소드다
            //정말 상위클래스는 하위클래스에게 모든걸 주는구나 = 하위클래스는 오직 상위 클래스간 커플링이 있구나.
        protected void Move(float speed) { Debug.Log("Moving with speed " + speed); }

        protected void PlaySound(string coolSound) { Debug.Log("Playing sound " + coolSound);}

        protected void SpawnParticles() {/*...*/}
    }


    //Subclasses
    public class SkyLaunch : Superpower
    {
        //본격적으로 상속받은 샌드박스 메소드를 구체화 한다.
        public override void Activate()
        {
            //Add operations this class has to perform
            Move(10f);
            PlaySound("SkyLaunch");
            SpawnParticles();
        }
    }

    //Subclasses
    public class GroundDive : Superpower
    {
        //Has to have its own version of Activate()
        public override void Activate()
        {
            //Add operations this class has to perform
            Move(15f);
            PlaySound("GroundDive");
            SpawnParticles();
        }
    }
    public class GameController : MonoBehaviour
    {
        List<Superpower> superPowers = new List<Superpower>();
        //스킬들을 저장하는 리스트

        void Start()
        {
            superPowers.Add(new SkyLaunch());
            superPowers.Add(new GroundDive());
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                for (int i = 0; i < superPowers.Count; i++) { superPowers[i].Activate(); }
            }
        }
    }
}
using System.Collections;
using UnitEngine;

namespace DesignPattern
{
    public interface CommandKey {
        public void Execute(GameObject obj);
    }

    public class CommandAttack : CommandKey {
        public void Execute(Gameobject obj) { Attack(obj); }
        void Attack(Gameobject obj){
            obj.transform.Translate(Vector3.forword);
        }
    }
    public class CommandDefense : CommandKey {
        public void Execute(GameObject obj){ Defense(obj);	 }

        void Defense(GameObject obj)
        {
            Debug.Log(obj.name + " Defense");
            obj.transform.Translate (Vector3.back);
        }
    }

    public class csPlayerCommand : MonoBehaviour {
        CommandKey btnA, btnB;

        void Start () { SetCommand(); }

        void SetCommand()
        {
            btnA = new CommandAttack();
            btnB = new CommandDefense();
        }

        public void BtnCommandA()
        {
            btnA.Execute(gameObject); // 이 스크립트가 붙은 오브젝트를 공격하게 함
        }
        public void BtnCommandB()
        {
            btnB.Execute(gameObject); // 이 스크립트가 붙은 오브젝트를 방어하게 함
        }

    }
} 
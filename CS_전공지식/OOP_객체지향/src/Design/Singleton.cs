// 일반적인 싱들톤
public class Singleton {
    private static readonly Singleton _instance = new Singleton();

    public static Singleton Instance {
        get {
            if(_instance == null) return new Singleton();
            return _instance;
        }
    }
}

//GameObject로 사용
public class _className_ : monoBehavier {
    private static _className_ _instance;

    public static _className_ Instanace {
        get{
            if(_instance == null){ 
                var obj = FindObjectType<_classNmae_>();
                if(obj != null){_instance = obj;}
                else if(obj == null) {
                    var newObj = new GameObject().AddComponent<_className_>();
                    return _instance;
                }
            }
        }
        private set;
    }
}


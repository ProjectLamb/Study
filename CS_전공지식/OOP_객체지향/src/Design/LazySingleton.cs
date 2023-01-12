public class LazySingleton {
    private static readonly Lazy<LazySingleton> _instance
        = new Lazy<LazySingleton>(() => new LazySingleton());

    public static LazySingleton Instance {
        get { return _instance.Value; }
        // _instance는 Lazy 객체 이므로 실제 인스턴스는 Value에 있다. 
    }
    private LazySingleton() { }
}
namespace DesignPattern{
    public enum Direction {
        Left = -1, Right = 1        
    }   
    public interface IBikeState {
        void Handle(BikeController bikeController);
    }

    public class BikeStateContext {
        public IBikeState currentState {get; set;}
        private readonly BikeController mBikeController;

        public BikeStateContext(BikeController _bikeController){
            this.mBikeController = _bikeController;
        }

        public void Transition(IBikeState _state){
            currentState = _state;
            currentState.Handle(mBikeController);
        }
    }
    /*BikeController.cs*/
    public class BikeController : MonoBehaviour {
        [field : SerializeField] public float maxSpeed {get; private set;} = 2.0f;
        [field : SerializeField] public float turnDistance {get; private set;} = 2.0f;
        public float currentSpeed {get;set;}
        public Direction currentTurnDirection {get; private set;}

        private IBikeState mStartState;
        private IBikeState mStopState;
        private IBikeState mTurntState;

        private BikeStateContext mBikeStateContext;
        private void Awake() {
            mBikeStateContext = new BikeStateContext(this);
            mStartState = gameobject.AddComponent<BikerStateState>();
            mStopState = gameobject.AddComponent<BikerStopState>();
            mTurntState = gameobject.AddComponent<BikerTurnState>();
            mBikeStateContext.Transition(mStopState);
        }
        
        public void StartBike()
        {
            mBikeStateContext.Transition(mStartState);
        }

        public void StopBike()
        {
            mBikeStateContext.Transition(mStopState);
        }

        public void Turn(Direction direction)
        {
            urrentTurnDirection = direction;
            mBikeStateContext.Transition(mTurntState);
        }

    }
    /*ClientState.cs*/
    public class ClientState : MonoBehaviour {
        private BikeController mBikeController;
        private void Awake(){
            MonoBehaviour = GetComponent<BikeController>();
        }

        private void OnGUI(){
            if (GUILayout.Button("Start Bike"))
            {
                mBikeController.StartBike();
            }

            if (GUILayout.Button("Turn Left"))
            {
                mBikeController.Turn(Direction.Left);
            }

            if (GUILayout.Button("Turn Right"))
            {
                mBikeController.Turn(Direction.Right);
            }

            if (GUILayout.Button("Stop Bike"))
            {
                mBikeController.StopBike();
            }
        }
    }
}
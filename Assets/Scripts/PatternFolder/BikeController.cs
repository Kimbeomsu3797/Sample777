using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
namespace Chapter.State
{
    public class BikeController : MonoBehaviour
    {
        public float maxSpeed = 2.0f;
        public float turnDistance = 2.0f;
        public float CurrentSpeed { get; set; }
        public Direction CurrentTurnDirection;
        private IBikeState _startState, _stopState, _turnState;
        private BikeStateContext _bikeStateContext;

        // Start is called before the first frame update
        void Start()
        {
            _bikeStateContext = new BikeStateContext(this);

            _startState = gameObject.AddComponent<BikeStartState>();
            _stopState = gameObject.AddComponent<BikeStopState>();
            _turnState = gameObject.AddComponent<BikeTurnState>();

            _bikeStateContext.Transition(_stopState);
        }
        public void StartBike()
        {
            _bikeStateContext.Transition(_startState);
        }
        public void StopBike()
        {
            _bikeStateContext.Transition(_stopState);
        }
        public void Turn(Direction direction)
        {
            CurrentTurnDirection = direction;
            _bikeStateContext.Transition(_turnState);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.State
{
    public class BikeStartState : MonoBehaviour, IBikeState
    {
        private BikeController _bikeController;
        public void Handle(BikeController bikeController)
        {
            if (!_bikeController)
            {
                _bikeController = bikeController;
            }
            _bikeController.CurrentSpeed = _bikeController.maxSpeed;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (_bikeController)
            {
                if(_bikeController.CurrentSpeed > 0)
                {
                    _bikeController.transform.Translate(Vector3.forward * (_bikeController.CurrentSpeed * Time.deltaTime));
                }
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;

        private void Start()
        {

            gameObject.AddComponent<HUDController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();
            _isButtonEnabled = false;

        }
        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.STOP, Restart);

        }
        private void OnDisable()
        {
            RaceEventBus.Unsubcribe(RaceEventType.STOP, Restart);
        }
        void Restart()
        {
            _isButtonEnabled = true;
        }
        private void OnGUI()
        {
            if (_isButtonEnabled)
            {
                if(GUILayout.Button("Start Countdown"))
                {
                    _isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.COUNTDOWN);
                }
            }
        }
    }
}


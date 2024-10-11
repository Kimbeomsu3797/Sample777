using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.EventBus
{
    public class BikeController : MonoBehaviour
    {
        private string _status;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, StartBike);
            RaceEventBus.Subscribe(RaceEventType.STOP, StopBike);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubcribe(RaceEventType.START, StartBike);
            RaceEventBus.Unsubcribe(RaceEventType.STOP, StopBike);
        }
        private void StartBike()
        {
            _status = "Started";
        }
        private void StopBike()
        {
            _status = "Stopped";
        }
        private void OnGUI()
        {
            GUI.color = Color.green;
            GUI.Label(new Rect(10, 60, 200, 20), "BIKE STATUS: " + _status);
        }
    }
}


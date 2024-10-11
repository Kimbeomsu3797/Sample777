using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Chapter.EventBus
{
    public class HUDController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.START, DisplayHUD);
                
           
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubcribe(RaceEventType.START, DisplayHUD);
        }
        private void DisplayHUD()
        {
            _isDisplayOn = true;
        }
        private void OnGUI()
        {
            if (_isDisplayOn)
            {
                if(GUILayout.Button("Stop Race"))
                {
                    _isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.STOP);// 확실하지않음
                }
            }
        }
    }
}


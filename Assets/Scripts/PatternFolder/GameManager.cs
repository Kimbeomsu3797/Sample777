using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace Chapter.State
{
    public enum Direction
    {
        Left = -1,
        Right = 1,

    }
}
public class GameManager : MonoBehaviour
{
    private DateTime _sessionStartTime;
    private DateTime _sessionEndTime;

    private void Start()
    {
        // Todo: (�������� �۾� ���)
        //�÷��̾� ���̺� �ε忡 �ð� ����
        _sessionStartTime = DateTime.Now;
        
    }
    private void OnApplicationQuit()
    {
        //���� ���� �ð� ����
        //subtract(timespan) �� �ν��Ͻ��� ������ ������ �Ⱓ�� �� �� datetime�� ��ȯ�մϴ�.
        //subtract(datetime) �� �ν��Ͻ��� ������ ������ ��¥�� �ð��� �� �� timespan�� ��ȯ�մϴ�.
        _sessionEndTime = DateTime.Now;
        TimeSpan timeDifference = _sessionEndTime.Subtract(_sessionStartTime);

    }
    private void OnGUI()
    {
        if(GUILayout.Button("Next Scene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

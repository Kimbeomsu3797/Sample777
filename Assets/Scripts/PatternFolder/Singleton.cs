using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T _instance;

    public static T Instance
    {
        //get�����ڷ� public ctatic �Ӽ��� �����ߴ�.
        //�� �����ڿ��� ���ο� �ν��Ͻ��� �ʱ�ȭ�ϱ� ���� �ٸ� �ν��Ͻ��� Ȯ���Ѵ�
        get
        {
            if(_instance == null)
            {
                //findobjectoftype�� ������ Ÿ���� ù��°�� �ε�� ������Ʈ�� �˻�
                _instance = FindObjectOfType<T>();
                //ã�������ٸ� ���ο� gameobj�� �����ϰ� �̸����� �� ������������ ������ ���۳�Ʈ�� �߰�
                if(_instance == null)
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }
            return _instance;
        }
        
    }
    //�̱��� Ŭ������ �������κ� ����
    //�Ļ� Ŭ�������� �ٽ� ������ �� �ִٴ� �ǹ��� virtual awake�޼���
    //awake���� �޸𸮿� �ʱ�ȭ�� �ڽ��� �ν��Ͻ��� �̹� �ִ��� Ȯ��
    //�̹� �ִٸ� ������ �������� ������ ����
    public virtual void Awake()
    {
        if(_instance == null)
        {
            _instance = this as T;
            //�̰� �ν��Ͻ����
            //�̰� �����ϴ°� ����
            //���� ���� ��ȯ�Ǿ �����ǵ����ϱ� ���Ͽ� �̷��� �ۼ�
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

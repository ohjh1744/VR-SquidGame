using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Younghee : MonoBehaviour
{

    public int nextturn;
    public bool check; //���� �ڵ��ƺô���Ȯ�� 
    public Text time;
    public bool g_start; //time �Ǹ� ���ӽ���
    bool b; //�ѹ��� �����ϵ���

    AudioSource audio;

    void Awake()
    {
        audio = GetComponent<AudioSource>(); 
    }

    void Update()
    {
        if (g_start && !b)
        {
            GameStart();
            b = true;
        }       
    }

    public void GameStart()
    {
        if (g_start)
        {
            Debug.Log("������ �����Ͽ����ϴ�.");
            Turnback();
        }
    }
    public void Turn()  // �ڵ��ƺ���
    {
        Debug.Log("�ڵ��ƺõ�!");
        check = true;
        //�ڵ��ƺ��� ��Ҹ�����
        audio.mute = true;
        Invoke("Turnback", 3); // �ڵ��ƺ��� 3�ʵڿ� �ٽ� ������.
    }

    public void Turnback()  // �ٽ� ���Ƽ� ������
    {
        Debug.Log("����ȭ ���� �Ǿ�~");
        check = false;
        nextturn = Random.Range(3, 6); // 3~5����
        //���̽�Ʋ��
        audio.mute = false;
        audio.Play();
        Invoke("Turn", nextturn);
    }
}

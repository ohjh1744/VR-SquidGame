using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oddEvenButton : MonoBehaviour
{
    // Start is called before the first frame update

    
    public static bool odd = true;
    public static bool even = false;
    public static bool choice_finished = false; //���� 1���� �����Ҽ��ֵ���
    public bool canchoose = false;  //oddEvenGame���� �����ִ� �ܰ谡���� true�� �ٲ�鼭 ���ð���.

    public GameObject player;
    void Update()
    {
         canchoose = player.GetComponent<oddEvenGame>().havetochoose;
        if(canchoose == false)
        {
            choice_finished = false;
            odd = true;  // �ȴ����� �ڵ������� odd���õǰ�
            even = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if((other.tag == "Lefthand" || other.tag == "Righthand") && canchoose && !choice_finished )
        {
            choice_finished = true;
            if (gameObject.tag == "odd")
            {
                odd = true;
                even = false;
                Debug.Log("Ȧ ����");
            }
            else if(gameObject.tag == "even")
            {
                odd = false;
                even = true;
                Debug.Log("¦ ����");
            }
        }
    }
}

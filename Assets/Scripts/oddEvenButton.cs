using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oddEvenButton : MonoBehaviour
{
    // Start is called before the first frame update

    
    public static bool odd = true;
    public static bool even = false;
    public static bool choice_finished = false; //매판 1번만 선택할수있도록
    public bool canchoose = false;  //oddEvenGame에서 고를수있는 단계가오면 true로 바뀌면서 선택가능.

    public GameObject player;
    void Update()
    {
         canchoose = player.GetComponent<oddEvenGame>().havetochoose;
        if(canchoose == false)
        {
            choice_finished = false;
            odd = true;  // 안누르면 자동적으로 odd선택되게
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
                Debug.Log("홀 누름");
            }
            else if(gameObject.tag == "even")
            {
                odd = false;
                even = true;
                Debug.Log("짝 누름");
            }
        }
    }
}

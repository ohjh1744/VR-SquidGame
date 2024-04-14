using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public GameObject younghee;
    bool isyhb;
    Rigidbody rigid;

    public Text timer;
    public int onechance;

    AudioSource audio;
    bool isdead = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        // 무궁화 꽃게임 뒤돌아볼때 죽는로직
        // 나중에 gameManager 만들어서 stage1에서만 작동하게 관리하자.
        isyhb = younghee.GetComponent<Younghee>().check;
        onechance = timer.GetComponent<Timer>().gamecontinue;

        // 영희가 뒤돌아봣을때 움직이거나, 시간이 다지나면 죽게.
        if (isyhb)
        {
            if(rigid.velocity != Vector3.zero && !isdead) 
            {
                Dead();
                isdead = true;
                              
            }
        }
        else if(onechance > 1 && !isdead)
        {
            Dead();
            isdead = true;

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            CurrentStage.stage1_clear = true;
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Back_Finish")
        {
            SceneManager.LoadScene(1);
        }
    }

    void Dead()
    {
        //총맞은 느낌 구현.
        audio.Play();
        rigid.AddForce(new Vector3(0, 100, -100));
        Debug.Log("죽었따!");
        Invoke("Restart", 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}

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
        // ����ȭ �ɰ��� �ڵ��ƺ��� �״·���
        // ���߿� gameManager ���� stage1������ �۵��ϰ� ��������.
        isyhb = younghee.GetComponent<Younghee>().check;
        onechance = timer.GetComponent<Timer>().gamecontinue;

        // ���� �ڵ��Ɣf���� �����̰ų�, �ð��� �������� �װ�.
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
        //�Ѹ��� ���� ����.
        audio.Play();
        rigid.AddForce(new Vector3(0, 100, -100));
        Debug.Log("�׾���!");
        Invoke("Restart", 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
    }
}

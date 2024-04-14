using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_glassbridge : MonoBehaviour
{

    public GameObject[] odd_glass;
    public GameObject[] even_glass;
    public GameObject[] fake_glass;
    public GameObject[] real_glass;
    public GameObject[] teleport_block;

    public Material rg_mat;
    public Material fg_mat;

    AudioSource audio;
    public AudioClip broken_glass;
    public AudioClip gun;

    public bool gamestart;
    public bool gamefinish;

    bool co_ing;
    bool time_set; // update�Լ����� audio.play�� �Լ�����Ǽ� �Ҹ��� �ȵ鸲. �ѹ��� �����ϰ��ϱ����� ����.

    int correct = 2; //�� ��� ���� ����ߴ���


    void Awake()
    {
        fake_glass = new GameObject[14];
        real_glass = new GameObject[14];
        choose_randomglass();
        audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        
        if (gamestart && !co_ing)
        {
            co_ing = true;
            StartCoroutine("shining");
        }
        //�ð��ʰ��ϸ� ����.
        if (gamefinish && !time_set)
        {
            time_set = true;
            Dead();
        }

    }

    void Dead()
    {
        audio.clip = gun;
        audio.Play();
        Debug.Log("�׾���!");
        Invoke("Restart", 1);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Dieborder�� ������ retry
        if(collision.gameObject.tag == "DieBorder")
        {
            Restart();
        }

        //��¥���������� �ݶ��̴� ����
        if(collision.gameObject.tag == "Glass")
        {
            for(int i = 0; i < 14; i++)
            {
                if(collision.gameObject == fake_glass[i])
                {
                    collision.gameObject.GetComponent<Collider>().isTrigger = true;
                }
                //��¥���������� �տ� �ڷ���Ʈ�溮���ֱ�
                else if(collision.gameObject == real_glass[i])
                {
                    teleport_block[i].SetActive(false);
                }
            }
        }




    }


    void OnTriggerEnter(Collider other)
    {
        //��¥���� ������ �������� �����¼Ҹ�
        if(other.gameObject.tag == "Glass")
        {
            other.gameObject.SetActive(false);
            audio.clip = broken_glass;
            audio.Play();
        }
        

        if (other.gameObject.tag == "Finish")
        {
            CurrentStage.stage3_clear = true;
            SceneManager.LoadScene(1);
        }

        if (other.tag == "Back_Finish")
        {
            SceneManager.LoadScene(1);
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(4);
    }


    void choose_randomglass()
    {
        for(int i = 0; i < 14; i++)
        {
            int c = Random.Range(1, 3); // 1~2
            if(c == 1)
            {
                fake_glass[i] = odd_glass[i];
                real_glass[i] = even_glass[i];
                Debug.Log("odd_glass" + i);
            }
            else
            {
 
                fake_glass[i] = even_glass[i];
                real_glass[i] = odd_glass[i];
                Debug.Log("even_glass" + i);
            }
        }
    }

    IEnumerator shining()
    {
        yield return new WaitForSeconds(6f);
        for(int i = 0; i < 14; i++)
        {
            fake_glass[i].GetComponent<MeshRenderer>().material = fg_mat; 
        }
        yield return new WaitForSeconds(1f);
        for(int i = 0; i < 14; i++)
        {
            fake_glass[i].GetComponent<MeshRenderer>().material = rg_mat;
        }
        co_ing = false;
    }


}

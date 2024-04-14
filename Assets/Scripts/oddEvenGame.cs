using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oddEvenGame : MonoBehaviour
{

    public GameObject EnemyImage;
    public Text Enemytext;
    int tel_chance; //�ڷ���Ʈ �ѹ��ϸ� ���ӽ����ϵ���, ������ �ڷ���Ʈ�Ҷ� ������ ���������ϴ°� �������� ����, ���� �ڷ���Ʈ��� �ѹ��������ϰ�
    bool gstart = true; //�ڷ���Ʈ�ϸ� ���ӽ����ϱ����� ����.

    int pearl;

    public bool havetochoose = false; //��ư�Լ����� �Ѱ��ִ� ���ڰ�. ���� �ܰ迡���� �����ֵ���.
    public GameObject odd_button;
    public GameObject even_button;

    public Text Enemy_Point_text;
    public Text Player_Point_text;

    int enemy_point = 0;
    int player_point = 0;

    public GameObject finish;
    public GameObject finish_teleport_area;

    Rigidbody rigid;

    public GameObject Enemy;
    Animator anim;
    AudioSource audio;

    public GameObject In_image;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = Enemy.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(tel_chance == 1 && gstart)
        {
            gstart = false;
            StartCoroutine("GameStart");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.tag == "teleport_area")
      {
            tel_chance++;
      }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Finish")
        {
            CurrentStage.stage4_clear = true;
            SceneManager.LoadScene(1);
        }
        if (other.tag == "Back_Finish")
        {
            SceneManager.LoadScene(1);
        }
    }
    IEnumerator GameStart()
    {
        yield return new WaitForSeconds(1f);
        Enemytext.text = "3��2������ �������� Ȧ��������, ¦�������� ���߸� ��";

        int n = 3;
        while (n > 0)
        {
            random_pearl();
            Debug.Log(pearl);

            yield return new WaitForSeconds(5f);
            Enemytext.text = "(���� ���� ��)";

            yield return new WaitForSeconds(5f);
            Enemytext.text = "Ȧ? ¦? ������ �ð� 10�� �ٰ�";
            havetochoose = true;

            yield return new WaitForSeconds(10f);

            Enemytext.text = "�� ������...!!";

            yield return new WaitForSeconds(5f);
            if (oddEvenButton.odd && (pearl % 2 == 1))
            {
                Enemytext.text = "�� ������ " + pearl + "����.. ���� ���ұ�..";
                player_point++;
                Player_Point_text.text = "" + player_point;
            }
            else if (!oddEvenButton.odd && (pearl % 2 == 1))
            {
                Enemytext.text = "�� ������ " + pearl + "����!! ŪŪ Ʋ�ȱ�..";
                enemy_point++;
                Enemy_Point_text.text = "" + enemy_point;
            }
            else if (oddEvenButton.even && (pearl % 2 == 0))
            {
                Enemytext.text = "�� ������ " + pearl + "����.. ���� ���ұ�..";
                player_point++;
                Player_Point_text.text = "" + player_point;
            }
            else if (!oddEvenButton.even && (pearl % 2 == 0))
            {
                Enemytext.text = "�� ������ " + pearl + "����!! ŪŪ Ʋ�ȱ�..";
                enemy_point++;
                Enemy_Point_text.text = "" + enemy_point;
            }

            n--;
            havetochoose = false;
        }

        yield return new WaitForSeconds(4f);
        if (player_point > enemy_point) //�¸��ҽ�
        {
            Enemytext.text = "���� ���ٴ�!";
            // ���� �״� �Լ��� ����������� animation
            audio.Play();
            anim.SetBool("isDead", true);
            
            finish.SetActive(true);
            finish_teleport_area.SetActive(true);
            In_image.SetActive(true);

            yield return new WaitForSeconds(4f);
            EnemyImage.SetActive(false);

        }
        else //�й��
        {
            Enemytext.text = "ŪŪ ����� ������!";
            audio.Play();
            rigid.AddForce(new Vector3(0, 100, -100));

            yield return new WaitForSeconds(3f);
            SceneManager.LoadScene(5);
        }
        

    }



    void random_pearl()
    {
        pearl = Random.Range(1, 5); // 1,2,3,4
       
    }
}

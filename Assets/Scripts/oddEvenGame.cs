using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class oddEvenGame : MonoBehaviour
{

    public GameObject EnemyImage;
    public Text Enemytext;
    int tel_chance; //텔레포트 한번하면 게임시작하도록, 여러번 텔레포트할때 게임이 계속재시작하는거 막기위한 변수, 또한 텔레포트기능 한번만가능하게
    bool gstart = true; //텔레포트하면 게임시작하기위한 변수.

    int pearl;

    public bool havetochoose = false; //버튼함수에서 넘겨주는 인자값. 고르는 단계에서만 고를수있도록.
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
        Enemytext.text = "3판2선제로 내구슬이 홀수개인지, 짝수개인지 맞추면 돼";

        int n = 3;
        while (n > 0)
        {
            random_pearl();
            Debug.Log(pearl);

            yield return new WaitForSeconds(5f);
            Enemytext.text = "(구슬 섞는 중)";

            yield return new WaitForSeconds(5f);
            Enemytext.text = "홀? 짝? 생각할 시간 10초 줄게";
            havetochoose = true;

            yield return new WaitForSeconds(10f);

            Enemytext.text = "내 구슬은...!!";

            yield return new WaitForSeconds(5f);
            if (oddEvenButton.odd && (pearl % 2 == 1))
            {
                Enemytext.text = "내 구슬은 " + pearl + "개야.. 운이 좋았군..";
                player_point++;
                Player_Point_text.text = "" + player_point;
            }
            else if (!oddEvenButton.odd && (pearl % 2 == 1))
            {
                Enemytext.text = "내 구슬은 " + pearl + "개야!! 큭큭 틀렸군..";
                enemy_point++;
                Enemy_Point_text.text = "" + enemy_point;
            }
            else if (oddEvenButton.even && (pearl % 2 == 0))
            {
                Enemytext.text = "내 구슬은 " + pearl + "개야.. 운이 좋았군..";
                player_point++;
                Player_Point_text.text = "" + player_point;
            }
            else if (!oddEvenButton.even && (pearl % 2 == 0))
            {
                Enemytext.text = "내 구슬은 " + pearl + "개야!! 큭큭 틀렸군..";
                enemy_point++;
                Enemy_Point_text.text = "" + enemy_point;
            }

            n--;
            havetochoose = false;
        }

        yield return new WaitForSeconds(4f);
        if (player_point > enemy_point) //승리할시
        {
            Enemytext.text = "내가 지다니!";
            // 상대방 죽는 함수만 집어넣으면댈듯 animation
            audio.Play();
            anim.SetBool("isDead", true);
            
            finish.SetActive(true);
            finish_teleport_area.SetActive(true);
            In_image.SetActive(true);

            yield return new WaitForSeconds(4f);
            EnemyImage.SetActive(false);

        }
        else //패배시
        {
            Enemytext.text = "큭큭 우승은 내꺼다!";
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

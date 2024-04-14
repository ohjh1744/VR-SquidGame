using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Player_rope : MonoBehaviour
{
    Rigidbody rigid;
    public Rigidbody enemy1;
    public Rigidbody enemy2;
    public Rigidbody enemy3;
    public Rigidbody rope;

    public GameObject enemy_rope;

    public InputActionReference PullRope;
    public float power;

    public Text timer;
    public GameObject win_text;

    public Animator red1_anim;
    public Animator red2_anim;
    public Animator red3_anim;


    public GameObject player_floor;
    public GameObject enemy_floor;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        enemy1 = enemy1.GetComponent<Rigidbody>();
        enemy2 = enemy2.GetComponent<Rigidbody>();
        enemy3 = enemy3.GetComponent<Rigidbody>();
        rope = rope.GetComponent<Rigidbody>();
        red1_anim = red1_anim.GetComponent<Animator>();
        red2_anim = red2_anim.GetComponent<Animator>();
        red3_anim = red3_anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        whoiswinner();
    }

    void FixedUpdate()
    {
        if (enemy_rope.GetComponent<Enemy_rope>().g_start)
        {
            PullRope.action.performed += Pull;
        }
      
    }

    void Pull(InputAction.CallbackContext obj)
    {
        if(touch_rope.Lhand_touch == true && touch_rope.Rhand_touch == true)
        {
            rigid.velocity = new Vector3(0, 0, -1) * power;
            enemy1.velocity = new Vector3(0, 0, -1) * power;
            enemy2.velocity = new Vector3(0, 0, -1) * power;
            enemy3.velocity = new Vector3(0, 0, -1) * power;
            rope.velocity = new Vector3(0, 0, -1) * power;
        }
    }


    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Back_Finish")
        {
            SceneManager.LoadScene(1);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(3);
    }

    void whoiswinner()  //1�� player win 2�� enemy win
    {
        if (timer.GetComponent<Stage2_Timer>().player_win)
        {
            Win();
        }
        else if (timer.GetComponent<Stage2_Timer>().enemy_win)
        {
            Lose();
        }
    }
    void Win()
    {
        //���߿� �ؽ�Ʈ �����ؼ� you win! ���̰�����.
        win_text.SetActive(true);
        //�� �ٸ� ���ֱ�
        enemy_floor.SetActive(false);
        //�������� �ִϸ��̼�����
        red1_anim.SetBool("isFall", true);
        red2_anim.SetBool("isFall", true);
        red3_anim.SetBool("isFall", true);
        // �κ������ ����
        CurrentStage.stage2_clear = true;
        Invoke("next_stage", 5);
    }

    void next_stage()
    {
        SceneManager.LoadScene(1);
    }

    void Lose()
    {
        player_floor.SetActive(false);
        Invoke("Restart", 3);
    }
}

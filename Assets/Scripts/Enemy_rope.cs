using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_rope : MonoBehaviour
{
    Rigidbody rigid;
    public Rigidbody player;
    public Rigidbody enemy_2;
    public Rigidbody enemy_3;
    public Rigidbody rope;
    public int num;
    public float power;

    public bool g_start;
    bool one; //Pullrope 한번만 실행하게하기위한

    public Text timer;
    bool gamefinish = false;

    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        player = player.GetComponent<Rigidbody>();
        enemy_2 = enemy_2.GetComponent<Rigidbody>();
        enemy_3 = enemy_3.GetComponent<Rigidbody>();
        rope = rope.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(timer.GetComponent<Stage2_Timer>().player_win == true || timer.GetComponent<Stage2_Timer>().enemy_win == true)
        {
            gamefinish = true;
        }
    }
    void FixedUpdate()
    {
        
        if (g_start && !one)
        {
            Pullrope();
            one = true;
        }
    }

    void Pullrope()
    {
        if (gamefinish)
        {
            power = 0;
        }
        rigid.velocity = new Vector3(0, 0, 1) * power;
        player.velocity = new Vector3(0, 0, 1) * power;
        enemy_2.velocity = new Vector3(0, 0, 1) * power;
        enemy_3.velocity = new Vector3(0, 0, 1) * power;
        rope.velocity = new Vector3(0, 0, 1) * power;
        num = Random.Range(0, 2);
        Invoke("Pullrope", num);
    }
}

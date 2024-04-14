using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    public InputActionReference jump;
    public float jump_power;
    bool isjump;
    Rigidbody rigid;

    void Start()
    {
        rigid = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        jump.action.performed += Onjump;
        
    }


    void Onjump(InputAction.CallbackContext obj)
    {
        if (!isjump)
        {
            rigid.AddForce(Vector3.up * jump_power);
            isjump = true;
        }     
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Glass")
        {
            isjump = false;
        }
    }

}

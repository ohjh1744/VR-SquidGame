using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touch_rope : MonoBehaviour
{
    static public bool Lhand_touch;
    static public bool Rhand_touch;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Lefthand")
        {
            Lhand_touch = true;
        }
        if(other.gameObject.tag == "Righthand")
        {
            Rhand_touch = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Lefthand")
        {
            Lhand_touch = false;
            Debug.Log("¿ÞÂÊ¼Õ¶«: " + Lhand_touch);
        }
        if (other.gameObject.tag == "Righthand")
        {
            Rhand_touch = false;

        }
    }
}

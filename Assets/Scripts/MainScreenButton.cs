using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScreenButton : MonoBehaviour
{
    
    public void Yes_Button()
    {
        SceneManager.LoadScene(1);
    }

    // ������ �����ϱ⿡���� �� ��ũ��Ʈ�� ���.
    public void Quit_Button()
    {
        Application.Quit();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_rest : MonoBehaviour
{

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Start_Finish")
        {
            // ù���� ����
            if (!CurrentStage.stage1_clear && !CurrentStage.stage2_clear && !CurrentStage.stage3_clear && !CurrentStage.stage4_clear)
            {
                SceneManager.LoadScene(2);
            }
            //�ι�°���� ����
            else if (CurrentStage.stage1_clear)
            {
                SceneManager.LoadScene(3);
                CurrentStage.stage1_clear = false;
            }
            //����°���� ����
            else if(CurrentStage.stage2_clear)
            {
                SceneManager.LoadScene(4);
                CurrentStage.stage2_clear = false;
            }
            //�׹�°���� ����
            else if(CurrentStage.stage3_clear)
            {
                SceneManager.LoadScene(5);
                CurrentStage.stage3_clear = false;
            }
            //�ٳ����� ������� ���ƿ���
            else if(CurrentStage.stage4_clear)
            {
                CurrentStage.stage4_clear = false;
                SceneManager.LoadScene(1);
                
            }

        }

        if (other.gameObject.tag == "End_Finish")
        {
            Application.Quit();
        }
    }

}

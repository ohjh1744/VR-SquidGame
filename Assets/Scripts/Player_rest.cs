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
            // 첫라운드 들어가기
            if (!CurrentStage.stage1_clear && !CurrentStage.stage2_clear && !CurrentStage.stage3_clear && !CurrentStage.stage4_clear)
            {
                SceneManager.LoadScene(2);
            }
            //두번째라운드 들어가기
            else if (CurrentStage.stage1_clear)
            {
                SceneManager.LoadScene(3);
                CurrentStage.stage1_clear = false;
            }
            //세번째라운드 들어가기
            else if(CurrentStage.stage2_clear)
            {
                SceneManager.LoadScene(4);
                CurrentStage.stage2_clear = false;
            }
            //네번째라운드 들어가기
            else if(CurrentStage.stage3_clear)
            {
                SceneManager.LoadScene(5);
                CurrentStage.stage3_clear = false;
            }
            //다끝나면 원래대로 돌아오기
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

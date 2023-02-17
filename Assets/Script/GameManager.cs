using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public string GameOverScene;

    // Start is called before the first frame update
    void Start()
    {
        //Screen.SetResolution(1920, 1080, false);//1920x1080�̃E�B���h�E���[�h
        //Application.targetFrameRate = 60;
        appleCount = 0;
        Hpcount = 3;
        brakeCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Esc�������ꂽ���Q�[���v���C�I��
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
        }

        //�v���C���[�����񂾂Ƃ��Q�[���I�[�o�[��ʂɈړ�
        if (player.Hp <= 0)
        {
            ChanegeScene();
        }
        
        //�����S��100�W�܂������Ɏc�@��1���₷
        if(appleCount==100)
        {
            appleCount = 0;
            player.AddRemainingLives();
        }
    }

    //�󂹂�u���b�N�̃J�E���g
    public Text textBrakeBlock;
    private int brakeCount;

    /// <summary>
    /// �󂹂�u���b�N�𑝂₷
    /// </summary>
    public void BrakeBlockCount()
    {
        brakeCount += 1;
        textBrakeBlock.text = "x" + brakeCount+ "/17";
    }

    //�����S�̃J�E���g
    public Text textComponent;
    private int appleCount;

    /// <summary>
    /// �����S�𑝂₷
    /// </summary>
    public void AddAppleCount()
    {
        appleCount += 1;
        textComponent.text = "x" + appleCount;
    }

    //HP�̃J�E���g
    public Text Hptext;
    private int Hpcount;

    /// <summary>
    /// HP�����炷
    /// </summary>
    public void SubHp()
    {
        Hpcount -= 1;
        Hptext.text = "x" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" +
            "" + Hpcount;
     }

    //�V�[���؂�ւ��i�Q�[���I�[�o�[�j
    public void ChanegeScene()
    {
        SceneManager.LoadScene(GameOverScene);
    }
}

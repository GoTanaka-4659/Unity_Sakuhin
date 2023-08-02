using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public string GameOverScene;
    public string MaxBrakeBlock;

    // Start is called before the first frame update
    void Start()
    {
        appleCount = 0;
        Hpcount = 3;
        brakeCount = 0;
       // appleCount = PlayerPrefs.GetInt("AppleCount");
        //brakeCount = PlayerPrefs.GetInt("BrakeBlock");

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
            Initiate.Fade(GameOverScene, Color.red, 1.0f);
            //ChanegeScene();
        }

        //�����S��100�W�܂������Ɏc�@��1���₷
        if (appleCount == 100)
        {
            appleCount = 0;
            player.AddRemainingLives();
        }
    }

    //�󂹂�u���b�N�̃J�E���g
    public Text textBrakeBlock;
    public int brakeCount;

    /// <summary>
    /// �󂹂�u���b�N�𑝂₷
    /// </summary>
    public void BrakeBlockCount()
    {
        brakeCount += 1;
        textBrakeBlock.text = "x" + brakeCount + MaxBrakeBlock;
    }

    //�����S�̃J�E���g
    public Text textComponent;
    public int appleCount;

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
    public void SubHpUI()
    {
        Hpcount -= 1;
        Hptext.text = "x" + Hpcount;
    }

    //�V�[���؂�ւ��i�Q�[���I�[�o�[�j
    public void ChanegeScene()
    {
        SceneManager.LoadScene(GameOverScene);

    }
}

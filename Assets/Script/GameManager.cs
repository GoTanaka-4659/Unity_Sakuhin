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
        //Screen.SetResolution(1920, 1080, false);//1920x1080のウィンドウモード
        //Application.targetFrameRate = 60;
        appleCount = 0;
        Hpcount = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;//ゲームプレイ終了
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }


        if (player.Hp <= 0)
        {
            ChanegeScene();
        }
    }


    public Text textComponent;
    private int appleCount;

    public void AddAppleCount()
    {
        appleCount += 1;
        textComponent.text = "AppleCount : " + appleCount;
    }

    public Text Hptext;
    private int Hpcount;

    public void SubHp()
    {
        Hpcount -= 1;
        Hptext.text = "Hp" + Hpcount;
     }

    public void ChanegeScene()
    {
        SceneManager.LoadScene(GameOverScene);
    }
}

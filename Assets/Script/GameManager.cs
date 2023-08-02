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
        //Escが押された時ゲームプレイ終了
        if (Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
    Application.Quit();//ゲームプレイ終了
#endif
        }

        //プレイヤーが死んだときゲームオーバー画面に移動
        if (player.Hp <= 0)
        {
            Initiate.Fade(GameOverScene, Color.red, 1.0f);
            //ChanegeScene();
        }

        //リンゴが100個集まった時に残機を1増やす
        if (appleCount == 100)
        {
            appleCount = 0;
            player.AddRemainingLives();
        }
    }

    //壊せるブロックのカウント
    public Text textBrakeBlock;
    public int brakeCount;

    /// <summary>
    /// 壊せるブロックを増やす
    /// </summary>
    public void BrakeBlockCount()
    {
        brakeCount += 1;
        textBrakeBlock.text = "x" + brakeCount + MaxBrakeBlock;
    }

    //リンゴのカウント
    public Text textComponent;
    public int appleCount;

    /// <summary>
    /// リンゴを増やす
    /// </summary>
    public void AddAppleCount()
    {
        appleCount += 1;
        textComponent.text = "x" + appleCount;
    }

    //HPのカウント
    public Text Hptext;
    private int Hpcount;

    /// <summary>
    /// HPを減らす
    /// </summary>
    public void SubHpUI()
    {
        Hpcount -= 1;
        Hptext.text = "x" + Hpcount;
    }

    //シーン切り替え（ゲームオーバー）
    public void ChanegeScene()
    {
        SceneManager.LoadScene(GameOverScene);

    }
}

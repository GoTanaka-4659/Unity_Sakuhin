using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    public string nextScene;

    //プレイヤーがゴールと接触したとき
    private void OnTriggerEnter(Collider other)
    {
        //デバッグ用
        Debug.Log("ゴール");

        //スコア用の変数保存
        PlayerPrefs.SetInt("AppleCount", gameManager.appleCount);
        PlayerPrefs.SetInt("BrakeCount", gameManager.brakeCount);
        PlayerPrefs.Save();
        //シーン切り替え
        ChanegeScene();
    }

    //クリアシーンに切り替え
    void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

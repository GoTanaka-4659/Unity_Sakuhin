using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;

    //プレイヤーがゴールと接触したとき
    private void OnTriggerEnter(Collider other)
    {
        //デバッグ用
        Debug.Log("ゴール");
        //シーン切り替え
        ChanegeScene();
    }

    //クリアシーンに切り替え
    void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

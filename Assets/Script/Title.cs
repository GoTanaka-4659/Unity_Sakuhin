using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string nextScene;

    // Update is called once per frame
    void Update()
    {
        //スペースが押されたときシーンを切り替える
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChanegeScene();
        }
    }

    //シーン切り替え
    public void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

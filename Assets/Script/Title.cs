using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string nextScene;

    private void Start()
    {
        // フルスクリーンモードに切り替えます
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        //スペースが押されたときシーンを切り替える
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Initiate.Fade(nextScene, Color.black, 1.0f);
            //ChanegeScene();
        }
    }

    //シーン切り替え
    public void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string titleScene;

    // Update is called once per frame
    void Update()
    {
        //スペースが押されたときシーンを切り替える
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Initiate.Fade(titleScene, Color.black, 1.0f);
            //ChanegeScene();
        }
    }

    public void ChanegeScene()
    {
        SceneManager.LoadScene(titleScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("�S�[��");
        ChanegeScene();
    }

    void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

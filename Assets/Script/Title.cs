using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�������ꂽ�Ƃ��V�[����؂�ւ���
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ChanegeScene();
        }
    }

    //�V�[���؂�ւ�
    public void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

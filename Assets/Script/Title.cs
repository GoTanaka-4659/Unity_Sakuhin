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
        // �t���X�N���[�����[�h�ɐ؂�ւ��܂�
        Screen.fullScreen = true;
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�������ꂽ�Ƃ��V�[����؂�ւ���
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Initiate.Fade(nextScene, Color.black, 1.0f);
            //ChanegeScene();
        }
    }

    //�V�[���؂�ւ�
    public void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public string nextScene;

    //�v���C���[���S�[���ƐڐG�����Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        //�f�o�b�O�p
        Debug.Log("�S�[��");
        //�V�[���؂�ւ�
        ChanegeScene();
    }

    //�N���A�V�[���ɐ؂�ւ�
    void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameManager gameManager;
    public string nextScene;

    //�v���C���[���S�[���ƐڐG�����Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        //�f�o�b�O�p
        Debug.Log("�S�[��");

        //�X�R�A�p�̕ϐ��ۑ�
        PlayerPrefs.SetInt("AppleCount", gameManager.appleCount);
        PlayerPrefs.SetInt("BrakeCount", gameManager.brakeCount);
        PlayerPrefs.Save();
        //�V�[���؂�ւ�
        ChanegeScene();
    }

    //�N���A�V�[���ɐ؂�ւ�
    void ChanegeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

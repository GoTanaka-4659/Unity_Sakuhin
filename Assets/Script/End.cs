using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    public string titleScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�X�y�[�X�������ꂽ�Ƃ��V�[����؂�ւ���
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChanegeScene();
        }
    }

    public void ChanegeScene()
    {
        SceneManager.LoadScene(titleScene);
    }
}

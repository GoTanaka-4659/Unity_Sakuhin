using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    bool flyFlag = false;

    float moveX = 0f;
    float moveY = 0f;
    float moveZ = 0f;

    //�v���C���[�ƃ����S���ڐG�����Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerMove.nowRotate == false)
            {
                //�J�E���g����&�����S�I�u�W�F�N�g�̔j��
                gameManager.AddAppleCount();
                Destroy(gameObject);
            }
            else if(playerMove.nowRotate==true)
            {
                flyFlag = true;
            }
        }
    }

    private void Update()
    {
        if(flyFlag==false)
        {
            transform.Translate(new Vector3(0, 0, 10));
        }
        else if(flyFlag==true)
        {

        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

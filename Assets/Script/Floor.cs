using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public PlayerMove playerMove;

    private void OnTriggerStay(Collider other)
    {
        //���ƃv���C���[���ڐG���Ă���Ƃ�
        if (other.gameObject.tag == "Player")
        {
            //�W�����v�t���O��false�ɂ���
            playerMove.isJumpFlag = false;
            //�f�o�b�O�p
            Debug.Log("Jump=false");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[����O�ɗ������Ƃ��ɎE��
        if (other.gameObject.tag == "Player")
        {
            //�v���C���[��HP��0�ɂ���
            player.Hp -= player.Hp;

            //�f�o�b�O�p
            Debug.Log("OutStage");
        }
    }
}

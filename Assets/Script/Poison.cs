using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�Ɠŏ����ڐG������
        if (other.gameObject.tag == "Player")
        {
            //�v���C���[��HP�����炷
            player.Hp -= 1;
            gameManager.SubHp();
            //�f�o�b�O�p
            Debug.Log("PosionHit");
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

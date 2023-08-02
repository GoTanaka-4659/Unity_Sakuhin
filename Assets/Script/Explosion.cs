using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    public Player player;


    [SerializeField] GameObject explosion;


    void OnTriggerStay(Collider other)
    {

        if (playerMove.nowRotate == true)
        {
            //�v���C���[����]�U���i�\��j�𓖂Ă��Ƃ�
            if (other.gameObject.tag == "Player")
            {
                //�J�E���g����&�󂹂�u���b�N�I�u�W�F�N�g�̔j��
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                player.Hp = player.Hp - 1;
                gameManager.SubHpUI();
                player.damageFlag = true;
            }
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

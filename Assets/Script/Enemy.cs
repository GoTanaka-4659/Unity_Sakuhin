using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    public Player player;

    int counter = 0;
    float move = 0.01f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 0, move));
        counter++;
        if (counter == 750)
        {
            counter = 0;
            StartCoroutine("RightMove");
        }
    }

    //�E��]
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 180; turn++)
        {
            transform.Rotate(0, 1, 0);
            yield return new WaitForSeconds(0.001f);
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (playerMove.nowRotate == true)
        {
            //�v���C���[����]�U���i�\��j�𓖂Ă��Ƃ�
            if (other.gameObject.tag == "Player")
            {
                //�G�I�u�W�F�N�g�̔j��
                Destroy(gameObject);
            }
        }

        if(playerMove.nowRotate==false)
        {
            //�v���C���[����]�U�����Ă��Ȃ��Ƃ�
            if (other.gameObject.tag == "Player")
            {
                //�v���C���[��HP�����炷
                player.Hp -= 1;
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

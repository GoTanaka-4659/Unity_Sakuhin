using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    public Player player;

    private int counter = 0;
    public int Maxcounter = 700;
    public float moveSample = 0.01f;
    public float moveX = 0.0f;
    public float moveY = 0.0f;
    public float moveZ = 0.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(moveX, moveY, moveZ));
        counter++;

        ////X�ɒl�������Ă��鎞
        //if (moveX != 0)
        //{
        //    if (counter == Maxcounter)
        //    {
        //        counter = 0;
        //        moveX *= -1;
        //    }
        //}
        ////Y�ɒl�������Ă��鎞
        //if (moveY != 0)
        //{
        //    if (counter == Maxcounter)
        //    {
        //        counter = 0;
        //        moveY *= -1;
        //    }
        //}
        ////Y�ɒl�������Ă��鎞
        //if (moveZ != 0)
        //{
        //    if (counter == Maxcounter)
        //    {
        //        counter = 0;
        //        moveZ *= -1;
        //    }
        //}
   
    }

    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�Ɠŏ����ڐG������
        if (other.gameObject.tag == "Player")
        {
            //�v���C���[��HP�����炷
            player.Hp -= 1;
            gameManager.SubHpUI();
            player.damageFlag = true;
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

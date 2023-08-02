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

        ////Xに値が入っている時
        //if (moveX != 0)
        //{
        //    if (counter == Maxcounter)
        //    {
        //        counter = 0;
        //        moveX *= -1;
        //    }
        //}
        ////Yに値が入っている時
        //if (moveY != 0)
        //{
        //    if (counter == Maxcounter)
        //    {
        //        counter = 0;
        //        moveY *= -1;
        //    }
        //}
        ////Yに値が入っている時
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
        //プレイヤーと毒床が接触した時
        if (other.gameObject.tag == "Player")
        {
            //プレイヤーのHPを減らす
            player.Hp -= 1;
            gameManager.SubHpUI();
            player.damageFlag = true;
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

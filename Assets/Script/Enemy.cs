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

    //右回転
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
            //プレイヤーが回転攻撃（予定）を当てたとき
            if (other.gameObject.tag == "Player")
            {
                //敵オブジェクトの破壊
                Destroy(gameObject);
            }
        }

        if(playerMove.nowRotate==false)
        {
            //プレイヤーが回転攻撃していないとき
            if (other.gameObject.tag == "Player")
            {
                //プレイヤーのHPを減らす
                player.Hp -= 1;
                gameManager.SubHpUI();
                player.damageFlag = true;
            }
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

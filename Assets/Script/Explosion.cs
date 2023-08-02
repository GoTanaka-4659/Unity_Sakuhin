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
            //プレイヤーが回転攻撃（予定）を当てたとき
            if (other.gameObject.tag == "Player")
            {
                //カウント増加&壊せるブロックオブジェクトの破壊
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
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

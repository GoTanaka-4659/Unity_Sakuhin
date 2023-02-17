using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと毒床が接触した時
        if (other.gameObject.tag == "Player")
        {
            //プレイヤーのHPを減らす
            player.Hp -= 1;
            gameManager.SubHp();
            //デバッグ用
            Debug.Log("PosionHit");
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

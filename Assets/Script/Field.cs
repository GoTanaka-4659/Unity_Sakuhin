using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーが場外に落ちたときに殺す
        if (other.gameObject.tag == "Player")
        {
            //プレイヤーのHPを0にする
            player.Hp -= player.Hp;

            //デバッグ用
            Debug.Log("OutStage");
        }
    }
}

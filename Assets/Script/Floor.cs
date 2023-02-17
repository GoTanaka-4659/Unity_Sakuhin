using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public PlayerMove playerMove;

    private void OnTriggerStay(Collider other)
    {
        //床とプレイヤーが接触しているとき
        if (other.gameObject.tag == "Player")
        {
            //ジャンプフラグをfalseにする
            playerMove.isJumpFlag = false;
            //デバッグ用
            Debug.Log("Jump=false");
        }
    }
}

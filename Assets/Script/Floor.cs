using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public PlayerMove playerMove;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerMove.isJumpFlag = false;

            Debug.Log("Jump=false");
        }
    }
}

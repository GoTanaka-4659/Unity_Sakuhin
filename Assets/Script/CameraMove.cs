using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 0.05f;
    public PlayerMove player;

    // Update is called once per frame
    void Update()
    {

        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;
        pos.x = player.cameraPos.x;
        pos.z = player.cameraPos.z + 35;

        //if (player.cameraPos.z >= 0)
        //{
        //    pos.z = 35;
        //}
        //if (player.cameraPos.x > -1100)
        //{
        //    pos.z = 35;
        //}

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }
}

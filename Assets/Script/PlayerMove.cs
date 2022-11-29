using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 0.05f;

    void Start()
    {

    }

    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //右方向に+0.1動く
            pos.x -= speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //左方向に+0.1動く
            pos.x += speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //上方向に+0.1動く
            pos.z -= speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //下方向に+0.1動く
            pos.z += speed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 5; i++)
            {
                pos.y += 1.0f;
            }
        }

        transform.position = new Vector3(pos.x,pos.y,pos.z);
    }
}



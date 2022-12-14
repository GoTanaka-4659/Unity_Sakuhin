using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 0.05f;
    public float jumpPower;
    public float garavity;
    private Rigidbody rb;
    public bool isJumpFlag = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //プレイヤーのワールド座標を取得
        Vector3 pos = transform.position;

        //プレイヤー画面
        //矢印キーが入力されたとき
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    右方向に+0.1動く
        //    pos.z += speed;
        //}
        //矢印キーが入力されたとき
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    左方向に+0.1動く
        //    pos.z -= speed;
        //}
        //矢印キーが入力されたとき
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    上方向に+0.1動く
        //    pos.x -= speed;
        //}
        //矢印キーが入力されたとき
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    下方向に+0.1動く
        //    pos.x += speed;
        //}

        //横画面
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //右方向に+0.1動く
            pos.z += speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //左方向に+0.1動く
            pos.z -= speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //上方向に+0.1動く
            pos.x -= speed;
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //下方向に+0.1動く
            pos.x += speed;
        }


        //if (Input.GetKeyDown(KeyCode.Space)&&isJumpFlag==false)
        //{
        //    for (int i = 0; i < 5; i++)
        //    {
        //        pos.y += 1.0f;
        // isJumpFlag = true;
        //    }
        //}

        //スペースを押した時ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumpFlag = true;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    //床と接しているときジャンプフラグfalse
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Floor"|| other.gameObject.tag == "Block" || other.gameObject.tag == "BrakeBlock")
        {
            isJumpFlag = false;
            Debug.Log("aaaa");
        }
        Debug.Log(other.gameObject.tag);
    }
}



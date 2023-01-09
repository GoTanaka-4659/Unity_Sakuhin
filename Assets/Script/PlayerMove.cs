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

    public float Mx = 0f;
    public float My = 0f;
    public float Mz = 0f;

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

        //スペースを押した時ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumpFlag = true;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        //床と接しているときジャンプフラグfalse
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block" || other.gameObject.tag == "BrakeBlock")
        {
            isJumpFlag = false;
            Debug.Log("aaaa");
        }
        Debug.Log(other.gameObject.tag);

        Vector3 pos = transform.position;

        if (other.gameObject.tag == "Block"||other.gameObject.tag=="BrakeBlock")
        {
            pos.x -= Mx;
        }
        if(other.gameObject.tag == "Wall")
        {

            pos.x -= 0.5f;
            pos.z -= Mz;
        }
        
        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

}



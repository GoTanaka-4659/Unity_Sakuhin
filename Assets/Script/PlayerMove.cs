using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    //パラメータ
    public float speed = 0.05f;
    public float jumpPower;
    public float garavity;

    //ジャンプをしているか/二回目のジャンプをしたか
    public bool isJumpFlag = false;
    public bool isJumpFlagTwice = false;

    //回転しているか
    public bool nowRotate = false;

    //カメラのワールド座標
    public Vector3 cameraPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        //プレイヤーのワールド座標を取得
        cameraPos = transform.position;

        //回転中ではない場合は実行 
        if (Input.GetKey(KeyCode.LeftShift) && !nowRotate)
        {
            nowRotate = true;
            //回転攻撃
            StartCoroutine("RightMove");
        }

        //横画面からの俯瞰
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //下方向動く
            rb.AddForce(0f, 0f, speed, ForceMode.Force);
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //上方向動く
            rb.AddForce(0f, 0f, -speed, ForceMode.Force);
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //右方向動く
            rb.AddForce(-speed, 0f, 0f, ForceMode.Force);
        }
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //左方向動く
            rb.AddForce(speed, 0f, 0f, ForceMode.Force);
        }

        //スペースを押した時ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            //rb.AddForce(0f, 28.0f, 0f, ForceMode.Impulse);
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isJumpFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == true && isJumpFlagTwice == false)
        {
            //rb.AddForce(0f, 28.0f, 0f, ForceMode.Impulse);
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isJumpFlagTwice = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //床と接しているときジャンプフラグfalse
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block" || other.gameObject.tag == "BrakeBlock")
        {
            isJumpFlag = false;
            isJumpFlagTwice = false;
            Debug.Log("jumpFlagOff");
        }
        Debug.Log(other.gameObject.tag);
    }

    //右に回転して攻撃
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 360; turn++)
        {
            transform.Rotate(0, 5, 0);
            yield return new WaitForSeconds(0.001f);
        }
        nowRotate = false;
    }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public Player player;
    //パラメータ
    public float speed = 0.05f;
    public float jumpPower;
    float halfJumpPower;
    //public float garavity;

    //ジャンプをしているか/二回目のジャンプをしたか
    public bool isJumpFlag = false;
    public bool isJumpFlagTwice = false;

    //回転しているか
    public bool nowRotate = false;

    //カメラのワールド座標
    public Vector3 cameraPos;

    //プレイヤーの状態用列挙型（ノーマル、ダメージ、無敵の3種類）
    enum STATE
    {
        NOMAL,
        DAMAGED,
        INVINCIBLE
    }

    STATE state;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        animator = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {

    }

    void Update()
    {
        //プレイヤーのワールド座標を取得
        cameraPos = transform.position;
        halfJumpPower = jumpPower / 2;

        //回転中ではない場合は実行 
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Return) && !nowRotate)
        {
            //回転している
            nowRotate = true;
            //回転攻撃
            StartCoroutine("RightMove");
        }
        //回転中の間アニメーションを再生
        if (nowRotate == true)
        {
            //animator.SetTrigger("Tpose");
            animator.Play("Tpose");
        }
        //回転していないとき＆何も押されていないときにアイドル状態のアニメーションを再生
        if (nowRotate == false && !Input.anyKey)
        {
            animator.Play("idle");
        }


        //横画面からの俯瞰
        //矢印キーが入力されたとき
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //下方向動く
            rb.AddForce(0f, 0f, speed, ForceMode.Force);
            animator.SetTrigger("Walk");
            //transform.Rotate(0, -90, 0);

        }
        //矢印キーが入力されたとき
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //上方向動く
            rb.AddForce(0f, 0f, -speed, ForceMode.Force);
            //アニメーション
            animator.SetTrigger("Walk");
            //transform.Rotate(0, 180, 0);

        }
        //矢印キーが入力されたとき
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //右方向動く
            rb.AddForce(-speed, 0f, 0f, ForceMode.Force);
            //アニメーション
            animator.SetTrigger("Walk");

            //transform.Rotate(0, -90, 0);

        }
        //矢印キーが入力されたとき
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //左方向動く
            rb.AddForce(speed, 0f, 0f, ForceMode.Force);
            //アニメーション
            animator.SetTrigger("Walk");
            //transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //右に向く
            transform.Rotate(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //左に向く
            transform.Rotate(0, 180, 0);
        }

        //スペースを押した時ジャンプ
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            //rb.AddForce(0f, 28.0f, 0f, ForceMode.Impulse);
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isJumpFlag = true;

            animator.SetTrigger("Jump");
        }
        //二段ジャンプ
        else if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == true && isJumpFlagTwice == false)
        {
            //rb.AddForce(0f, 28.0f, 0f, ForceMode.Impulse);
            rb.AddForce(0f, halfJumpPower, 0f, ForceMode.Impulse);
            isJumpFlagTwice = true;

            animator.SetTrigger("Jump");
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
        else if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Poison")
        {


        }
    }

    //右に回転して攻撃
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 180; turn++)
        {
            transform.Rotate(0, 10, 0);
            yield return new WaitForSeconds(0.003f);
        }
        //回転しているフラグをおろす
        nowRotate = false;
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    //�p�����[�^
    public float speed = 0.05f;
    public float jumpPower;
    public float garavity;

    //�W�����v�����Ă��邩/���ڂ̃W�����v��������
    public bool isJumpFlag = false;
    public bool isJumpFlagTwice = false;

    //��]���Ă��邩
    public bool nowRotate = false;

    //�J�����̃��[���h���W
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
        //�v���C���[�̃��[���h���W���擾
        cameraPos = transform.position;

        //��]���ł͂Ȃ��ꍇ�͎��s 
        if (Input.GetKey(KeyCode.LeftShift) && !nowRotate)
        {
            nowRotate = true;
            //��]�U��
            StartCoroutine("RightMove");
        }

        //����ʂ���̘���
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //����������
            rb.AddForce(0f, 0f, speed, ForceMode.Force);
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //���������
            rb.AddForce(0f, 0f, -speed, ForceMode.Force);
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //�E��������
            rb.AddForce(-speed, 0f, 0f, ForceMode.Force);
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //����������
            rb.AddForce(speed, 0f, 0f, ForceMode.Force);
        }

        //�X�y�[�X�����������W�����v
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
        //���Ɛڂ��Ă���Ƃ��W�����v�t���Ofalse
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block" || other.gameObject.tag == "BrakeBlock")
        {
            isJumpFlag = false;
            isJumpFlagTwice = false;
            Debug.Log("jumpFlagOff");
        }
        Debug.Log(other.gameObject.tag);
    }

    //�E�ɉ�]���čU��
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



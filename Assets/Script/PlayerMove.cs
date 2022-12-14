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
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //�v���C���[���
        //���L�[�����͂��ꂽ�Ƃ�
        //if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        //{
        //    �E������+0.1����
        //    pos.z += speed;
        //}
        //���L�[�����͂��ꂽ�Ƃ�
        //if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        //{
        //    ��������+0.1����
        //    pos.z -= speed;
        //}
        //���L�[�����͂��ꂽ�Ƃ�
        //if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        //{
        //    �������+0.1����
        //    pos.x -= speed;
        //}
        //���L�[�����͂��ꂽ�Ƃ�
        //if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        //{
        //    ��������+0.1����
        //    pos.x += speed;
        //}

        //�����
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //�E������+0.1����
            pos.z += speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //��������+0.1����
            pos.z -= speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //�������+0.1����
            pos.x -= speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //��������+0.1����
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

        //�X�y�[�X�����������W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumpFlag = true;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    //���Ɛڂ��Ă���Ƃ��W�����v�t���Ofalse
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



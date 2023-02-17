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
    public bool isJumpFlagTwice = false;


    public float Mx = 0f;
    public float My = 0f;
    public float Mz = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;

        //�v���C���[3�l�̎��_
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

        //����ʂ���̘���
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

        //�X�y�[�X�����������W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            rb.velocity = Vector3.up * jumpPower;
            isJumpFlag = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == true && isJumpFlagTwice == false)
        {
            rb.velocity = Vector3.up * jumpPower ;
            isJumpFlagTwice = true;
        }

        transform.position = new Vector3(pos.x, pos.y, pos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        //���Ɛڂ��Ă���Ƃ��W�����v�t���Ofalse
        if (other.gameObject.tag == "Floor" || other.gameObject.tag == "Block" || other.gameObject.tag == "BrakeBlock")
        {
            isJumpFlag = false;
            isJumpFlagTwice = false;
            Debug.Log("aaaa");
        }
        Debug.Log(other.gameObject.tag);


        //�v���C���[�����܂�Ȃ��悤�ɒ��˕Ԃ�
        Vector3 pos = transform.position;

        if (other.gameObject.tag == "Block"||other.gameObject.tag=="BrakeBlock")
        {
            pos.x -= Mx;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }

        if(other.gameObject.tag == "InteriorWall")
        {
            pos.z -= Mz;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        
        if(other.gameObject.tag == "ThisSideWall")
        {
            pos.z += Mz;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }

        if(other.gameObject.tag == "LeftWall")
        {
            pos.x -= 1.0f;
            transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
    }

}



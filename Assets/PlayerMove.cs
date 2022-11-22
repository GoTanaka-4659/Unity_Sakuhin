using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    float speed = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        //�v���C���[�̃��[���h���W���擾
        Vector3 pos = transform.position;
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //�E������+0.1����
            pos.x -= speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //��������+0.1����
            pos.x += speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //�������+0.1����
            pos.z -= speed;
        }
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow))
        {
            //��������+0.1����
            pos.z += speed;
        }

        transform.position = new Vector3(pos.x,pos.y,pos.z);
    }
}



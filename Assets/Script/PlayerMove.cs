using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public Animator animator;
    public Player player;
    //�p�����[�^
    public float speed = 0.05f;
    public float jumpPower;
    float halfJumpPower;
    //public float garavity;

    //�W�����v�����Ă��邩/���ڂ̃W�����v��������
    public bool isJumpFlag = false;
    public bool isJumpFlagTwice = false;

    //��]���Ă��邩
    public bool nowRotate = false;

    //�J�����̃��[���h���W
    public Vector3 cameraPos;

    //�v���C���[�̏�ԗp�񋓌^�i�m�[�}���A�_���[�W�A���G��3��ށj
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
        //�v���C���[�̃��[���h���W���擾
        cameraPos = transform.position;
        halfJumpPower = jumpPower / 2;

        //��]���ł͂Ȃ��ꍇ�͎��s 
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Return) && !nowRotate)
        {
            //��]���Ă���
            nowRotate = true;
            //��]�U��
            StartCoroutine("RightMove");
        }
        //��]���̊ԃA�j���[�V�������Đ�
        if (nowRotate == true)
        {
            //animator.SetTrigger("Tpose");
            animator.Play("Tpose");
        }
        //��]���Ă��Ȃ��Ƃ�������������Ă��Ȃ��Ƃ��ɃA�C�h����Ԃ̃A�j���[�V�������Đ�
        if (nowRotate == false && !Input.anyKey)
        {
            animator.Play("idle");
        }


        //����ʂ���̘���
        //���L�[�����͂��ꂽ�Ƃ�
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            //����������
            rb.AddForce(0f, 0f, speed, ForceMode.Force);
            animator.SetTrigger("Walk");
            //transform.Rotate(0, -90, 0);

        }
        //���L�[�����͂��ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            //���������
            rb.AddForce(0f, 0f, -speed, ForceMode.Force);
            //�A�j���[�V����
            animator.SetTrigger("Walk");
            //transform.Rotate(0, 180, 0);

        }
        //���L�[�����͂��ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //�E��������
            rb.AddForce(-speed, 0f, 0f, ForceMode.Force);
            //�A�j���[�V����
            animator.SetTrigger("Walk");

            //transform.Rotate(0, -90, 0);

        }
        //���L�[�����͂��ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //����������
            rb.AddForce(speed, 0f, 0f, ForceMode.Force);
            //�A�j���[�V����
            animator.SetTrigger("Walk");
            //transform.Rotate(0, 90, 0);

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            //�E�Ɍ���
            transform.Rotate(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            //���Ɍ���
            transform.Rotate(0, 180, 0);
        }

        //�X�y�[�X�����������W�����v
        if (Input.GetKeyDown(KeyCode.Space) && isJumpFlag == false)
        {
            //rb.AddForce(0f, 28.0f, 0f, ForceMode.Impulse);
            rb.AddForce(0f, jumpPower, 0f, ForceMode.Impulse);
            isJumpFlag = true;

            animator.SetTrigger("Jump");
        }
        //��i�W�����v
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
        //���Ɛڂ��Ă���Ƃ��W�����v�t���Ofalse
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

    //�E�ɉ�]���čU��
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 180; turn++)
        {
            transform.Rotate(0, 10, 0);
            yield return new WaitForSeconds(0.003f);
        }
        //��]���Ă���t���O�����낷
        nowRotate = false;
    }


}



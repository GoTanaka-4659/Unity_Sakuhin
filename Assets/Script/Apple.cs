using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    bool flyFlag = false;

    float moveX = 0f;
    float moveY = 0f;
    float moveZ = 0f;

    private int counter = 0;

    [SerializeField]
    [Tooltip("����������G�t�F�N�g�i�p�[�e�B�N���j")]
    private ParticleSystem particle;

    int interPaeticle = 0;

    //�v���C���[�ƃ����S���ڐG�����Ƃ�
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerMove.nowRotate == true)
            {
                flyFlag = true;
            }
            else if (playerMove.nowRotate == false && flyFlag != true)
            {
                ////�J�E���g����&�����S�I�u�W�F�N�g�̔j��
                gameManager.AddAppleCount();
                CreateParticle(other);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(moveX, moveY, moveZ));

        if (flyFlag == false)
        {

        }
        else if (flyFlag == true)
        {
            //�����_���ȕ����ɔ�΂�
            moveX = 100;
            //moveY=
            //moveZ=

            if (moveX > 200 || moveY > 200 || moveZ > 200 || moveX < -200 || moveY < -200 || moveZ < -200)
            {
                //  Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();

        flyFlag = false;
    }

    void CreateParticle(Collider collider)
    {
        //�����������肪Plaer�^�O�������Ă�����
        if (collider.gameObject.tag == "Player")
        {
            //�p�[�e�B�N���V�X�e���̃C���X�^���X�𐶐�����
            ParticleSystem newParticle = Instantiate(particle);
            //�p�[�e�B�N���̔����ꏊ�����̃X�N���v�g���A�^�b�`���Ă���GameObject�̏ꏊ�ɂ���
            newParticle.transform.position = this.transform.position;
            //�p�[�e�B�N���𔭐�������
            newParticle.Play();

            Destroy(newParticle.gameObject, 5.0f);
        }
    }
}

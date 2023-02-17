using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBlock : MonoBehaviour
{
    public GameManager gameManager;
    [SerializeField]
    [Tooltip("����������G�t�F�N�g�i�p�[�e�B�N���j")]
    private ParticleSystem particle;

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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //�v���C���[����]�U���i�\��j�𓖂Ă��Ƃ�
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //�J�E���g����&�󂹂�u���b�N�I�u�W�F�N�g�̔j��
                gameManager.BrakeBlockCount();
                Destroy(gameObject);
                CreateParticle(other);

                //�f�o�b�O�p
                Debug.Log("LHit");
            }
            //�f�o�b�O�p
            Debug.Log("Hit");
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

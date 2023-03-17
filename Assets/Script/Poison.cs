using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    [SerializeField]
    [Tooltip("����������G�t�F�N�g�i�p�[�e�B�N���j")]
    private ParticleSystem particle;

    int interPaeticle = 0;

    private void Update()
    {
        interPaeticle++;

        if (interPaeticle % 10 == 3)
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


    private void OnTriggerEnter(Collider other)
    {
        //�v���C���[�Ɠŏ����ڐG������
        if (other.gameObject.tag == "Player")
        {
            //�v���C���[��HP�����炷
            player.Hp -= 1;
            gameManager.SubHpUI();
            player.damageFlag = true;
        }
    }

    private void Start()
    {
        //�Q�[���}�l�[�W���[�̎擾
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

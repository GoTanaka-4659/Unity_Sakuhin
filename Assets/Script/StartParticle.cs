using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartParticle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("����������G�t�F�N�g�i�p�[�e�B�N���j")]
    private ParticleSystem particle;

    private void OnCollisionEnter(Collision collision)
    {
        //�����������肪Plaer�^�O�������Ă�����
        if (collision.gameObject.tag == "Player")
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

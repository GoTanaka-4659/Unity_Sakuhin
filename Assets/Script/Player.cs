using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�łȂǂɓ������Č���q�b�g�|�C���g
    public int Hp = 3;
    //�c�@
    public int remainingLives = 1;
    //�_���[�W���󂯂��Ƃ�
    public bool damageFlag = false;
    //���G����
    public int invincibleTime = 0;

    void Update()
    {
        if (Hp == 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(this.Hp);

        if (damageFlag == true)
        {
            this.Hp = this.Hp;

            invincibleTime++;
        }

        if(invincibleTime==1000)
        {
            damageFlag = false;
            invincibleTime = 0;
        }
    }

    /// <summary>
    /// �c�@�ǉ�
    /// </summary>
    public void AddRemainingLives()
    {
        remainingLives += 1;
    }
}

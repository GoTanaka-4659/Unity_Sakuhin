using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //�łȂǂɓ������Č���q�b�g�|�C���g
    public int Hp = 3;
    //�c�@
    public int remainingLives = 1;

    void Update()
    {
        if (Hp == 0)
        {
            Destroy(this.gameObject);
        }
            Debug.Log(this.Hp);
    }

    /// <summary>
    /// �c�@�ǉ�
    /// </summary>
    public void AddRemainingLives()
    {
        remainingLives += 1;
    }

  
}

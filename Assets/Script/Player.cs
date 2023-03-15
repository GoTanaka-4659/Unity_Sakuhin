using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //毒などに当たって減るヒットポイント
    public int Hp = 3;
    //残機
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
    /// 残機追加
    /// </summary>
    public void AddRemainingLives()
    {
        remainingLives += 1;
    }

  
}

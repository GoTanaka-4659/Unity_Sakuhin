using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //毒などに当たって減るヒットポイント
    public int Hp = 3;
    //残機
    public int remainingLives = 1;
    //ダメージを受けたとき
    public bool damageFlag = false;
    //無敵時間
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
    /// 残機追加
    /// </summary>
    public void AddRemainingLives()
    {
        remainingLives += 1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBlock : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    [SerializeField]
    [Tooltip("発生させるエフェクト（パーティクル）")]
    private ParticleSystem particle;

    void CreateParticle(Collider collider)
    {
        //当たった相手がPlaerタグを持っていたら
        if (collider.gameObject.tag == "Player")
        {
            //パーティクルシステムのインスタンスを生成する
            ParticleSystem newParticle = Instantiate(particle);
            //パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする
            newParticle.transform.position = this.transform.position;
            //パーティクルを発生させる
            newParticle.Play();

            Destroy(newParticle.gameObject, 5.0f);
        }
    }

    void OnTriggerStay(Collider other)
    {
        
        if (playerMove.nowRotate == true)
        {
            //プレイヤーが回転攻撃（予定）を当てたとき
            if (other.gameObject.tag == "Player")
            {
                //カウント増加&壊せるブロックオブジェクトの破壊
                gameManager.BrakeBlockCount();
                Destroy(gameObject);
                CreateParticle(other);
            }
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

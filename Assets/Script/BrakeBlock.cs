using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrakeBlock : MonoBehaviour
{
    public GameManager gameManager;
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
        if (other.gameObject.tag == "Player")
        {
            //プレイヤーが回転攻撃（予定）を当てたとき
            if (Input.GetKey(KeyCode.LeftShift))
            {
                //カウント増加&壊せるブロックオブジェクトの破壊
                gameManager.BrakeBlockCount();
                Destroy(gameObject);
                CreateParticle(other);

                //デバッグ用
                Debug.Log("LHit");
            }
            //デバッグ用
            Debug.Log("Hit");
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

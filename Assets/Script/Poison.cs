using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public Player player;
    public GameManager gameManager;

    [SerializeField]
    [Tooltip("発生させるエフェクト（パーティクル）")]
    private ParticleSystem particle;

    int interPaeticle = 0;

    private void Update()
    {
        interPaeticle++;

        if (interPaeticle % 10 == 3)
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


    private void OnTriggerEnter(Collider other)
    {
        //プレイヤーと毒床が接触した時
        if (other.gameObject.tag == "Player")
        {
            //プレイヤーのHPを減らす
            player.Hp -= 1;
            gameManager.SubHpUI();
            player.damageFlag = true;
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();
    }
}

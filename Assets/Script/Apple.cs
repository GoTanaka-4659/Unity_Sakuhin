using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerMove playerMove;
    bool flyFlag = false;

    float moveX = 0f;
    float moveY = 0f;
    float moveZ = 0f;

    private int counter = 0;

    [SerializeField]
    [Tooltip("発生させるエフェクト（パーティクル）")]
    private ParticleSystem particle;

    int interPaeticle = 0;

    //プレイヤーとリンゴが接触したとき
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (playerMove.nowRotate == true)
            {
                flyFlag = true;
            }
            else if (playerMove.nowRotate == false && flyFlag != true)
            {
                ////カウント増加&リンゴオブジェクトの破壊
                gameManager.AddAppleCount();
                CreateParticle(other);
                Destroy(gameObject);
            }
        }
    }

    private void Update()
    {
        transform.Translate(new Vector3(moveX, moveY, moveZ));

        if (flyFlag == false)
        {

        }
        else if (flyFlag == true)
        {
            //ランダムな方向に飛ばす
            moveX = 100;
            //moveY=
            //moveZ=

            if (moveX > 200 || moveY > 200 || moveZ > 200 || moveX < -200 || moveY < -200 || moveZ < -200)
            {
                //  Destroy(gameObject);
            }
        }
    }

    private void Start()
    {
        //ゲームマネージャーの取得
        GameObject managerObject = GameObject.Find("GameManager");
        gameManager = managerObject.GetComponent<GameManager>();

        flyFlag = false;
    }

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
}

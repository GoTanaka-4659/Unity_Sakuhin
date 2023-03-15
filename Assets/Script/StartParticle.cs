using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartParticle : MonoBehaviour
{
    [SerializeField]
    [Tooltip("発生させるエフェクト（パーティクル）")]
    private ParticleSystem particle;

    private void OnCollisionEnter(Collision collision)
    {
        //当たった相手がPlaerタグを持っていたら
        if (collision.gameObject.tag == "Player")
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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

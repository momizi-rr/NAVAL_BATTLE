using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CannonballExplosion : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticles = default;    //爆発パーティクルの参照
    public LayerMask targetMask;                            //レイヤーの参照
    private const float maxLifeTime = 5.0f;                 //弾が何も触れなかった時の生存時間

    private void Start()
    {
        //弾発射時、指定秒後にDestroy
        Destroy(gameObject, maxLifeTime);

        //エラーが出るので
        DontDestroyOnLoad(gameObject);
    }

    //何かに触れた時
    //private void OnTriggerEnter(Collider other)
    public void OnCollisionEnter(Collision other)
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false; 

        //接触したオブジェクトのTargetDestroyを参照　
        TargetDestroy target = other.gameObject.GetComponent<TargetDestroy>();

        //TargetDestroyがあった場合、ターゲットを消去
        if (target)
            target.sendDestroy = true;

        //パーティクルを親オブジェクト(弾)から切り離し、弾が消えた後も爆発がされるようにする。
        explosionParticles.transform.parent = null;

        //爆発パーティクルを再生
        explosionParticles.Play();

        //パーティクルが１週がしたらDestory
        Destroy(explosionParticles.gameObject, explosionParticles.main.duration);

        ////オブジェクトをDestory
        //PhotonNetwork.Destroy(gameObject);
    }
}
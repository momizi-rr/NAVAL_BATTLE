using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//砲弾が触れた時に呼ばれる
public class TargetDestroy : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem explosionParticles = default;    //爆発パーティクルの参照
    public delegate void OnDelegate();                      //デリゲートを定義
    private OnDelegate destroyTaegetOne = null;             //デリゲートを受け取る変数を宣言
    private bool OnDestroy = false;                         //ターゲットが破壊された時の命令を１回に制限する

    public bool syncDestroy = false;                        //Destroy情報を同期する為の変数
    public bool sendDestroy = false;
    private const float lifeTime = 10.0f;

    private void Awake()
    {
        //エラーが出るので
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        syncDestroy = sendDestroy;

        //Destroyされた事が共有されたら、共有先もDestroy処理を行う
        if (syncDestroy && !OnDestroy)
            StartCoroutine(DestroyObject());
    }

    //呼ばれたらオブジェクトをDestroy
    //public void StartDestroy()
    public void OnCollisionEnter(Collision other)
    {
        StartCoroutine(DestroyObject());
    }

    private IEnumerator DestroyObject()
    { 
        if (!OnDestroy)
        {
            //ターゲットは破壊された
            OnDestroy = true;

            //ターゲットが消滅した事を伝える
            if(PhotonNetwork.isMasterClient)
                destroyTaegetOne();

            //船のモデルとコライダーの衝突判定を非アクティブにする
            transform.GetChild(0).gameObject.SetActive(false);
            GetComponent<BoxCollider>().isTrigger = true;

            //爆発パーティクルの処理
            explosionParticles.transform.parent = null;                                 //パーティクルを親オブジェクト(弾)から切り離し、弾が消えた後も爆発がされるようにする。
            explosionParticles.Play();                                                  //爆発パーティクルを再生
            Destroy(explosionParticles.gameObject, explosionParticles.main.duration);   //パーティクルが１週がしたらDestory

            //Destroyされた事を同期
            syncDestroy = true;

            //Destroyされるまでの時間(共有用)
            yield return new WaitForSeconds(lifeTime);

            //所有権の移譲
            //gameObject.GetComponent<PhotonView>().TransferOwnership(PhotonNetwork.player.ID);

            //Destroy
            if (PhotonNetwork.isMasterClient)
                PhotonNetwork.Destroy(gameObject);
        }
    }

    //LevelDesignerから、ターゲットが１つ減ったという処理をする「DestroyTaegetOne()」を受け取る
    public void SendDestroyDelegate(OnDelegate del)
    {
        destroyTaegetOne = del;
    }

    //パラメータの同期処理
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //送信処理
        if (stream.isWriting)
        {   //送信処理
            stream.SendNext(syncDestroy);
        }
        else
        {   //受信処理
            syncDestroy = (bool)stream.ReceiveNext();
        }
    }
}

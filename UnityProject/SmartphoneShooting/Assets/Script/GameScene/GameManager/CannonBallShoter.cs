using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallShoter : MonoBehaviour
{
    [SerializeField]
    private Transform mainCamera = default;        //カメラを参照
    [SerializeField]
    private GameObject cannonballPrefab = default;   //砲弾のPrefabを参照

    private const float cannonballForce = 60f;      //砲弾の発射力

    //砲弾を打つ関数
    public void OnclickShootCannonBall()
    {
        //Rigidbody型で、砲弾のインスタンスを生成
        GameObject cannonballInstance = PhotonNetwork.Instantiate(cannonballPrefab.name, mainCamera.position, mainCamera.rotation, 0);

        //砲弾に発射力分の速度を与える
        cannonballInstance.GetComponent<Rigidbody>().velocity = cannonballForce * mainCamera.forward;
    }
}

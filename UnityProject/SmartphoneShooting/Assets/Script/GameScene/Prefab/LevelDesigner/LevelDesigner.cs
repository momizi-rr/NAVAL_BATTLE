using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LevelDesigner : MonoBehaviour
{
    [SerializeField]                                        //生成するターゲットのPrefabを参照
    private GameObject targetPrefab = default;
    private List<LevelDesignData> levelDataList = default;  //レベルデザインの全データを収納するリスト

    private int level = 0;                                  //現在のレベルを確保する変数
    private int targetCount = 0;                            //現在のターゲット数を確保する変数z

    private void Awake()
    {
        //レベルデザインを取得
        levelDataList = SendLevelDesign.GetlevelDataList();

        //エラーが出るので
        DontDestroyOnLoad(gameObject);
    }

    //取得したレベルデザインのデータを元に、ターゲットを配置
    public void SetLevelDesign()
    {
        //レベルを進める
        level++;

        //ターゲットの個数をリセットする
        targetCount = 0;

        //インスタンスを生成
        foreach (LevelDesignData levelData in levelDataList)
        {
            //現在のレベルとは異なるデータは配置しない
            if (levelData.Level != level)
                continue;

            //テーブルデータの位置、回転、大きさをインスタンスに入れる変数を作る
            Vector3 insertPos = new Vector3(levelData.PosX, levelData.PosY, levelData.PosZ);                //位置を指定する変数をつくる
            Quaternion insertRate = Quaternion.Euler(levelData.RateX, levelData.RateY, levelData.RateZ);    //回転を指定
            Vector3 insertScale = new Vector3(levelData.ScaleX, levelData.ScaleY, levelData.ScaleZ);        //大きさを指定

            //Rigidbody型で、敵船のインスタンスを生成
            GameObject targetInstance = PhotonNetwork.Instantiate(targetPrefab.name, insertPos, insertRate, 0);
            targetInstance.transform.localScale = insertScale; //大きさを指定

            //パターン２の場合、反復処理を持った敵船を出す
            if(levelData.Pattern == 2)
                targetInstance.GetComponent<IterateMoveTarget>().enabled = true;

            //インスタンスがDestroyされた時に呼ばれるデリゲートを渡す
            TargetDestroy targetDestroy = targetInstance.GetComponent<TargetDestroy>();
            targetDestroy.SendDestroyDelegate(DestroyTargetOne);

            //ターゲットの個数を数える
            targetCount++;
        }
    }

    //ターゲットがDestroyされた時に呼ばれる「ターゲットが１つ減った」という処理のデリゲート関数
    public void DestroyTargetOne()
    {
        targetCount--;
    }

    //ターゲットの個数を返す関数
    public int RetrunTargetCount()
    {
        return targetCount;
    }

    //現在のレベルを返す関数
    public int ReturnCurrentLevel()
    {
        return level;
    }

    //パラメータの同期処理
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //送信処理
        if (stream.isWriting)
        {   //送信処理
            stream.SendNext(level);
            stream.SendNext(targetCount);
        }
        else
        {   //受信処理
            level = (int)stream.ReceiveNext();
            targetCount = (int)stream.ReceiveNext();
        }
    }
}

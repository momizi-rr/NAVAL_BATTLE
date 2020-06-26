using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class StartController : MonoBehaviour
{
    //Prefabにスクリプトを張り付けている場合そのスクリプト名でシリアライズしたほうがいい
    //-----------------------------------------------------------
    [SerializeField]                                        //レベルデザインをメインゲームに渡すオブジェクトのPrefab
    private GameObject sendLevelDesignPrefab = default;
    //-----------------------------------------------------------
    
    private List<LevelDesignData> levelDataList = default;  //レベルデザインの全データを収納するリスト
    private string ipAddress;                               //入力されたIPアドレスを収納する変数
    private const float setLevelSendDelay = 2.0f;           //レベルデザインを取得した後のゲームシーンに移動するまでの余韻
    private bool EndGetLeveldesign = false;                 //レベルデザインの取得を１回に制限する

    [SerializeField]                                        //ダイアログのオブジェクトを参照
    private GameObject ipAddressDialog = default;
    private Text dialogMessageText = default;               //ダイアログのメッセージテキストを参照
    private Text inputIpAddress = default;                  //ダイアログの入力テキストの内容を参照

    [SerializeField]                                        //人数確認のダイアログを参照
    private GameObject photonDialog = default;

    private void Awake()
    {
        //ダイアログを非アクティブに
        ipAddressDialog.SetActive(false);
        photonDialog.SetActive(false);

        //ダイアログのメッセージテキストを参照
        dialogMessageText = ipAddressDialog.transform.GetChild(0).GetComponent<Text>();

        //ダイアログのテキスト入力内容を参照
        inputIpAddress = ipAddressDialog.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
    }

    //タイトルで画面のどこかに触れたら
    public void OnClickGameStart()
    {
        //IPアドレスを問うダイアログをアクティブに
        ipAddressDialog.SetActive(true);
    }

    //ダイアログのボタンが押された時、入力されたIPを参照してレベルデザイン取得する命令を出す関数
    public void OnClickIPAddressInsert()
    {
        if (!EndGetLeveldesign)
        {
            //入力されたIPアドレスを参照
            ipAddress = inputIpAddress.text;

            // APIが設置してあるURLパス
            string url = "http://" + ipAddress + "/shootinglevelset/Shootingleveldesign/getMessages";

            // Wwwを利用して json データ取得をリクエストする
            StartCoroutine(GetLevelDesign(url));
        }
    }

    //レベルデザインをデータベースから取得し、リスト型に変換するコールチン
    private IEnumerator GetLevelDesign(string url)
    {
        // WWWを利用してリクエストを送る
        UnityWebRequest webRequest = UnityWebRequest.Get(url);

        //タイムアウトの指定
        webRequest.timeout = 5;

        // WWWレスポンス待ち
        yield return webRequest.SendWebRequest();

        //リクエストが成功したか失敗したかを確認
        if(webRequest.error != null)    //失敗の場合
        {
            GetFailureLevelData();
        }
        else if (webRequest.isDone)     // リクエスト成功の場合
        {
            StartCoroutine(GetSuccessLevelData(webRequest));
        }
    }

    //Webリクエストが失敗した場合の処理をする関数
    private void GetFailureLevelData()
    {
        //テキストに失敗を表示
        dialogMessageText.text = "レベルデザイン取得失敗…\nもう一度IPアドレスを入力してください";
    }

    //Webリクエストが成功した場合の処理をする関数
    private IEnumerator GetSuccessLevelData(UnityWebRequest webRequest)
    {
        //テキストに成功を表示
        dialogMessageText.text = "レベルデザイン取得完了!!";
        Debug.Log($"Success:{webRequest.downloadHandler.text}"); //中身を確認(テスト用)

        //jsonデータをデコード
        yield return levelDataList = LevelDesignDataModel.DeserializeFromJson(webRequest.downloadHandler.text);

        //レベルデザインのデータを持ったインスタンスの生成を命令
        MoveMAinGame();

        //余韻
        yield return new WaitForSeconds(setLevelSendDelay);

        //IPアドレスを問うダイアログをアクティブに
        photonDialog.SetActive(true);
    }

    //レベルデザインのデータを持ったインスタンスを生成する関数
    private void MoveMAinGame()
    {
        //レベルデザインのデータを持ったインスタンスを生成
        GameObject levelDesignInstance = Instantiate(sendLevelDesignPrefab);
        levelDesignInstance.GetComponent<SendLevelDesign>().SetLevelData(levelDataList);

        //レベルデザインの取得１回に制限
        EndGetLeveldesign = true;
    }
}

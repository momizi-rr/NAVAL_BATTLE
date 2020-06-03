using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleManager : MonoBehaviour
{
    [SerializeField]                                        //タイトル画面からIPアドレス確認ダイアログへ移るボタンを参照
    private GameObject gameStartButton = default;

    [SerializeField]                                        //IPアドレス確認のダイアログを参照
    private GameObject ipAddressDialog = default;
    private Text dialogMessageText = default;               //IPアドレス確認のメッセージテキストを参照
    private Text inputIpAddress = default;                  //IPアドレス確認の入力テキストの内容を参照
    private Button insertIpAddressButton = default;         //IPアドレス確認の確認ボタンを参照

    [SerializeField]                                        //人数確認のダイアログを参照
    private GameObject photonDialog = default;
    private Text photonMessageText = default;               //人数選択ダイアログのテキストを参照
    private Button onePlayerButton = default;               //人数選択ダイアログの１人プレイボタンを参照
    private Button twoPayersCreateButton = default;         //人数選択ダイアログの２人プレイ(ルーム作成)ボタンを参照
    private Button twoPlayersJoinButton = default;          //人数選択ダイアログの２人プレイ(ルーム入室)ボタンを参照

    private void Start()
    {
        //ダイアログを非アクティブに
        ipAddressDialog.SetActive(false);
        photonDialog.SetActive(false);

        //ダイアログからUIを取得
        GetDialogChild();
    }

    private void GetDialogChild()
    {
        //IPアドレス確認のダイアログから各々のUIを参照
        dialogMessageText = ipAddressDialog.transform.GetChild(0).GetComponent<Text>();
        inputIpAddress = ipAddressDialog.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();
        insertIpAddressButton = ipAddressDialog.transform.GetChild(2).GetComponent<Button>();

        //人数確認のダイアログから各々のUIを参照
        photonMessageText = photonDialog.transform.GetChild(0).GetComponent<Text>();
        onePlayerButton = photonDialog.transform.GetChild(1).GetComponent<Button>();
        twoPayersCreateButton = photonDialog.transform.GetChild(2).GetComponent<Button>();
        twoPlayersJoinButton = photonDialog.transform.GetChild(3).GetComponent<Button>();
    }

    private void Update()
    {

    }

    //タイトルで画面のどこかに触れたら
    public void OnClickGameStart()
    {
        //IPアドレスを問うダイアログをアクティブに
        ipAddressDialog.SetActive(true);

        //タイトル画面からIPアドレス確認ダイアログへ移るボタンを非アクティブに
        gameStartButton.SetActive(false);
    }

    //ダイアログのボタンが押された時、入力されたIPを参照してレベルデザイン取得する命令を出す関数
    public void OnClickIPAddressInsert()
    {


    }
}

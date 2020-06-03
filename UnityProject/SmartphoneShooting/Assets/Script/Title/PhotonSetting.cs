　using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PhotonSetting : Photon.MonoBehaviour
{
    [SerializeField]                                //人数選択ダイアログのテキストを参照
    private Text photonMessageText = default;

    private const string PHOTON_GAME_VER = "v1.0";  //バージョン指定
    private const int GAMEROOM_LIMIT = 2;           //部屋の制限人数
    private string roomName = "Room1";              //ルーム名の指定

    private const int GAMEROOM_SORO = 1;           //部屋の制限人数
    private bool createRoomOn = false;

    //各テキストの内容
    private const string createdRoomText = "ルームを作りました！\nもう１人を待っています…";
    private const string createRoomFailedText = "ルームの作成に失敗しました…";
    private const string joinedRoomText = "ルームを見つけました！\n２人プレイを開始します！";
    private const string joinRoomFailedText = "ルームが見つかりませんでした…";

    private void Start()
    {
        //photonへ接続
        PhotonNetwork.ConnectUsingSettings(PHOTON_GAME_VER);

        //1秒間に送信するパケット数を設定
        PhotonNetwork.sendRate = 60;
        PhotonNetwork.sendRateOnSerialize = 60;

        //「PhotonNetwork.LoadLevel()」を使える様にする
        PhotonNetwork.automaticallySyncScene = true;
    }

    //ルームオプションを設定する関数
    private RoomOptions SetRoomData()
    {
        //ハッシュテーブルの設定
        ExitGames.Client.Photon.Hashtable customProp = new ExitGames.Client.Photon.Hashtable(); // ハッシュテーブルを作成
        customProp.Add("roomName", roomName);                                                   // ルーム名
        PhotonNetwork.SetPlayerCustomProperties(customProp);                                    // ハッシュテーブルの情報を同期

        // ルームオプションにカスタムプロパティを設定
        RoomOptions roomOptions = new RoomOptions();                                            // ルームオプションの作成
        roomOptions.CustomRoomProperties = customProp;                                          // ハッシュテーブルの取得
        roomOptions.CustomRoomPropertiesForLobby = new string[] { "roomName" };                   // カスタムルームのプロパティを定義
        roomOptions.MaxPlayers = (byte)GAMEROOM_LIMIT;                                          // 部屋の最大人数を設定
        roomOptions.IsOpen = true;                                                              // 入室可能にする
        roomOptions.IsVisible = true;                                                           // ロビーから見えるようにする

        return roomOptions;
    }

    //「１で遊ぶ」ボタンが押された時
    public void Onclick1playerButton()
    {
        //ルームオプションを受け取る
        RoomOptions roomOptions = SetRoomData();

        //ルームを作成
        PhotonNetwork.CreateRoom(roomName, roomOptions, null);

        // ルーム入室の処理
        StartCoroutine(WaitOnePlayer());
    }

    //１人プレイヤー用ルーム入室待機処理GAMEROOM_SORO
    private IEnumerator WaitOnePlayer()
    {
        bool isWaiting = true;
        while (isWaiting)
        {
            //参加人数が2名になったら完了
            if (PhotonNetwork.room != null && PhotonNetwork.room.PlayerCount == GAMEROOM_SORO)
            {
                isWaiting = false;  //人数がそろった。
            }
            yield return null;
        }

        yield return null;

        //メインゲームへシーン移動
        PhotonNetwork.LoadLevel("GameScene");
    }


    //「２人で遊ぶ(部屋を作る)」ボタンが押された時
    public void Onclick2playersCreateButton()
    {
        //ルームオプションを受け取る
        RoomOptions roomOptions = SetRoomData();

       //ルームを作成
        PhotonNetwork.CreateRoom(roomName, roomOptions, null);

        // 対戦相手を待つ
        StartCoroutine(WaitOtherPlayer());
    }

    //「２人で遊ぶ(部屋に入る)」ボタンが押された時
    public void Onclick2playersJoinButton()
    {
        //ルームを作成
        PhotonNetwork.JoinRoom(roomName);
    }

    //部屋に誰かが入ってくるまで待機処理を行う関数
    public IEnumerator WaitOtherPlayer()
    {
        bool isWaiting = true;
        while (isWaiting)
        {
            //参加人数が2名になったら完了
            if (PhotonNetwork.room != null && PhotonNetwork.room.PlayerCount == GAMEROOM_LIMIT)
            {
                isWaiting = false;  //人数がそろった。
            }
            yield return null;
        }

        //メインゲームへシーン移動
        PhotonNetwork.LoadLevel("GameScene");
    }


    //以下Photonのコールバック関数
    //ルーム作成時に呼ばれる関数
    public void OnCreatedRoom()
    {
        photonMessageText.text = createdRoomText;
    }
    //ルーム作成失敗
    public void OnPhotonCreateRoomFailed()
    {
        photonMessageText.text = createRoomFailedText;
    }
    //ルーム入室
    public void OnJoinedRoom()
    {
        if(createRoomOn)
            photonMessageText.text = joinedRoomText;
        createRoomOn = true;
    }
    //ルーム入室失敗
    public void OnPhotonJoinRoomFailed(object[] cause)
    {
        photonMessageText.text = joinRoomFailedText;
    }
}

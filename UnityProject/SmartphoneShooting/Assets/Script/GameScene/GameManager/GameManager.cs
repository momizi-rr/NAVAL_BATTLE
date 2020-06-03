using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]                                                //テキストを参照
    private Text mainText = default;
    [SerializeField]                                                //照準のUI画像を参照
    private Image sightingImage = default;
    [SerializeField]                                                //射撃ボタンを参照
    private Button shootButtone = default;
    [SerializeField]                                                //警告用テキストの参照
    private Text WarningText = default;
    [SerializeField]                                                //ゲーム終了時の背景画像を参照
    private Image GameEndBackImage = default;

    [SerializeField]
    private GameObject levelDesignerPrefab = default;               //Prefab「LevelDesigner」を参照
    private LevelDesigner levelDesigner = default;                  //インスタンス生成した「LevelDesigner」のLevelDesignerコンポーネントを参照
    private const float startWatiTime = 3.0f;
    private bool getLevelDesigner = false;

    private const float startDelay = 3.0f;                          //ラウンド頭の遅延時間
    private const float endDelay = 4.0f;                            //ラウンド終了の遅延時間
    private const float syncDelay = 1.0f;                            //ラウンド終了の遅延時間

    private const string leveldesignerLordText = "Lording…";          //「Level 」をテキストに追加する文章
    private const string levelNotationText = "Level ";              //「Level 」をテキストに追加する文章
    private const string levelClearText = "Clear";                  //「Clear!!」をテキストに追加する文章
    private const string gameEndText = "GameEnd\nTouch to Retry";   //ゲーム終了時の内容をテキストに追加する文章

    private const int gameEndLevel = 10;                            //ゲームを終了するレベルを指定する
    private const int gameEndFontSize = 200;                        //ゲーム終了時に変更するフォントサイズの値

    private void Start()
    {
        //UIを非アクティブに
        sightingImage.enabled = false;
        mainText.enabled = false;
        shootButtone.enabled = false;
        GameEndBackImage.enabled = false;

        //マスタークライアントのみ、GameManagerを生成する
        if (PhotonNetwork.isMasterClient)
        {
            //「LevelDesigner」を生成
            GameObject instanceLevelDedigner = PhotonNetwork.Instantiate(levelDesignerPrefab.name, Vector3.zero, Quaternion.identity, 0);
            levelDesigner = instanceLevelDedigner.GetComponent<LevelDesigner>();
            getLevelDesigner = true;
        }

        //レベルデザインをロードするまで待機する関数
        StartCoroutine(GameStartWait());
    }

    private void Update()
    {
        if (!PhotonNetwork.isMasterClient && !getLevelDesigner && levelDesigner == null)
        {
            GameObject instanceLevelDedigner = GameObject.Find(levelDesignerPrefab.name + "(Clone)");
            if (instanceLevelDedigner)
            {
                levelDesigner = instanceLevelDedigner.GetComponent<LevelDesigner>();
                getLevelDesigner = true;
            }
        }
    }

    private IEnumerator GameStartWait()
    {
        mainText.enabled = true;
        mainText.text = leveldesignerLordText;

        yield return new WaitForSeconds(startWatiTime);

        //レベルデザインをデータベースから取得し配置
        if (PhotonNetwork.isMasterClient)
            levelDesigner.SetLevelDesign();

        //ゲームのメインループを開始
        StartCoroutine(GameLoop());
    }

    //ゲームのメインループを行うコルーチン
    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());   //ラウンド開始時の処理を行うコールチン
        yield return StartCoroutine(RoundPlaying());    //ゲームプレイ時の処理を行うコールチン
        yield return StartCoroutine(RoundEnding());     //ラウンド終了時の処理を行うコールチン

        //最終レベルかどうかを確認
        if (levelDesigner.ReturnCurrentLevel() < gameEndLevel)
        {
            //最終レベルではない時、ループ処理
            StartCoroutine(GameLoop());
        }
        else
        {
            //最終レベルの時
            mainText.text = gameEndText;                        //ゲーム終了を知らせるテキスト表示
            GameEndBackImage.enabled = true;                    //ゲーム終了時の背景画像を表示
            mainText.fontSize = gameEndFontSize;                //フォントサイズを変更
            GetComponent<RetryManager>().StartRetrySystem();    //リトライ用ボタンをアクティブにする命令を出す

            if (PhotonNetwork.isMasterClient)
            {
                GameObject instanceLevelDedigner = GameObject.Find(levelDesignerPrefab.name + "(Clone)");
                PhotonNetwork.Destroy(instanceLevelDedigner);
            }
        }
    }

    //ラウンド開始時の処理を行うコールチン
    private IEnumerator RoundStarting()
    {
        //テキストをアクティブにし、レベルスタート時の表記内容を追加
        mainText.enabled = true;
        mainText.text = levelNotationText + levelDesigner.ReturnCurrentLevel();

        //ゲーム開始時の余韻
        yield return new WaitForSeconds(startDelay);
    }

    //ゲームプレイ時の処理を行うコールチン
    private IEnumerator RoundPlaying()
    {
        //表示UIの入れ替え
        mainText.enabled = false;       //テキストを非アクティブに
        sightingImage.enabled = true;   //照準をアクティブに
        shootButtone.enabled = true;    //射撃ボタンをアクティブに
        WarningText.enabled = true;     //警告テキストをアクティブに

        //ターゲットがいなくなるまでループ
        while (levelDesigner.RetrunTargetCount() != 0)
        {
            yield return null;
        }
    }

    //ラウンド終了時の処理を行うコールチン
    private IEnumerator RoundEnding()
    {
        //表示UIの入れ替え
        sightingImage.enabled = false;
        shootButtone.enabled = false;
        mainText.enabled = true;
        WarningText.enabled = false;
        mainText.text = levelNotationText + levelClearText;    //テキストにクリア時の表記内容を追加

        //ゲーム開始時の余韻
        yield return new WaitForSeconds(endDelay);

        //レベルデザインをデータベースから取得し配置
        if (PhotonNetwork.isMasterClient)
            levelDesigner.SetLevelDesign();

        //ゲーム開始時の余韻
        yield return new WaitForSeconds(syncDelay);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryManager : MonoBehaviour
{
    [SerializeField]
    private GameObject retryButton = default;   //リトライするボタンを参照

    private void Awake()
    {
        //ゲーム開始時にリトライボタンを非アクティブに
        retryButton.SetActive(false);
    }

    //リトライボタンをアクティブにする関数
    public void StartRetrySystem()
    {
        retryButton.SetActive(true);
    }

    //リトライボタンが触られた時、ゲームを再スタート
    public void OnClickRetryButton()
    {
        PhotonNetwork.LoadLevel("GameScene");
    }
}

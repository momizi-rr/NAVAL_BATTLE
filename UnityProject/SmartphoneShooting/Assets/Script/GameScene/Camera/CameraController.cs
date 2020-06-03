using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    private const float round = 360.0f;                             //360度を収納
    private float angleAdjust = 0;                                  //正面を変更する為の差分を収納する変数

    [SerializeField]                                                //警告用テキストの参照
    private Text WarningText = default;
    private const float quarteRound = 90.0f;                        //90度を収納
    private const string WarningMessage = "そっちに敵船はいないぞ！";   //警告メッセージの収納

    private bool cameraSet = true;                                  //最初に一度だけカメラを初期位置にする処理を許可する

    private void Start()
    {
        //ジャイロを有効にするここから、ここから
        Input.gyro.enabled = true;
    }

    private void Update()
    {
        //カメラの角度を更新
        CameraUpdate();

        //警告が必要かチェック
        WarningCheck();
    }

    //カメラの角度を更新する関数
    private void CameraUpdate()
    {
        //ジャイロが有効な場合
        if (Input.gyro.enabled)
        {
            //傾きを取得
            Quaternion gyro = Input.gyro.attitude;

            //カメラを更新
            this.transform.localRotation = Quaternion.Euler(90, angleAdjust, 0) * (new Quaternion(-gyro.x, -gyro.y, gyro.z, gyro.w));

            //最初に一度だけカメラを初期位置にセット
            if (transform.localEulerAngles.y != 0 && cameraSet)
            {
                OnclickRestCameraOrigin();
                cameraSet = false;
            }
        }
    }

    //正面を今向いている角度に設定する関数
    public void OnclickRestCameraOrigin()
    {
        Transform myTransform = this.transform;
        Vector3 localAngle = myTransform.localEulerAngles;
        angleAdjust += (round - localAngle.y);
    }

    //警告が必要かどうかを確認する関数
    private void WarningCheck()
    {
        //カメラのY軸Rotateを取得
        Vector3 localAngle = transform.localEulerAngles;

        //90度〜270度の間は警告表示
        if (localAngle.y < quarteRound || round - quarteRound < localAngle.y)
            WarningText.text = "";
        else
            WarningText.text = WarningMessage;
    }
}

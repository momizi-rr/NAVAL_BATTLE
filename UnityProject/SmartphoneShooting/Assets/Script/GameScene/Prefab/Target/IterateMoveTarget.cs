using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IterateMoveTarget : MonoBehaviour
{
    private Vector3 startPos;                   //現在の位置
    private const float delta_X = 16.0f;        //移動するX軸の幅
    private const float speed_X = 0.3f;         //X軸の移動速度
    private const float delta_Z = 4.0f;         //移動するZ軸の幅
    private const float speed_Z = 0.3f;         //Z軸の移動速度

    private Vector3 MovePos;                    //スタート位置から動いた距離を取得する関数
    private const float swingAngle = 180.0f;    //旋回する角度
    private float endRote = 0;                  //旋回開始時から旋回した総角度
    private bool swingStart = false;            //旋回処理をするかしないかを決定(trueなら旋回)

    private float localTimeCoiunt = 0;
    private float localTimeDifference = 0;

    private void Start()
    {
        //現在のゲーム開始からの時間を収納
        localTimeDifference = Time.time;

        //戻ってくる地点を取得
        startPos = transform.position;
    }

    private void Update()
    {
        //スタート位置から動いた距離を取得
        MovePos = startPos - transform.position;

        //ローカルな経過秒を作り、localTimeCoiuntに収納
        localTimeCoiunt = Time.time - localTimeDifference;

        UpdatePos();    //現在位置の更新
        UpdateRote();   //ターゲットの向きを更新
    }

    //反復運動の処理をする関数
    private void UpdatePos()
    {
        Vector3 movePos = startPos;
        movePos.x += delta_X * Mathf.Sin(localTimeCoiunt * speed_X);  //X軸の移動
        movePos.z += delta_Z * Mathf.Cos(localTimeCoiunt * speed_Z);  //Z軸の移動
        transform.position = movePos;
    }

    //旋回の処理をする関数
    private void UpdateRote()
    {
        //「swingStart」がtrueのとき旋回処理
        if (swingStart)
        {
            Vector3 moveRote = transform.localEulerAngles;
            moveRote.y += swingAngle * (speed_X / 2 * Time.deltaTime);
            endRote += swingAngle * (speed_X / 2 * Time.deltaTime);
            transform.localEulerAngles = moveRote;
        }

        //「swingStart」の中身を決定
        CheckSwingStart();
    }

    //「swingStart」の中身を決定する関数
    private void CheckSwingStart()
    {
        if (delta_X / 2 < Mathf.Abs(MovePos.x)) //旋回を制限するif文(往復距離が残り1/4になったとき旋回スタート)
        {
            if (endRote > swingAngle)           //旋回処理の総回転数がswingAngleを越した時、旋回ストップ
                swingStart = false;
            else
                swingStart = true;
        }
        else
        {
            endRote = 0;
            swingStart = false;
        }
    }
}

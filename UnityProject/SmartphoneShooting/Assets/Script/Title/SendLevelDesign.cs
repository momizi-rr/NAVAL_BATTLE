using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SendLevelDesign : MonoBehaviour
{
    //ゲームシーンへ渡すレベルデザインの全データを保持する関数
    public static List<LevelDesignData> levelDataList = default;

    private void Awake()
    {
        //シーンが変わってもDestroyしない様に
        DontDestroyOnLoad(this);
    }

    //jsonから変換されたレベルデザインのデータを取得する関数
    public void SetLevelData(List<LevelDesignData> list)
    {
        levelDataList = list;
    }

    //保持しているレベルデザインのデータを渡す関数
    public static List<LevelDesignData> GetlevelDataList()
    {
        return levelDataList;
    }
}

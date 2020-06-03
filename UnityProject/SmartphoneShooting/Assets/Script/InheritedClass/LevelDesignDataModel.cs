using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MiniJSON;

public class LevelDesignDataModel
{
	public static List<LevelDesignData> DeserializeFromJson(string sStrJson)
	{
		var ret = new List<LevelDesignData>();

		// JSONデータは最初は配列から始まるので、Deserialize（デコード）した直後にリストへキャスト      
		IList jsonList = (IList)Json.Deserialize(sStrJson);

		// リストの内容はオブジェクトなので、辞書型の変数に一つ一つ代入しながら、処理
		foreach (IDictionary jsonOne in jsonList)
		{
			//新レコード解析開始
			var tmp = new LevelDesignData();

			if (jsonOne.Contains("Level"))
			{
				tmp.Level = (int)(long)(long)jsonOne["Level"];
			}
			if (jsonOne.Contains("Pattern"))
			{
				tmp.Pattern = (int)(long)jsonOne["Pattern"];
			}
			if (jsonOne.Contains("PosX"))
			{
				tmp.PosX = (int)(long)jsonOne["PosX"];
			}
			if (jsonOne.Contains("PosY"))
			{
				tmp.PosY = (int)(long)jsonOne["PosY"];
			}
			if (jsonOne.Contains("PosZ"))
			{
				tmp.PosZ = (int)(long)jsonOne["PosZ"];
			}
			if (jsonOne.Contains("RateX"))
			{
				tmp.RateX = (int)(long)jsonOne["RateX"];
			}
			if (jsonOne.Contains("RateY"))
			{
				tmp.RateY = (int)(long)jsonOne["RateY"];
			}
			if (jsonOne.Contains("RateZ"))
			{
				tmp.RateZ = (int)(long)jsonOne["RateZ"];
			}
			if (jsonOne.Contains("RateX"))
			{
				tmp.ScaleX = (int)(long)jsonOne["ScaleX"];
			}
			if (jsonOne.Contains("ScaleY"))
			{
				tmp.ScaleY = (int)(long)jsonOne["ScaleY"];
			}
			if (jsonOne.Contains("ScaleZ"))
			{
				tmp.ScaleZ = (int)(long)jsonOne["ScaleZ"];
			}
				//現レコード解析終了
				ret.Add(tmp);
		}
		return ret;
	}
}

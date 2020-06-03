using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalGameManager : MonoBehaviour
{
	public static GlobalGameManager _instance = null;

	//public TitleManager titleManager = null;
	public LevelDesigner levelDesigner = null;

	void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(gameObject);  //これを記述する事でこのゲームオブジェクトはシーンが切り替わっても破棄されない。
	}
}

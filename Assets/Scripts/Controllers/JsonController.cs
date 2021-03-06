﻿using LitJson;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JsonController : MonoBehaviour
{
	[Header("Views")]
	public GameObject _mainSceneCanvas;
	public GameObject _loadingSceneCanvas;
	private string jsonString;
	public static JsonData jsonDataStages;
	public static JsonData jsonDataConfig;
	public string _stageUrl;

	private WWW _www;


	IEnumerator Start()
	{
		_www = new WWW(_stageUrl);

		yield return _www;

		if (_www.error == null)
		{
			print(_www.text);
			jsonDataStages = JsonMapper.ToObject(_www.text.Trim());
			loadGlobalVariablesFromJson();
			yield return new WaitForSeconds(1f);
			this._mainSceneCanvas.SetActive(true);
			this._loadingSceneCanvas.SetActive(false);
		}

		else
		{
			Debug.Log("ERROR: " +  _www.error);
		}        
	}

    private void loadGlobalVariablesFromJson()
    {
        GlobalVariables._totallyStages = jsonDataStages["Stages"].Count;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_AgainOrExit : MonoBehaviour {

	public IE_FristEnven _FristTip;
	public string _SceneName;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name == "UI_Again") {
			OnAgain(_SceneName);
		}

		if (other.gameObject.name == "UI_Exit")
		{
			OnExit(_SceneName);
		}
	}

	// 重来
	public void OnAgain(string sceneName) {

		SceneManager.LoadScene(sceneName);
		_FristTip.HideTips();

	}

	// 退出
	public void OnExit(string sceneName)
	{

		SceneManager.LoadScene(sceneName);
	}
}

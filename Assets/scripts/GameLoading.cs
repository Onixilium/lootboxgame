using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoading : MonoBehaviour
{

	public KeyCode _keyCode = KeyCode.Space;
	public GameObject loadingIcon;
	private AsyncOperation async;

	IEnumerator Start()
	{
		async = SceneManager.LoadSceneAsync("runner");
		loadingIcon.SetActive(true);
		yield return true;
		async.allowSceneActivation = false;
		loadingIcon.SetActive(false);
	}

	void Update()
	{
		if (Input.GetKeyDown(_keyCode)) async.allowSceneActivation = true;
	}
}

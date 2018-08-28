using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	private int map1, mapIntro, mapCommon;
	public GameObject FadeOutMan;

	private void Start()
	{
		mapIntro = 0;
		mapCommon = 1;
		Time.timeScale = 1f;
	
	}

	public void PlayGame()
	{
		FadeOutMan.GetComponent<FadeOut>().OnFadeToNum(mapCommon);
	}

	public void ToMainMenu()
	{
		//intro 화면으로
		FadeOutMan.GetComponent<FadeOut>().OnFadeToNum(mapIntro);
	}

	public void GameOver()
	{
		FadeOutMan.GetComponent<FadeOut>().OnFadeToNum(mapCommon);
	}

	public void QuitGame()
	{
		Application.Quit();
	}
	
}

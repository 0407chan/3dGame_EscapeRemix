using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FadeOut : MonoBehaviour {
	public Animator animator;
	public int NumMap;

	public void FadeToStart()
	{
		animator.SetTrigger("FadeOut");
		Time.timeScale = 1f;
	}

	public void GameDone()
	{
		animator.SetTrigger("GameDone");
		Time.timeScale = 1f;
	}

	public void FadeToMain()
	{
		animator.SetTrigger("FadeToMain");
		Time.timeScale = 1f;
	}

	public void ToPuzzleMap()
	{
		SceneManager.LoadScene(1);
	}

	public void OnFadeToNum(int Num)
	{
		Num = NumMap;
		animator.SetTrigger("FadeOut");
		Time.timeScale = 1f;
	}

	public void OnFadeToMain()
	{
		SceneManager.LoadScene(0);
	}

	public void OnFadeComplete()
	{
		SceneManager.LoadScene(1);
	}

	public void ToGameDone()
	{
		SceneManager.LoadScene(0);
	}
}

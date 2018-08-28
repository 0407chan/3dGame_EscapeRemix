using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPuased = false;
	public int CurScene = 0;
	public GameObject pauseMenuUI;
	public GameObject SceneMan;
	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
		{
			if (GameIsPuased)
			{
				Resume();
				UnityEngine.Cursor.visible = false;
			}
			else
			{
				Pause();
			}
		}
	}

	void Resume()
	{
		UnityEngine.Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPuased = false;
		
	}

	public void ResumeMenu()
	{
		UnityEngine.Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;

		pauseMenuUI.SetActive(false);
		Time.timeScale = 1f;
		GameIsPuased = false;
	}

	void Pause()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPuased = true;
	}

	public void PauseMenu2()
	{
		Cursor.lockState = CursorLockMode.None;
		Cursor.lockState = CursorLockMode.Confined;
		Cursor.visible = true;
		pauseMenuUI.SetActive(true);
		Time.timeScale = 0f;
		GameIsPuased = true;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(1);
	}
}

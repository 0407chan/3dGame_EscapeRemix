using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public GameObject GameOver, FadeMan, Dia,MainMenu;
	public int life;
	private bool isDead;
	// Use this for initialization
	void Start () {
		life = PlayerManager.FriendSheild;
		isDead = true;
		StartCoroutine(GameOverPlayer());
	}

	IEnumerator GameOverPlayer()
	{
		while (true)
		{
			life = PlayerManager.FriendSheild;
			//죽은거
			if (life < 0 && isDead == true)
			{
				isDead = false;
				Dia.GetComponent<DialogueTrigger>().TriggerDialogue();
				Time.timeScale = 1f;
				//Wait for 4 seconds
				yield return new WaitForSeconds(1);
				FadeMan.GetComponent<FadeOut>().FadeToStart();
			}
			yield return null;
		}
	}
	
}

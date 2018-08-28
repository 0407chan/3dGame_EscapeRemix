using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDone : MonoBehaviour
{
	public GameObject FadeOutMan, dia;
	

	void OnTriggerEnter(Collider other)
	{
		if(other.tag == "Player")
		{
			dia.GetComponent<DialogueTrigger>().TriggerDialogue();
			Time.timeScale = 1f;
			FadeOutMan.GetComponent<FadeOut>().GameDone();
		}
	}
}


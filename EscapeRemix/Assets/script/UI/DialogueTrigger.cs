using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;

    public int HaveConver;
	private void Start()
	{
		//기본적으로 1번만 대화하고 끝. 
		HaveConver = 1;
	}
	public void TriggerDialogue()
    {
		Time.timeScale = 0f;
		
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }

    private void OnTriggerEnter(Collider other)
    {
		if (other.CompareTag("Player" ) && HaveConver  > 0)
        {
			Time.timeScale = 0f;
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            HaveConver--;
        }
    }
}

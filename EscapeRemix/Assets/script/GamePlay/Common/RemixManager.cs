using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemixManager : MonoBehaviour {
	public GameObject mainCam, remixCam, dia;
	public float waitTime;
	private bool isRemix;
	private bool isDone;

	private void Start()
	{
		isDone = false;
		isRemix = true;
	}

	private void Update()
	{
		if (isRemix)
		{
			isRemix = false;
			if (Remix.isMap3)
			{
				RemixOn();
				isDone = true;
			}
		}
	}
	
	public bool GetDone()
	{
		return isDone;
	}
	public void SetDone()
	{
		isDone = false;
	}
	public void RemixOff()
	{
		mainCam.SetActive(true);
		remixCam.SetActive(false);
	}

	public void RemixOn() {
		mainCam.SetActive(false);
		remixCam.SetActive(true);
		dia.GetComponent<DialogueTrigger>().TriggerDialogue();
	}
}

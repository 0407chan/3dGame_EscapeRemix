using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSelect : MonoBehaviour {

	public string str;
	public GameObject AudioMan;
	
	public void AudioPlay()
	{
		AudioMan.GetComponent<AudioManager>().Play(str);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SqawnManager : MonoBehaviour {
	public GameObject Player;
	public GameObject map1, map2, map3;
	// Use this for initialization
	
	public void SqawnMap1()
	{
		Player.GetComponent<Transform>().position = map1.transform.position;
	}
	public void SqawnMap2()
	{
		Player.GetComponent<Transform>().position = map2.transform.position;
	}
	public void SqawnMap3()
	{
		Player.GetComponent<Transform>().position = map3.transform.position;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestScene : MonoBehaviour
{
	public GameObject Sqawn;
	public GameObject SceneMan;

	private void Update()
	{
		//Puzzle all Clear
		if (Input.GetKeyDown(KeyCode.Alpha5))
		{
			Debug.Log("All Puzzle Cleared!");
			DoorManager_map1.puzzle1 = 4;
			DoorManager_map1.puzzle2 = 4;
			DoorManager_map1.puzzle3 = 4;

			DoorManager_map2.puzzle1 = 4;
			DoorManager_map2.puzzle2 = 4;
			DoorManager_map2.puzzle3 = 4;

			DoorManager_map3.puzzle1 = 4;
			DoorManager_map3.puzzle2 = 4;
			DoorManager_map3.puzzle3 = 4;
		}

		//맵 1로
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Debug.Log("Puzzle Solved!");
			//SceneMan.GetComponent<SceneOnOffManager>().ToMap1();
			SceneMan.GetComponent<SqawnManager>().SqawnMap1();
		}

		//맵2로
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			//SceneMan.GetComponent<SceneOnOffManager>().ToMap2();
			SceneMan.GetComponent<SqawnManager>().SqawnMap2();
		}

		//맵 3으로
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			//SceneMan.GetComponent<SceneOnOffManager>().ToMap3();
			SceneMan.GetComponent<SqawnManager>().SqawnMap3();
		}

		//인트로
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			SceneManager.LoadScene(0);
		}
	}
}
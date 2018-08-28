using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hollway2to3 : MonoBehaviour
{
	public GameObject SceneMap, Check1, Check2, player, point1, point2;
	public GameObject Cam;
	public bool MapOn, check1, check2, check;
	public int CurMap = 0;
									//갈때 맵3 키고,  맵2 끔,         올때 : 맵2 키고,   맵3 끔
	public float distance, Go_map3On, Go_map2Off, Back_map2On, Back_map3Off;
	public bool BoxIn = false;
	private bool Go1, Go2, Back1, Back2;
	private void Start()
	{

		MapOn = true;
		CurMap = SceneOnOffManager.CurMap;
		Go1 = true;
		Go2 = true;
		Back1 = true;
		Back2 = true;

		Go_map3On = Vector3.Distance(Check1.transform.position, point1.transform.position);
		Go_map2Off = Vector3.Distance(Check1.transform.position, point2.transform.position);
		Back_map2On = Vector3.Distance(Check2.transform.position, point2.transform.position);
		Back_map3Off = Vector3.Distance(Check2.transform.position, point1.transform.position);
	}

	private void Update()
	{
		check1 = Check1.GetComponent<HollCheck>().GetCheck();
		check2 = Check2.GetComponent<HollCheck>().GetCheck();
		//박스에 들어왔음
		if (BoxIn)
		{
			//2에서 3로 갈때
			if (check1)
			{
				//플레이어 거리
				distance = Vector3.Distance(Check1.transform.position, player.transform.position);
				if (distance > Go_map3On)
				{
					if (Go2)
					{
						Go2 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map3On();
						Remix.isMap3 = true;
					}
				}
				else
				{
					Go2 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map3Off();
					Remix.isMap3 = false;
				}

				if (distance > Go_map2Off)
				{
					Go1 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map2Off();
				}
				else
				{
					if (Go1)
					{
						Go1 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map2On();
					}
				}
			}
			//3에서 2로 갈때
			if (check2)
			{
				distance = Vector3.Distance(Check2.transform.position, player.transform.position);
				if (distance > Back_map2On)
				{
					if (Back1)
					{
						Back1 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map2On();
					}

				}
				else
				{
					Back1 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map2Off();
				}

				if (distance > Back_map3Off)
				{
					Back2 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map3Off();
				}
				else
				{
					if (Back2)
					{
						Back2 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map3On();
					}
				}
			}

		}
	}
	//박스에 들어감
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			BoxIn = true;
		}
	}

	//박스에서 나온다.
	void OnTriggerExit(Collider other)
	{

		if (other.tag == "Player")
		{
			//Cam.GetComponent<RemixManager>().RemixOn();
			Check1.GetComponent<HollCheck>().CheckOff();
			Check2.GetComponent<HollCheck>().CheckOff();
			BoxIn = false;
			Go1 = true;
			Go2 = true;
			Back1 = true;
			Back2 = true;

		}
	}
}

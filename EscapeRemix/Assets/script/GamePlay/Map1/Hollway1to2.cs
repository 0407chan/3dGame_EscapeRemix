using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hollway1to2 : MonoBehaviour
{
	public GameObject SceneMap, Check1,Check2, player, point1, point2,Students;
	public bool MapOn,check1,check2 ,check;
	public int CurMap = 0;
	                                //갈때 맵2 키고,  맵1 끔,         올때 : 맵1 키고,   맵2 끔
	public float distance, Go_map2On, Go_map1Off, Back_map1On, Back_map2Off;
	public bool BoxIn = false;
	private bool Go1,Go2, Back1,Back2;
	private void Start()
	{

		MapOn = true;
		CurMap = SceneOnOffManager.CurMap;
		Go1 = true;
		Go2 = true;
		Back1 = true;
		Back2 = true;

		Go_map2On = Vector3.Distance(Check1.transform.position, point1.transform.position);
		Go_map1Off = Vector3.Distance(Check1.transform.position, point2.transform.position);
		Back_map1On = Vector3.Distance(Check2.transform.position, point2.transform.position);
		Back_map2Off = Vector3.Distance(Check2.transform.position, point1.transform.position);
	}

	private void Update()
	{
		check1 = Check1.GetComponent<HollCheck>().GetCheck();
		check2 = Check2.GetComponent<HollCheck>().GetCheck();
		//박스에 들어왔음
		if (BoxIn)
		{
			//1에서 2로 갈때
			if (check1)
			{
				//플레이어 거리
				distance = Vector3.Distance(Check1.transform.position, player.transform.position);
				if(distance > Go_map2On)
				{
					if (Go2)
					{
						Go2 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map2On();
						Students.SetActive(true);
					}
				}
				else
				{
					Go2 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map2Off();
					Students.SetActive(false);
				}

				if(distance > Go_map1Off)
				{
					Go1 = true ;
					SceneMap.GetComponent<SceneOnOffManager>().Map1Off();
				}
				else
				{
					if(Go1)
					{
						Go1 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map1On();
					}
				}
			}
			//2에서 1로 갈때
			if (check2)
			{
				distance = Vector3.Distance(Check2.transform.position, player.transform.position);
				if (distance > Back_map1On)
				{
					if (Back1)
					{
						Back1 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map1On();
					}
					
				}
				else
				{
					Back1 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map1Off();
				}

				if (distance > Back_map2Off)
				{
					Back2 = true;
					SceneMap.GetComponent<SceneOnOffManager>().Map2Off();
				}
				else
				{
					if (Back2)
					{
						Back2 = false;
						SceneMap.GetComponent<SceneOnOffManager>().Map2On();
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

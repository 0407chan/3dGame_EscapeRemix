using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneOnOffManager : MonoBehaviour
{
	public bool map1 = true, map2 = false, map3= true;

	//각 맵 1,2,3
	public GameObject scene1, scene2, scene3;
	SqawnManager sp;
	public static int CurMap = 0;
	public int CurScene = 0;

	private bool reSpawn;

	private void Start()
	{
		sp = GetComponent<SqawnManager>();
		CurMap = 1;
	}

	private void Update()
	{
		CurScene = CurMap;

		if (map1 == true)
		{
			scene1.SetActive(true);
			CurMap = 1;
		}
		else
		{
			scene1.SetActive(false);
		}

		if (map2 == true)
		{
			scene2.SetActive(true);
			CurMap = 2;
		}
		else
		{
			scene2.SetActive(false);
		}

		if (map3 == true)
		{
			scene3.SetActive(true);
			CurMap = 3;
		}
		else
		{
			scene3.SetActive(false);
		}
	}

	public void Map1Off()
	{
		map1 = false;
	}
	public void Map2Off()
	{
		map2 = false;
	}
	public void Map3Off()
	{
		map3 = false;
	}

	public void Map1On()
	{
		map1 = true;
	}

	public void GetMap1sp()
	{
		sp.SqawnMap1();
	}

	public void Map2On()
	{
		map2 = true;
	}
	public void Map3On()
	{
		map3 = true;
	}

	public bool GetMap1()
	{
		return map1;
	}
	public bool GetMap2()
	{
		return map2;
	}
	public bool GetMap3()
	{
		return map3;
	}
	/*
	public int GetCurMap()
	{
		return CurScene;
	}
	public void SetCurMap(int num)
	{
		CurMap = num;
	}

	public void CurMapOff()
	{
		//기존에 켜져있는 맵 끄고
		if (CurMap == 1)
		{
			map1 = false;
		}
		else if (CurMap == 2)
		{
			map2 = false;
		}
		else if (CurMap == 3)
		{
			map3 = false;
		}
	}

	
	public void ToMap1()
	{
		CurMapOff();
		map1 = true;
		CurMap = 1;
		if (reSpawn) sp.SqawnMap1();
	}

	public void ToMap2()
	{
		CurMapOff();
		map2 = true;
		CurMap = 2;
		if (reSpawn) sp.SqawnMap2();
	}

	public void ToMap3()
	{
		CurMapOff();
		map3 = true;
		CurMap = 3;
		if (reSpawn) sp.SqawnMap3();
	}

	public void ToMapCur(int num)
	{
		if (num == 1)
		{
			ToMap1();
		}
		else if (num == 2)
		{
			ToMap2();
		}
		else if (num == 3)
		{
			ToMap3();
		}
	}

	
	
	*/
}

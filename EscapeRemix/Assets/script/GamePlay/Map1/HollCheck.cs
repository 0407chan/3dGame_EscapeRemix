using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollCheck : MonoBehaviour
{
	public bool check;
	public Material active;
	private Material originalMat;
	public Renderer body;
	private void Start()
	{
		check = false;
		originalMat = body.material;
	}

	public void CheckOff()
	{
		check = false;
		body.material = originalMat;
	}

	public bool GetCheck()
	{
		return check;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			check = true;
			body.material = active;
		}
	}
	
}
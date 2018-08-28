using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleDetect_map1: MonoBehaviour {

    public Material active;
    private Material originalMat;
    public Renderer body;
    
	// Use this for initialization
	void Start () {
        originalMat = body.material;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Puzzle1")
        {
            body.material = active;
            DoorManager_map1.puzzle1++;
        }
		else if (collision.gameObject.tag == "Puzzle2")
		{
			body.material = active;
			DoorManager_map1.puzzle2++;
		}
		else if (collision.gameObject.tag == "Puzzle3")
		{
			body.material = active;
			DoorManager_map1.puzzle3++;
		}

		if( (DoorManager_map1.puzzle1 + DoorManager_map1.puzzle2 + DoorManager_map1.puzzle3) == 12)
		{
			DoorManager_map1.isSolved = true;
		}
		else
		{
			DoorManager_map1.isSolved = false;
		}
	}
    private void OnTriggerExit(Collider collision)
    {
		if (collision.gameObject.tag == "Puzzle1")
		{
			body.material = originalMat;
			DoorManager_map1.puzzle1--;
		}
		else if (collision.gameObject.tag == "Puzzle2")
		{
			body.material = originalMat;
			DoorManager_map1.puzzle2--;
		}
		else if (collision.gameObject.tag == "Puzzle3")
		{
			body.material = originalMat;
			DoorManager_map1.puzzle3--;
		}
	}
    
}

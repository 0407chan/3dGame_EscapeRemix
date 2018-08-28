using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Detect_particle : MonoBehaviour
{
    public GameObject particle;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            particle.SetActive(true);
        }
    }

    void OnTriggerExit(Collider collision)
    {
		if (collision.tag == "Player")
		{
			particle.SetActive(false);
        }
    }
}


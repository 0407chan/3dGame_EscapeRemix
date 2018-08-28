using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Milk : MonoBehaviour {
    public GameObject milk;
	public GameObject milkPC,milkDetect;

	private bool isHitted;
	
    public float disTime = 10f;
	// Use this for initialization
	void Start () {
        milkPC.SetActive(false);
		isHitted = false;
	}


    private void OnTriggerEnter(Collider collision)
    {
		
		//친구가 맞으면
		if (collision.gameObject.tag == "Student" && isHitted== false)
		{
			isHitted = true;
			collision.GetComponent<Animator>().SetBool("dead", true);
			//안따라오게 하고
			collision.GetComponent<NavMeshAgent>().isStopped = true;
			//죽은애 콜라이더 끔
			collision.GetComponent<CapsuleCollider>().enabled = false;
			//수 빼줌
			PlayerManager.FriendSheild--;
			
		}
		
		//사람이 맞으면
		if (collision.gameObject.tag == "Player" && isHitted == false)
		{
			isHitted = true;
			PlayerManager.FriendSheild--;
			collision.GetComponent<Animator>().SetBool("dead", true);

			Destroy(milk.gameObject, Time.deltaTime * disTime);
			milkPC.SetActive(true);
		}

		Destroy(milk.gameObject, Time.deltaTime * disTime * 5.0f);
		milkPC.SetActive(true);
		milkDetect.SetActive(false);

		isHitted = false;
	}
}

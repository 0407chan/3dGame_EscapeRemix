using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorManager_map2 : MonoBehaviour
{
	public GameObject solvedDialogue;
	public GameObject NotSolvedDialogue;
	
	//map1 Puzzles
	public GameObject PC1, PC2, PC3;

	//map2 particle
	public GameObject particle;
	public int Puzzle_Count = 0;

	//puzzle 1,2,3
	public static int puzzle1;
	public static int puzzle2;
	public static int puzzle3;

	private Animator _animator;
	private AudioSelect _audio;
	public static bool isSolved;
	private bool solDialogue = true;
	private bool isOpen = false;
	private int num_open = 1;

	// Use this for initialization
	void Start()
	{
		_audio = GetComponent<AudioSelect>();
		_animator = GetComponent<Animator>();
		puzzle1 = 0;
		puzzle2 = 0;
		puzzle3 = 0;
		isSolved = false;
	}

	void Update()
	{
		if (puzzle1 == 4)
		{
			PC1.SetActive(true);
		}

		if (puzzle2 == 4)
		{
			PC2.SetActive(true);
		}
		if (puzzle3 == 4)
		{
			PC3.SetActive(true);
		}

		Puzzle_Count = puzzle1 + puzzle2 + puzzle3;
		//한번만 실행되게 하기위해 
		if (solDialogue && isSolved)
		{
			solvedDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
			solDialogue = false;
		}
	}
	//트리거를 당기면 문이 열림.
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player" && num_open == 1)
		{
			//퍼즐이 풀려있으면
			if (isSolved)
			{
				//닫혀있으면
				if (isOpen == false)
				{
					_audio.AudioPlay();
					isOpen = true;
					_animator.SetBool("close", false);
					_animator.SetBool("open", true);
					num_open -= 1;
				}
				else
				{
					_animator.SetBool("open", false);
					_animator.SetBool("close", true);
					isOpen = false;
				}
			}
			//퍼즐 안풀려있으면
			else
			{
				NotSolvedDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
			}
		}
	}


}

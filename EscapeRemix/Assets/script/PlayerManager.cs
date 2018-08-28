using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

	
    #region Singleton
    public static PlayerManager instance;
	public GameObject GameOverDia;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public static int FriendSheild;
	public int NumFriend;
	public static bool isGameOver;

	private void Start()
	{
		FriendSheild = 0;
		isGameOver = false;
	}

	private void Update()
	{
		NumFriend = FriendSheild;
	}

}

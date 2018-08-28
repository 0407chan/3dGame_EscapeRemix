using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;

public class Minimap : MonoBehaviour{
    public GameObject cam;
    
    void start()
    {
        cam.SetActive(false);
       
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            print("눌렸다");
            cam.SetActive(true);
        }


        if(Input.GetKeyUp(KeyCode.R))
        {
            print("뗏다");
            cam.SetActive(false);
        }

    }
}

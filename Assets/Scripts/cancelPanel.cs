﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancelPanel : MonoBehaviour {
    public GameObject Panel;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       
    }

    public void clickCancel()
    {
        Panel.SetActive(false);
    }
}
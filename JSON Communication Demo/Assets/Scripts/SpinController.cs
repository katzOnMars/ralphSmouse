﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinController : MonoBehaviour {




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime);
        transform.Translate(Vector3.up * Time.deltaTime*40, Space.World);
    }
}

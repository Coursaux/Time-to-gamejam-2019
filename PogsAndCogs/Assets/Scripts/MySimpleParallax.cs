﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MySimpleParallax : MonoBehaviour
{
	public float parallaxSpeed = 0.5f;

	private Transform followObject;
	private float previousX;

	void Start () {
		// idk if i should follow player or camera
		followObject = GameObject.FindGameObjectWithTag("Player").transform;
		previousX = followObject.transform.position.x;
	}
	
	void Update () {
		float deltaX = followObject.transform.transform.position.x - previousX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);

		previousX = followObject.transform.position.x;
	}
}

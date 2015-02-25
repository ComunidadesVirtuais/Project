﻿using UnityEngine;
using System.Collections;

[ExecuteInEditMode]  
public class FollowPlayer : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("player");
		//this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		 this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
	}
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class Lizard : MonoBehaviour {

	private Attacker attacker;
	private Animator animator;

	// Use this for initialization
	void Start () {
		attacker = GetComponent<Attacker>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}	

	void OnTriggerEnter2D(Collider2D other) {
		GameObject obj = other.gameObject;
		if (!obj.GetComponent<Defender>()){
			return;
		}

		Debug.Log(name + " collided with "+ other);

		animator.SetBool("isAttacking",true);
		attacker.Attack(obj);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]

public class SackDemon : MonoBehaviour {

	private Animator animator;
	private Attacker attacker;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		attacker = GetComponent<Attacker>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		GameObject obj = other.gameObject;
		if (!obj.GetComponent<Defender>()){
			return;
		}

		Debug.Log(name + " collided with "+ other);	

		if (obj.GetComponent<StarTrophy>()){
			animator.SetTrigger("jumpTrigger");
		} else {
			animator.SetBool("isAttacking",true);
			attacker.Attack (obj);
		}
	}
}

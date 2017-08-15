using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range (-1f,1.5f)] private float currentSpeed; //this is awesome! I love it. This Range thing is cool
	private GameObject currentTarget;
	private Health otherHealth;
	private Animator animator;

	// Use this for initialization
	void Start () {
		Rigidbody2D myRigidBody = gameObject.AddComponent<Rigidbody2D>();
		myRigidBody.isKinematic = true;
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);
		if (!currentTarget){
			animator.SetBool("isAttacking",false);
		}
	}

	void SetSpeed(float speed){
		currentSpeed = speed;
	}
	void StrikeCurrentTarget(float damage){
		Debug.Log(name + " is attacking for "+ damage);
		if (currentTarget && otherHealth){
			otherHealth.TakeDamage(damage);
		}
	}

	public void Attack (GameObject obj){
		if(obj){
			currentTarget = obj;
			otherHealth = currentTarget.GetComponent<Health>();
		} else {
			Debug.LogError("No object passed in to" + name + " 's Attack method");
		}
	}
}

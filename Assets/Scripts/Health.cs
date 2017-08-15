using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	public float health;

	public void TakeDamage(float damage){
		Debug.Log(name +" is taking "+ damage +" damage");
		health -= damage;
		Debug.Log(health + " health");
		if (health <= 0){
			DestroyObject();
		}
	}

	public void DestroyObject (){
		Destroy(gameObject);
	}
}

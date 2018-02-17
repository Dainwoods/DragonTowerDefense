using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	
		
	public float MaxHealth = 100F;
	public float Health { get; set; }
	public bool Damageable = false;
	
	// Use this for initialization
	public void Start ()
	{
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void TakeDamage(float damage)
	{
		Debug.Log(Health);
		Health -= damage;
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}

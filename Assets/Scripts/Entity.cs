using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	
		
	public float MaxHealth = 100;
	public float Health { get; set; }
	
	// Use this for initialization
	public void Start () {
		
		
	}
	
	// Update is called once per frame
	public void Update () {
		
	}

	public void TakeDamage(float damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Destroy(gameObject);
		}
	}
}

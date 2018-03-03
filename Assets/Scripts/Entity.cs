using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {
	
		
	public float MaxHealth = 100F;

	public virtual float Health
	{
		get { return _health; }
		set { _health = Mathf.Max(value, 0); }
	}

	public bool Damageable = false;
	private float _health;

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

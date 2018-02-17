using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

	public float Speed = 5F;
	public float MaxHealth = 100;

	private Rigidbody2D _rigidbody;
	private float _health;

	// Use this for initialization
	void Start ()
	{
		_rigidbody = GetComponent<Rigidbody2D>();
		_health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update ()
	{
		_rigidbody.velocity = Vector2.right * Speed;
	}

	public void TakeDamage(float damage)
	{
		_health -= damage;
		if (_health <= 0)
		{
			Destroy(gameObject);
		}
	}
}

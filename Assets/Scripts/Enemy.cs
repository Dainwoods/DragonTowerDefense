using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

	public float Speed = 5F;
	public float Damage = 10F;

	private Rigidbody2D _rigidbody;
	private float _nextAttack = 0F;

	private GameObject _target = null;

	// Use this for initialization
	public void Start ()
	{
		base.Start();
		_rigidbody = GetComponent<Rigidbody2D>();
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	public void Update ()
	{
		base.Update();
		_rigidbody.velocity = Vector2.right * Speed;


		if (_target != null)
		{
            _tryAttack();
		}
		
	}

	private void _tryAttack()
	{
		if (Time.time > _nextAttack)
		{
            var trapScript = _target.GetComponent<Trap>();
            trapScript.TakeDamage(Damage);
            _nextAttack = Time.time + 1.0F;
		}
	}

	public void StartAttacking(GameObject target)
	{
			_target = target;
	}
}

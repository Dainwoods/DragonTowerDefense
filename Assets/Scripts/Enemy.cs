using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

	public float Speed = 5F;
	public float Damage = 10F;
	public GameObject Gold;

	private Rigidbody2D _rigidbody;
	private float _nextAttack = 0F;

	private GameObject _target = null;
	private bool _retreating = false;
	
	
	public override float Health
	{
		set
		{
			base.Health = value;
			if (Health <= 0)
			{
				Die();
			}
		}
	}

	public void Die()
	{
		Destroy(gameObject);
		if (_retreating)
		{
            Instantiate(Gold, transform.position, Quaternion.identity);
		}
	}

	// Use this for initialization
	public new void Start ()
	{
		base.Start();
		_rigidbody = GetComponent<Rigidbody2D>();
		Health = MaxHealth;
	}

	public void ChangeDirection()
	{
		if (!_retreating)
		{
			_retreating = true;
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
			RoundHandler.gold -= 1;
		}
	}

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			ChangeDirection();
		}
	}
	
	// Update is called once per frame
	public new void Update ()
	{
		base.Update();


		if (_target != null)
		{
			_tryAttack();
		}
		else
		{
			if (_retreating)
			{
				_rigidbody.velocity = Vector2.left * Speed;
			}
			else
			{
				_rigidbody.velocity = Vector2.right * Speed;
			}
		}
		
		Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
		if (screenPoint.x < -.1)
		{
			Destroy(gameObject);
		};

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

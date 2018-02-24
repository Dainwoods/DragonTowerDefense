using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{

	public float Damage = 5.0F;
	public float DamageDelay = 1.0F;
	private List<Enemy> _enemies = new List<Enemy>();
	private float _nextAttack = 0F;

	// Update is called once per frame
	public new void Update () {
		base.Update();

		if (Time.time > _nextAttack)
		{
			for (int i = 0; i < _enemies.Count; i++)
			{
				_enemies[i].TakeDamage(Damage);
			}
            Health -= 1;
			_nextAttack = Time.time + DamageDelay;
		}
	}
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (IsActive && collision.gameObject.CompareTag("Enemy"))
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			_enemies.Add(enemy);
		}
	}

	public void OnTriggerExit2D(Collider2D collision)
	{
		if (IsActive && collision.gameObject.CompareTag("Enemy"))
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			_enemies.Remove(enemy);
		}
	}
}

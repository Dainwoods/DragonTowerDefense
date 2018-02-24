using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapdoor : Trap {

	public void OnTriggerEnter2D(Collider2D collision) {
		if (IsActive && collision.gameObject.CompareTag("Enemy"))
		{
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
//			enemy.TakeDamage(enemy.Health);
			enemy.TakeDamage(enemy.Health);
//			Rigidbody2D enemyRigidbody = enemy.GetComponent<Rigidbody2D>();
//			enemyRigidbody.isKinematic = true;
//			enemyRigidbody.velocity = Vector2.down;
		}
	}
}

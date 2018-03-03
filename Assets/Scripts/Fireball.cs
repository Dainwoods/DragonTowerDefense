using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Collided with enemy");
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			enemy.TakeDamage(10000);
			Destroy(gameObject);
		}

		if (collision.gameObject.CompareTag("Floor"))
		{
			Destroy(gameObject);
		}
	}
}

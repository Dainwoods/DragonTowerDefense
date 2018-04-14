using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

	public float Damage = 50;
	public float Radius = 2;
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Collided with enemy");
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			Destroy(gameObject);
			
			
			Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius);
			for (int i = 0; i < collisions.Length; i++)
			{
				if (collisions[i].CompareTag("Enemy"))
				{
                    collisions[i].GetComponent<Enemy>().TakeDamage(Damage);
				}
			}
		}

		if (collision.gameObject.CompareTag("Floor"))
		{
			Destroy(gameObject);
		}
	}
}

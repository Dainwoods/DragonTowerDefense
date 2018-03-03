using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour {
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("Enemy"))
		{
			Debug.Log("Collided with enemy");
			Enemy enemy = collision.gameObject.GetComponent<Enemy>();
			Destroy(gameObject);
			
			
//            var enemyLayer = 1 << LayerMask.NameToLayer("Trap");
			Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, 2);
			for (int i = 0; i < collisions.Length; i++)
			{
				if (collisions[i].CompareTag("Enemy"))
				{
                    collisions[i].GetComponent<Enemy>().TakeDamage(1000);
				}
			}
		}

		if (collision.gameObject.CompareTag("Floor"))
		{
			Destroy(gameObject);
		}
	}
}

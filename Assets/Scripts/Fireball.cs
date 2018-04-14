using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{

	public float Damage = 50;
	public float Radius = 2;
	public bool DidHit = false;
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (!DidHit)
		{
            if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Floor"))
            {
                DidHit = true;
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                Destroy(gameObject);
                
                Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius);
                for (int i = 0; i < collisions.Length; i++)
                {
                    String debug = String.Format("Found a collision with tag {0}", collisions[i].tag);
                    Debug.Log(debug, collisions[i]);
                    if (collisions[i].CompareTag("Enemy"))
                    {
                        Debug.Log("Found enemy");
                        collisions[i].GetComponent<Enemy>().TakeDamage(Damage);
                    }
                }
            }
		}
	}
}

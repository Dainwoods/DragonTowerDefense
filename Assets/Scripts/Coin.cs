using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public void OnTriggerEnter2D(Collider2D collision) {
	    if (collision.gameObject.CompareTag("Enemy"))
	    {
		    var enemy = collision.gameObject.GetComponent<Enemy>();
		    if (!enemy.Retreating)
		    {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Enemy>().ChangeDirection();
		    }
	    }
    }
}

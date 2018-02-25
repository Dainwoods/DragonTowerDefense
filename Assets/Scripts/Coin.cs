using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    
    public void OnTriggerEnter2D(Collider2D collision) {
	    if (collision.gameObject.CompareTag("Enemy"))
	    {
		    Destroy(gameObject);
		    collision.gameObject.GetComponent<Enemy>().ChangeDirection();
	    }
    }
}

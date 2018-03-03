using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtbox : MonoBehaviour {

	// Use this for initialization
	public void Start () {
	}
	
	// Update is called once per frame
	public void Update () {
		
	}
	
	public void OnTriggerEnter2D(Collider2D collision) {
		if (collision.gameObject.CompareTag("DamageableTrap"))
		{
			
			// Don't interact with trap indicators
			if (collision.gameObject.GetComponent<Trap>().IsActive)
			{
                var parentScript = transform.parent.gameObject.GetComponent<Enemy>();
                parentScript.StartAttacking(collision.gameObject);
			}
		}
	}
	
	//called when something exits the trigger
}

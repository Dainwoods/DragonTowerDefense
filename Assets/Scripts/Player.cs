using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity {

	private Rigidbody2D _rigidbody;
	private bool FireballCharge;

	// Use this for initialization
	void Start () {
		base.Start();
		_rigidbody = GetComponent<Rigidbody2D>();
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {


		}
		/*for (int i = 0; i < Input.touchCount; ++i)
		{
			if (Input.GetTouch(i).phase == TouchPhase.Began)
			{
				bool FireballCharge = true;
			}
			//if (FireballCharge == true)
			{

			}
			// Construct a ray from the current touch coordinates
			Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
			// Create a particle if hit
			if (Physics.Raycast(ray))
				//Instantiate(Enemy, transform.position, transform.rotation);
		}*/
	}
}

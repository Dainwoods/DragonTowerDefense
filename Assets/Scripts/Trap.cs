using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Entity
{

	public float Cost;

	// Use this for initialization
	public void Start () {
		base.Start();
		
		// Snap traps to ground.
		float floorHeight = FloorHeight();
		var collider = GetComponent<BoxCollider2D>();
		float bottomHeight = collider.bounds.center.y - collider.bounds.size.y / 2;
		float newY = transform.position.y - bottomHeight + floorHeight;
		
		transform.position = new Vector3(transform.position.x, newY, transform.position.z);
	}

//	private bool _canPlace()
//	{
//		
//	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();
	}

	private float FloorHeight()
	{
		GameObject floor = GameObject.FindGameObjectsWithTag("Floor")[0];
		BoxCollider2D floorCollider = floor.GetComponent<BoxCollider2D>();
		return floorCollider.bounds.center.y + floorCollider.bounds.size.y / 2;
	}
}

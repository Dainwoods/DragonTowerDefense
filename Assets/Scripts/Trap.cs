using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : Entity
{

	public float Cost;
	public bool IsActive = true;
	public List<Sprite> Textures;

	public override float Health
	{
		set
		{
			base.Health = value;
			float bucketSize = MaxHealth / Textures.Count;
			int numBuckets = (int) ((MaxHealth - Health) / bucketSize);
			int index = Mathf.Min(numBuckets, Textures.Count - 1);
			GetComponent<SpriteRenderer>().sprite = Textures[index];

			if (Health <= 0)
			{
				Destroy(gameObject);
			}
		}
	}

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

	public void Deactivate()
	{
		IsActive = false;
	}

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

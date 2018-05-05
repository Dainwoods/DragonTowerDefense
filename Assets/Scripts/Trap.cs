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
	public new void Start () {
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

    public int getGold() {
        float retVal;
        if(base.Health > 2f * MaxHealth / 3f) {
            retVal = (2f * Cost / 3f);
        }
        else if(base.Health > 1f * MaxHealth / 3f) {
            retVal = (Cost / 3f);
        }
        else {
            retVal = 0;
        }
        retVal = Mathf.Floor(retVal);
        return (int)retVal;
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

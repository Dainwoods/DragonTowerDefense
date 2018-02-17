using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

	public float Speed = 5F;

	private Rigidbody2D _rigidbody;

	// Use this for initialization
	public void Start ()
	{
		base.Start();
		_rigidbody = GetComponent<Rigidbody2D>();
		Health = MaxHealth;
	}
	
	// Update is called once per frame
	public void Update ()
	{
		base.Update();
		_rigidbody.velocity = Vector2.right * Speed;
	}
	
	private bool _isBlockedByBarrier()
	{
        return true;
        // Vector2 top_left = new Vector2(transform.position.x - 0.3F, transform.position.y - distToGround);
        // Vector2 bot_right = new Vector2(transform.position.x + 0.3F, transform.position.y - distToGround - 0.3F);
        // return Physics2D.OverlapArea(top_left, bot_right, groundLayers);
	}
}

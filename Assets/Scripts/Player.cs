﻿using System.Collections;
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
		
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Trap {

	// Use this for initialization
	public void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public void Update () {
		base.Update();
	}

	public void Deactivate()
	{
		base.Deactivate();
		GetComponent<BoxCollider2D>().isTrigger = true;
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : Trap {

	public void Deactivate()
	{
		base.Deactivate();
		GetComponent<BoxCollider2D>().isTrigger = true;
	}
}

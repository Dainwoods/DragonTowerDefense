using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAnimationEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, .25f);
	}
}

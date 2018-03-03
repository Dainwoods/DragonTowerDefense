using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballButton : MonoBehaviour
{
	public GameObject RoundHandler;

	// Use this for initialization
	void Start () {
		Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update ()
	{
		RoundHandler roundHandlerScript = RoundHandler.GetComponent<RoundHandler>();
		if (roundHandlerScript.CanFire())
		{
			GetComponent<CanvasGroup>().alpha = 1;
		}
		else
		{
			GetComponent<CanvasGroup>().alpha = 0.5f;
		}
	}

	void OnClick()
	{
		RoundHandler roundHandler = RoundHandler.GetComponent<RoundHandler>();
		roundHandler.IsFiring = !roundHandler.IsFiring;
	}
}

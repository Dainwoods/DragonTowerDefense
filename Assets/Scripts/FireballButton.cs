using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireballButton : MonoBehaviour
{
	public GameObject RoundHandler;
    public Sprite enabledSprite;
    public Sprite disabledSprite;

    private Image imageComponent;

	// Use this for initialization
	void Start () {
        imageComponent = this.GetComponent<Image>();
        Button btn = GetComponent<Button>();
		btn.onClick.AddListener(OnClick);
	}
	
	// Update is called once per frame
	void Update ()
	{
		RoundHandler roundHandlerScript = RoundHandler.GetComponent<RoundHandler>();
		if (roundHandlerScript.CanFire())
		{
            imageComponent.sprite = enabledSprite;
		}
		else
		{
            imageComponent.sprite = disabledSprite;
		}
    }

	void OnClick()
	{
		RoundHandler roundHandler = RoundHandler.GetComponent<RoundHandler>();
		roundHandler.IsFiring = !roundHandler.IsFiring;
	}
}

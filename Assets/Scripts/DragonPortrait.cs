using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonPortrait : MonoBehaviour {

    public Sprite spr1;
    public Sprite spr2;
    public Sprite spr3;

    // Update is called once per frame
    void Update () {
		if(RoundHandler.gold > 67) {
            this.transform.GetComponent<UnityEngine.UI.Image>().sprite = spr1;
        }
        else if(RoundHandler.gold > 33) {
            this.transform.GetComponent<UnityEngine.UI.Image>().sprite = spr2;
        }
        else {
            this.transform.GetComponent<UnityEngine.UI.Image>().sprite = spr3;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHighlight : MonoBehaviour {

    private Color startColor;
    public SpriteRenderer renderer;

    void OnMouseEnter() {
        startColor = renderer.material.color;
        renderer.material.color = Color.red;
    }

    void OnMouseExit() {
        renderer.material.color = startColor;
    }
}

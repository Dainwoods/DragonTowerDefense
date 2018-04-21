using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public GameObject Target;

    public float journeyTime = 1.0f;
    private float startTime;

	public float Damage = 50;
	public float Radius = 2;
	public bool DidHit = false;

    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 midPos;

    private GameObject target;

    public void setTarget(Vector2 a, Vector2 b) {
        startTime = Time.time;
        startPos = a;
        endPos = b;
        midPos = new Vector2((a.x + b.x) / 2, ((a.y + b.y) / 2) + 10);
        target = Instantiate(Target, endPos, transform.rotation);
    }

    private void Update() {
        if(endPos != null) {
            float t = (Time.time - startTime) / journeyTime;
            if(t < 1.0f) {
                transform.position = Bezier(t, startPos, midPos, endPos);
            }
            else {
                blowUp();
            }
        }
    }

    private Vector2 Bezier(float t, Vector2 a, Vector2 b, Vector2 c) {
        Vector2 ab = Vector2.Lerp(a, b, t);
        Vector2 bc = Vector2.Lerp(b, c, t);
        return Vector2.Lerp(ab, bc, t);
    }

    private void blowUp() {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(transform.position, Radius);
        Destroy(target);
        for(int i = 0; i < collisions.Length; i++) {
            if(collisions[i].CompareTag("Enemy")) {
                collisions[i].GetComponent<Enemy>().TakeDamage(Damage);
            }
        }
        Destroy(gameObject);
    }
}

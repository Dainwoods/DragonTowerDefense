using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

	public float Speed = 5F;
	public float Damage = 10F;
	public GameObject Gold;

	private Rigidbody2D _rigidbody;
	private float _nextAttack = 0F;

	private GameObject _target = null;
	public bool Retreating = false;
    public bool HasGold = false;

    private Color startColor;
    private SpriteRenderer renderer;
    public float damageTimer;
    private float timer;
    private bool damageTaken;


    public override float Health
	{
		set
		{
			base.Health = value;
			if (Health <= 0)
			{
				Die();
			}
		}
	}

	public void Die()
	{
		Destroy(gameObject);
		if (Retreating)
		{
            Instantiate(Gold, transform.position, Quaternion.identity);
		}
	}

	// Use this for initialization
	public new void Start ()
	{
		base.Start();
		renderer = GetComponent<SpriteRenderer>();
        damageTaken = false;
        startColor = renderer.material.color;
        _rigidbody = GetComponent<Rigidbody2D>();
		Health = MaxHealth;
	}

	public void ChangeDirection()
	{
		if (!Retreating)
		{
            if (RoundHandler.gold > 0)
            {
                RoundHandler.gold -= 1;
                HasGold = true;
            }
		}
        Retreating = !Retreating;
        Vector3 newScale = transform.localScale;
		if ((Retreating && newScale.x > 0) || (!Retreating && newScale.x < 0))
		{
            newScale.x *= -1;
		}
        transform.localScale = newScale;
    }

	public void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			ChangeDirection();
		}
	}
	
	// Update is called once per frame
	public new void Update ()
	{
		base.Update();


		if (_target != null)
		{
			_tryAttack();
		}
		else
		{
			if (Retreating)
			{
				_rigidbody.velocity = Vector2.left * Speed;
			}
			else
			{
				_rigidbody.velocity = Vector2.right * Speed;
			}
		}
		
		// Escape
		Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
		if (screenPoint.x < -.1 && Retreating)
		{
            HasGold = false;
			ChangeDirection();
		};

        if(damageTaken) {
           timer += Time.deltaTime;
           if(timer > damageTimer) {
               damageTaken = false;
               timer = 0f;
               renderer.material.color = startColor;
           }
       }

    }

    private void _tryAttack()
	{
		if (Time.time > _nextAttack)
		{
            var trapScript = _target.GetComponent<Trap>();
            trapScript.TakeDamage(Damage);
            _nextAttack = Time.time + 1.0F;
		}
	}

	public void StartAttacking(GameObject target)
	{
			_target = target;
	}

    public void TakeDamage(float Damage) {
        base.TakeDamage(Damage);
        renderer.material.color = Color.red;
        damageTaken = true;
    }
}

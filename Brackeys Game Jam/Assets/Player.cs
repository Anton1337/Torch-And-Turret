using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed;
    public int damage;

    [HideInInspector]
    public Vector2 moveInput;

    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private PlayerAnimation anim;

    public float startTimeBtwAttack;
    private float timeBtwAttack = 0;

    public float lightRange;

    public float attackRange;
    public Transform attackPos;
    public LayerMask whatIsEnemy;


    private void Start()
    {
        Bullet.damage = 1;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<PlayerAnimation>();
    }

    private void Update()
    {

        MoveInput();
        Flip();

        if(timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Attack();
                timeBtwAttack = startTimeBtwAttack;
            }
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    private void Attack()
    {
        FindObjectOfType<AudioManager>().Play("SwordSwing");
        anim.Attack();

        Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(
            attackPos.position, attackRange, whatIsEnemy);

        foreach (var enemy in enemiesToDamage)
        {
            enemy.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void MoveInput()
    {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();
    }

    private void Move()
    {
        moveInput *= speed * Time.fixedDeltaTime * 100;
        rb.velocity = moveInput;
    }

    private void Flip()
    {
        if(moveInput.x < 0)
        {
            sprite.flipX = true;
        }
        else if(moveInput.x > 0)
        {
            sprite.flipX = false;
        }
    }
}

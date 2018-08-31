using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour {

    public float speed;
    public float health;
    public int damage;
    public int goldDropAmount;

    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }

    public abstract void Attack();

    protected virtual void Update()
    {
        Move();
    }

    protected virtual void Move()
    {
        transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
    }

    public virtual void Dequeue()
    {
        EnemySpawner.enemies.Remove(this.gameObject);
    }

    protected virtual void OnDestroy()
    {
        Dequeue();
    }

    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Dequeue();
            Shop.goldAmount += goldDropAmount;
            //spawn particles
            Destroy(gameObject);
        }
    }

}

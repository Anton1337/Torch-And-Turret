using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinRaider : Enemy {

    public float timeBtwAttack = 1.0f;
    private float actualTimeBtwAttack = 0f;

    public override void Attack()
    {
        FindObjectOfType<AudioManager>().Play("CastleHit");
        anim.SetTrigger("Attack");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Castle"))
        {
            speed = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Castle"))
        {
            if (actualTimeBtwAttack <= 0)
            {
                Attack();
                Debug.Log("Deal Damage!");
                other.GetComponent<Castle>().TakeDamage(damage);
                actualTimeBtwAttack = timeBtwAttack;
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinBomber : Enemy
{
    public override void Attack()
    {
        speed = 0;
        anim.SetTrigger("Expload");
        FindObjectOfType<AudioManager>().Play("CastleHit");
        Dequeue();
        StartCoroutine(AttackWait());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Castle"))
        {
            Attack();
            other.GetComponent<Castle>().TakeDamage(damage);
        }
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }

}

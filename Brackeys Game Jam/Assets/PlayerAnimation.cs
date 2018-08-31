using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    private Animator anim;
    private Player player;

    private void Start()
    {
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Run();
    }

    private void Run()
    {
        if(Mathf.Abs(player.moveInput.x) > 0 || Mathf.Abs(player.moveInput.y) > 0)
        {
            anim.SetFloat("Speed", 1);
        }
        else
        {
            anim.SetFloat("Speed", 0);
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Castle : MonoBehaviour {

    public int health;
    public int maxHealth;
    private int absoluteMaxHealth;

    public Image[] healthBar;

    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite goldHeart;

    public GameObject gameOverUI;

    private bool doGameoverStuff = true;

    private void Start()
    {
        absoluteMaxHealth = healthBar.Length;
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        for (int i = 0; i < healthBar.Length; i++)
        {
            if(i < health)
            {
                healthBar[i].sprite = fullHeart;
            }
            else
            {
                if(i == healthBar.Length -1)
                {
                    if(healthBar[i].sprite != goldHeart)
                    {
                        healthBar[i].sprite = emptyHeart;
                    }
                }
                else
                {
                    if (healthBar[i].sprite == goldHeart && i < maxHealth)
                    {
                        healthBar[i + 1].sprite = goldHeart;
                        healthBar[i].sprite = emptyHeart;
                    }
                    if(healthBar[i].sprite != goldHeart)
                    {
                        healthBar[i].sprite = emptyHeart;
                    }
                }
            }

            if(i < maxHealth)
            {
                healthBar[i].enabled = true;
            }
            else
            {
                if(healthBar[i].sprite != goldHeart)
                {
                    healthBar[i].enabled = false;
                }
                else
                {
                    healthBar[i].enabled = true;
                }
            }
        }
    }

    public void PickupGoldHeart()
    {
        if(maxHealth < absoluteMaxHealth)
        {
            Debug.Log("gold heart spawned");
            healthBar[maxHealth].enabled = true;
            healthBar[maxHealth].sprite = goldHeart;
        }
        if(maxHealth == absoluteMaxHealth && health < absoluteMaxHealth)
        {
            health++;
        }
        UpdateHealthBar();
    }

    public void PickupHeart()
    {
        if(health < maxHealth)
        {
            health += 1;
        }
        UpdateHealthBar();
    }

    public void TakeDamage(int damage)
    {
        if(maxHealth != absoluteMaxHealth)
        {
            if (healthBar[maxHealth].sprite == goldHeart && damage > 0)
            {
                healthBar[maxHealth].enabled = false;
                healthBar[maxHealth].sprite = fullHeart;
                damage -= 1;
            }
        }

        health -= damage;
        UpdateHealthBar();

        if (health <= 0)
        {
            if(doGameoverStuff)
            {
                gameOverUI.SetActive(true);
                GetComponent<AudioSource>().Play();

                FindObjectOfType<AudioManager>().Mute();

                doGameoverStuff = false;
            }

        }
    }
}

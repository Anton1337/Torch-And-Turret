using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {

    private float distanceToEnemy;
    private float ClosestDistanceToEnemy;
    private float distanceDefault = 999999;
    private float lightDistance;
    private float lightDistanceOffset = 0.5f;

    public float rotateOffset;

    private GameObject enemyToShoot;

    public GameObject bullet;

    public Transform shootPos;

    private float timeBtwShots = 0;
    public float startTimeBtwShots;

    public Transform playerTrans;
    public Player player;

    private void Update()
    {
        if(timeBtwShots <= 0)
        {
            if(EnemySpawner.enemies.Count > 0)
            {
                LookForEnemy();
            }

        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

    }

    private void LookForEnemy()
    {
        ClosestDistanceToEnemy = distanceDefault;
        foreach (var enemy in EnemySpawner.enemies)
        {
            distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            lightDistance = Vector2.Distance(playerTrans.position, enemy.transform.position);

            if ( distanceToEnemy < ClosestDistanceToEnemy &&
                lightDistance < player.lightRange - lightDistanceOffset)
            {
                ClosestDistanceToEnemy = distanceToEnemy;
                enemyToShoot = enemy;
            }
        }

        if(ClosestDistanceToEnemy != distanceDefault)
        {
            ShootEnemy();
        }
        else
        {
            return;
        }
    }

    private void ShootEnemy()
    {
        Rotate();
        Shoot();
        //Reset shot timer.
        timeBtwShots = startTimeBtwShots;
    }

    private void Shoot()
    {
        FindObjectOfType<AudioManager>().Play("TurretShot");
        Instantiate(bullet, shootPos.position, transform.rotation);
    }

    private void Rotate()
    {
        Vector3 difference = enemyToShoot.transform.position - transform.position;

        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ + rotateOffset);
    }
}

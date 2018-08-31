using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public Transform spawnRangeTop;
    public Transform spawnRangeBot;

    public GameObject[] enemy;
    [HideInInspector]
    public static List<GameObject> enemies;

    private float timeBtwSpawn;
    public float startTimeBtwSpawn;

    public int startNumberOfEnemies;
    [HideInInspector]
    public int numOfEnemies;

    public static int waveNumber = 1;

    public float startWaveCountdown;
    private float waveCountdown;

    public GameObject shopUI;

    public static bool nextWave = false;
    public static bool showText = false;

    private float showShopTimer = 3.0f;
    private float startShowShopTimer = 3.0f;

    public GoblinBomber bomberEnemy;
    public GoblinRaider raiderEnemy;

    private

	void Start ()
    {
        nextWave = false;
        showText = false;
        waveNumber = 1;
        enemies = new List<GameObject>();
        timeBtwSpawn = startTimeBtwSpawn;
        numOfEnemies = startNumberOfEnemies;
        waveCountdown = startWaveCountdown;
	}
	
	void Update ()
    {
        if (numOfEnemies > 0)
        {
            SpawnEnemies();
        }
        else
        {
            if(enemies.Count <= 0)
            {
                if(!nextWave)
                {
                    showText = true;
                    if(showShopTimer <= 0)
                    {
                        shopUI.SetActive(true);
                        showText = false;
                    }
                    else
                    {
                        showShopTimer -= Time.deltaTime;
                    }
                }

                if(nextWave)
                {
                    if (waveCountdown <= 0)
                    {
                        NewWave();
                        waveCountdown = startWaveCountdown;
                    }
                    else
                    {
                        waveCountdown -= Time.deltaTime;
                    }
                }
            }
        } 
    }

    private void NewWave()
    {
        nextWave = false;
        waveNumber += 1;

        startNumberOfEnemies += 5;
        numOfEnemies = startNumberOfEnemies;

        startTimeBtwSpawn -= 0.20f;
        if(startTimeBtwSpawn <= 0.4f)
        {
            startTimeBtwSpawn = 0.4f;
            int rand = UnityEngine.Random.Range(0, 3);

            if(rand == 1)
            {
                bomberEnemy.health += 1;
            }
            else if(rand == 2)
            {
                raiderEnemy.health += 1;
            }
        }
    }

    private void SpawnEnemies()
    {
        if(timeBtwSpawn <= 0)
        {
            SpawnEnemy();
            numOfEnemies--;
            timeBtwSpawn = startTimeBtwSpawn;
        }
        else
        {
            timeBtwSpawn -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        float yPos = UnityEngine.Random.Range(spawnRangeBot.position.y, spawnRangeTop.position.y);
        Debug.Log(yPos);

        Vector3 spawnPos = new Vector3(spawnRangeBot.position.x, yPos, spawnRangeBot.position.z);

        GameObject currentEnemy = Instantiate(enemy[UnityEngine.Random.Range(0,2)], spawnPos, Quaternion.identity);
        enemies.Add(currentEnemy);
    }

    public void startNextWave()
    {
        shopUI.SetActive(false);
        nextWave = true;
        showShopTimer = startShowShopTimer;
    }
}

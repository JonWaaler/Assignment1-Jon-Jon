using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class EnemySpawner : MonoBehaviour {

    // Dll import & set-up
    const string DLL_NAME = "Assignment1_DLL";

    [DllImport(DLL_NAME)]
    private static extern float random();
    [DllImport(DLL_NAME)]
    private static extern float randomRange(int x, int y);



    public GameObject Enemy;
    public float RateOfSpawn = .5f;
    private float t_RateOfSpawn = 0;
    public List<Transform> SpawnPositions;
    private const int ENEMY_POOL_SIZE = 500;
    public List<GameObject> enemys;

    public enum SpawnMethod { random, roundRobin};
    public SpawnMethod spawnMethod;
    private int robinNum = 0;
    private void Start()
    {
        for (int i = 0; i < ENEMY_POOL_SIZE; i++)
        {
            GameObject enemyInstance = Instantiate(Enemy);
            enemyInstance.transform.position = transform.position;
            enemys.Add(enemyInstance);
            enemyInstance.SetActive(false);
            enemyInstance.GetComponent<MeshRenderer>().material.color = new Color(randomRange(0, 255) / 255.0f, randomRange(0, 255) / 255.0f, randomRange(0, 255) / 255.0f, 1);

        }
        print("SpawnPositionCount: " + SpawnPositions.Count);

    }
    void Update () {
        // Upate Timer
        t_RateOfSpawn += Time.deltaTime;

        // If allowed to spawn, proceed
		if(t_RateOfSpawn > RateOfSpawn)
        {
            // Search enemies
            for (int i = 0; i < enemys.Count; i++)
            {
                // If an enemy is inactive set active and to a position                
                if (!enemys[i].activeInHierarchy)
                {
                    // Make said enemy visible (basically spawn it)
                    enemys[i].SetActive(true);
                    if(spawnMethod == SpawnMethod.random)
                    {
                        int randSpawnNum = Random.Range(0, SpawnPositions.Count);
                        print("RandSpawnNumber: " + randSpawnNum);
                        enemys[i].transform.position = SpawnPositions[randSpawnNum].transform.position;
                        return;
                    }
                    else
                    {
                        // ROUND ROBIN
                        // Resets the robin loop, and mak
                        if (robinNum >= SpawnPositions.Count)
                            robinNum = 0;
                        
                        enemys[i].transform.position = SpawnPositions[robinNum].transform.position;
                        robinNum++;
                        return;
                    }

                }
            }

            // Reset timer
            t_RateOfSpawn = 0;
        }
	}
}

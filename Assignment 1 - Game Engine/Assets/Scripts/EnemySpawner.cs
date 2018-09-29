﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject Enemy;
    private float t_RateOfSpawn = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t_RateOfSpawn += Time.deltaTime;

		if(t_RateOfSpawn > .5f)
        {
            GameObject enemyInstance = Instantiate(Enemy);
            enemyInstance.transform.position = transform.position;
            t_RateOfSpawn = 0;
        }
	}
}
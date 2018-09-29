using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyweight_Spawner : MonoBehaviour {

    public GameObject myEnemyPrefab;
    public Mesh myMesh;
    public enum SpawnMethod
    {
        FlyWeight,
        Regular
    };
    public SpawnMethod spawnMethod;

	// Use this for initialization
	void Start () {
        
        

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.I) && spawnMethod == SpawnMethod.FlyWeight)
        {
            for (int i = 0; i < 10000; i++)
            {
                GameObject enemyInstance = Instantiate<GameObject>(myEnemyPrefab);
                enemyInstance.AddComponent<MeshFilter>();
                enemyInstance.GetComponent<MeshFilter>().mesh = myMesh;
            }
        }
	}
}

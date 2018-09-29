using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHardMode : MonoBehaviour {

    public List<GameObject> spawners;
    public Score scoreManager;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (scoreManager.t_score > 15)
        {
            foreach (var l in spawners)
            {
                l.SetActive(true);
            }

        }
	}
}

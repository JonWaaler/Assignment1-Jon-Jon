using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player Parent");
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.transform.Translate(-(transform.position - Player.transform.position).normalized * Time.deltaTime * 5f);
	}

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other);
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Player);
    }
}

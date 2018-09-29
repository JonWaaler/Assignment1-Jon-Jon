using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    public GameObject Player;

    //public Mesh myEnemy;

	// Use this for initialization
	void Start () {
        Player = GameObject.Find("Player Parent");
	}
	
	// Update is called once per frame
	void Update () {
        if(Player != null)
        gameObject.transform.Translate(-(transform.position - Player.transform.position).normalized * Time.deltaTime * 5f);


        //GameObject myObj = Instantiate<GameObject>(basicGameobject);
        //myObj.AddComponent<MeshFilter>();
        //
        //myObj.AddComponent<MeshRenderer>();
        //
        //myObj.GetComponent<MeshFilter>().mesh = myEnemy;

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


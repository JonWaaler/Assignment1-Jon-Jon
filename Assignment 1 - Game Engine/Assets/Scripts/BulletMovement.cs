using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-Vector3.forward * Time.deltaTime * 30);
	}

    private void OnCollisionEnter(Collision collision)
    {
        //if(collision.gameObject.tag == "Enemy")
            Destroy(gameObject);

    }
}

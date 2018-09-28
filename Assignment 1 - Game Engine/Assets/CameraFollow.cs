using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject player;

	void Start () {
	}
	
	void Update () {
        if(player != null)
        transform.position = player.transform.position + new Vector3(0, 20f, -3);
	}
}

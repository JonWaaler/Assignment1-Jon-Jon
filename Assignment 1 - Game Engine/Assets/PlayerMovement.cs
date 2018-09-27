using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public KeyBindingScriptableObj playerKeybinds;
    public float Speed = 15;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        // Movement
        float x = 0;
        float z = 0;
                
        if (Input.GetKey(playerKeybinds.forward))
        {
            z = 1;
        }
        if (Input.GetKey(playerKeybinds.backwards))
        {
            z = -1;
        }
        if (Input.GetKey(playerKeybinds.left))
        {
            x = -1;

        }
        if (Input.GetKey(playerKeybinds.right))
        {
            x = 1;
        }

        gameObject.transform.Translate(new Vector3(x, 0, z) * Time.deltaTime * Speed);

        if (x == 0 && z == 0)
            x = 1;
        // Look
        transform.GetChild(0).rotation = Quaternion.LookRotation(new Vector3(-x,0,-z));

    }

}

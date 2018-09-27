using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehaviour : MonoBehaviour {

    public GameObject bulletPrefab;
    private float t_shootStart = 0;
    public KeyBindingScriptableObj playerKeybinds;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t_shootStart += Time.deltaTime;

        if ((Input.GetKey(playerKeybinds.fire))&&(t_shootStart > 0.2f))
        {
            GameObject myBulletInstance = Instantiate(bulletPrefab);
            myBulletInstance.transform.position = transform.GetChild(0).position;
            myBulletInstance.transform.rotation = transform.parent.rotation;
            t_shootStart = 0;
        }
	}
}

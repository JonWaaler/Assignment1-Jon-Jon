using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour {

    public GameObject settings_canvas;
    public Text fw, bw, l, r, fire;
    public KeyBindingScriptableObj keybinds;
    public bool checkNull = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (checkNull)
        {


        }	
	}

    public void ToggleSettings()
    {
        settings_canvas.SetActive(!settings_canvas.activeInHierarchy);

        if(Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

    }


    public void rebind_FW()
    {
        checkNull = true;
        fw.text = "Press Button";
        //fw.text = Event.current.keyCode.ToString();
        //keybinds.forward = Event.current.keyCode;
    }
    public void rebind_BW()
    {
        checkNull = true;
        bw.text = "Press Button";
        //bw.text = Event.current.keyCode.ToString();
        //keybinds.backwards = Event.current.keyCode;
    }
    public void rebind_L()
    {
        checkNull = true;
        l.text = "Press Button";
        //l.text = Event.current.keyCode.ToString();
        //keybinds.left = Event.current.keyCode;
    }
    public void rebind_R()
    {
        checkNull = true;
        r.text = "Press Button";
        //r.text = Event.current.keyCode.ToString();
        //keybinds.right = Event.current.keyCode;
    }
    public void rebind_Fire()
    {
        checkNull = true;
        fire.text = "Press Button";
        //fire.text = Event.current.keyCode.ToString();
        //keybinds.fire = Event.current.keyCode;
    }
}

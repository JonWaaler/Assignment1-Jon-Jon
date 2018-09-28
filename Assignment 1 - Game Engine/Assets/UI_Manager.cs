using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CommandPattern;

public class UI_Manager : MonoBehaviour {

    public GameObject settings_canvas;
    public Text fw, bw, l, r, fire;
    public KeyBindingScriptableObj keybinds;
    public bool checkNull = false;

    // Design pattern stuff
    public GetKey_Forward cmd_forward = new GetKey_Forward();
    public GetKey_Backward cmd_backward = new GetKey_Backward();
    public GetKey_Right cmd_right = new GetKey_Right();
    public GetKey_Left cmd_left = new GetKey_Left();
    public GetKey_Fire cmd_fire = new GetKey_Fire();

    //public static List<Command> oldCommands = new List<Command>();
    private KeyCode tempKeycode;

    public Stack<KeyCode> oldKeycodes_forward;
    public Stack<KeyCode> oldKeycodes_backward;
    public Stack<KeyCode> oldKeycodes_right;
    public Stack<KeyCode> oldKeycodes_left;
    public Stack<KeyCode> oldKeycodes_fire;
    private void OnGUI()
    {
        Event e = Event.current;
        if (e.isKey)
        {
            print("Key Code: " + e.keyCode);
            tempKeycode = e.keyCode;
        }

        fw.text = keybinds.forward.ToString();
        bw.text = keybinds.backwards.ToString();
        r.text = keybinds.right.ToString();
        l.text = keybinds.left.ToString();
        fire.text = keybinds.fire.ToString();
    }
    private void Start()
    {
        oldKeycodes_forward = new Stack<KeyCode>();
        oldKeycodes_backward = new Stack<KeyCode>();
        oldKeycodes_right = new Stack<KeyCode>();
        oldKeycodes_left = new Stack<KeyCode>();
        oldKeycodes_fire = new Stack<KeyCode>();
    }

    void Update () {

        /* Basically, the objects execute a function that checks if a key == keycode.nono
         * it then detects a key pressed
         * 
         * 
         */
        cmd_forward.Execute(fw, cmd_forward, keybinds, tempKeycode, checkNull);
        cmd_backward.Execute(bw, cmd_backward, keybinds, tempKeycode, checkNull);
        cmd_right.Execute(r, cmd_right, keybinds, tempKeycode, checkNull);
        cmd_left.Execute(l, cmd_left, keybinds, tempKeycode, checkNull);
        cmd_fire.Execute(fire, cmd_fire, keybinds, tempKeycode, checkNull);

        tempKeycode = KeyCode.None;
        
	}

    public void ToggleSettings()
    {
        settings_canvas.SetActive(!settings_canvas.activeInHierarchy);

        if(Time.timeScale == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = 0;

    }


    // All the bellow functions are for setting up around to make the execute function
    // work properly for rebinding keys
    public void rebind_Fore()
    {
        oldKeycodes_forward.Push(keybinds.forward);
        checkNull = true;
        fw.text = "Press Button";
        keybinds.forward = KeyCode.None;
    }
    public void rebind_Back()
    {
        oldKeycodes_backward.Push(keybinds.backwards);
        checkNull = true;
        bw.text = "Press Button";
        keybinds.backwards = KeyCode.None;
    }
    public void rebind_Left()
    {
        oldKeycodes_left.Push(keybinds.left);
        checkNull = true;
        l.text = "Press Button";
        keybinds.left = KeyCode.None;
    }
    public void rebind_Right()
    {
        oldKeycodes_right.Push(keybinds.right);
        checkNull = true;
        r.text = "Press Button";
        keybinds.right = KeyCode.None;
    }
    public void rebind_Fire()
    {
        oldKeycodes_fire.Push(keybinds.fire);
        checkNull = true;
        fire.text = "Press Button";
        keybinds.fire = KeyCode.None;
    }



    public void undo_Fore()
    {
        cmd_forward.UndoBind(oldKeycodes_forward, keybinds, fw);
    }
    public void undo_Back()
    {
        cmd_backward.UndoBind(oldKeycodes_backward, keybinds, bw);
    }
    public void undo_Right()
    {
        cmd_right.UndoBind(oldKeycodes_right, keybinds, r);
    }
    public void undo_Left()
    {
        cmd_left.UndoBind(oldKeycodes_left, keybinds, l);
    }
    public void undo_Fire()
    {
        cmd_fire.UndoBind(oldKeycodes_fire, keybinds, fire);
    }
}

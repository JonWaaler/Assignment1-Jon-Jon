using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "KeyBinds", menuName = "", order = 1)]
public class KeyBindingScriptableObj : ScriptableObject {

    public KeyCode forward;
    public KeyCode backwards;
    public KeyCode left;
    public KeyCode right;
    public KeyCode fire;

}

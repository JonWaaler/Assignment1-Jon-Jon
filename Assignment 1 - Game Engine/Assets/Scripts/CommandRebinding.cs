using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CommandPattern
{

    // Base Command class
    public abstract class Command
    {
        public abstract void Execute(Text txt, Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check);
        public abstract void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt);
    }

    // Sub override classes
    public class GetKey_Forward : Command
    {
        public override void Execute(Text txt, Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check)
        {
            if (binds.forward == KeyCode.None && check)
            {
                txt.text = temp.ToString();
                binds.forward = temp;
                check = false;
            }
        }

        public override void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt)
        {
            if(oldKeys.Count >0)
            {
                Debug.Log("Undoing Key bind");              // Adds to log 
                txt.text = oldKeys.Peek().ToString();       // Peek at top of stack
                keybinds.forward = oldKeys.Pop();           // Pop stack and used for key binding
            }
        }

    }
    public class GetKey_Backward : Command
    {
        public override void Execute(Text txt , Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check)
        {
            if (binds.backwards == KeyCode.None && check)
            {
                txt.text = temp.ToString();
                binds.backwards = temp;
                check = false;
            }
        }

        public override void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt)
        {
            if (oldKeys.Count > 0)
            {
                Debug.Log("Undoing Key bind");
                txt.text = oldKeys.Peek().ToString();
                keybinds.backwards = oldKeys.Pop();
            }
        }
    }
    public class GetKey_Right : Command
    {
        public override void Execute(Text txt , Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check)
        {
            if (binds.right == KeyCode.None && check)
            {
                txt.text = temp.ToString();
                binds.right = temp;
                check = false;
            }
        }

        public override void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt)
        {
            if (oldKeys.Count > 0)
            {
                Debug.Log("Undoing Key bind");
                txt.text = oldKeys.Peek().ToString();
                keybinds.right = oldKeys.Pop();
            }
        }
    }
    public class GetKey_Left : Command
    {
        public override void Execute(Text txt, Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check)
        {
            if (binds.left == KeyCode.None && check)
            {
                txt.text = temp.ToString();
                binds.left = temp;
                check = false;
            }
        }

        public override void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt)
        {
            if (oldKeys.Count > 0)
            {
                Debug.Log("Undoing Key bind");
                txt.text = oldKeys.Peek().ToString();
                keybinds.left = oldKeys.Pop();
            }
        }
    }
    public class GetKey_Fire : Command
    {
        public override void Execute(Text txt, Command command, KeyBindingScriptableObj binds, KeyCode temp, bool check)
        {
            if (binds.fire == KeyCode.None && check)
            {
                txt.text = temp.ToString();
                binds.fire = temp;
                check = false;
            }
        }

        public override void UndoBind(Stack<KeyCode> oldKeys, KeyBindingScriptableObj keybinds, Text txt)
        {
            if (oldKeys.Count > 0)
            {
                Debug.Log("Undoing Key bind");
                txt.text = oldKeys.Peek().ToString();
                keybinds.fire = oldKeys.Pop();
            }
        }
    }
}

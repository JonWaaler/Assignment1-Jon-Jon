using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public abstract void Execute();
}

namespace CommandPattern
{
    public class InputHandler : MonoBehaviour
    {

        private Command buttonW, buttonS, buttonA, buttonD, buttonSpace;
        public static List<Command> oldCommands = new List<Command>();
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
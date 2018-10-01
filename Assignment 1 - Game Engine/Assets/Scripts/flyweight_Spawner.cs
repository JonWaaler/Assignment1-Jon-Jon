using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyweight_Spawner : MonoBehaviour
{
    public Material flyweight_mat;
    public Material regular_mat;

    // flyweight texture thats going other objects are going to "point" to
    private Texture2D flyWeightTex;

    // FOr switching spawning methods
    public enum InstancingMode { flyweight, regular};
    public InstancingMode instancingMode;

    private void Start()
    {
        // Were creating the texture once. This is now in memory
        flyWeightTex = new Texture2D(1024, 1024);
    }

    public void Update()
    { 
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(instancingMode == InstancingMode.flyweight)
            {
                for (int i = 0; i < 1000; i++)
                {
                    // Create a new empty gameobject
                    GameObject instance = new GameObject("flyweight GM");
                                     
                    // here we set the material and mainTexture for the material to a already set variable above
                    // These vars "flyweight_component" are already in memory so why we put the same data multiple times mem
                    // when we can just access it
                    instance.AddComponent<MeshRenderer>().material = flyweight_mat;
                    instance.GetComponent<MeshRenderer>().material.mainTexture = flyWeightTex; // Using pre-made texture
                }
            }
            if (instancingMode == InstancingMode.regular)
            {
                for (int i = 0; i < 1000; i++)
                {
                    // Create a new empty gameobject
                    GameObject instance = new GameObject("non-flyweight GM");
                                    
                    // here we use the "new" keyword to create a new instance a texture in memory to test 
                    // how much more memory non-flyweight uses
                    instance.AddComponent<MeshRenderer>().material = new Material(regular_mat);
                    instance.GetComponent<MeshRenderer>().material.mainTexture = new Texture2D(1024,1024);


                    /*  For 1000 objects
                     *  Flyweight used about 300 MB of total memory
                     * 
                     *  Regular used about 10 GB of total memory
                     */
                }
            }
        }
    }
}

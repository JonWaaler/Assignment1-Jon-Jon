using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flyweight_Spawner : MonoBehaviour
{
    public GameObject flyweightInstance;

    public Material flyweight_mat;
    public Material regular_mat;

    private Texture2D flyWeightTex;

    public enum InstancingMode { flyweight, regular};
    public InstancingMode instancingMode;

    private void Start()
    {
        flyWeightTex = new Texture2D(1024, 1024);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(instancingMode == InstancingMode.flyweight)
            {
                for (int i = 0; i < 750; i++)
                {
                    // Create a new empty gameobject
                    GameObject instance = new GameObject("flyweight GM");
                                     
                    // here we set the material and mainTexture for the material to a already set variable above
                    // These vars "flyweight_component" are already in memory so why we put the same data multiple times mem
                    // when we can just access it
                    instance.AddComponent<MeshRenderer>().material = flyweight_mat;
                    instance.GetComponent<MeshRenderer>().material.mainTexture = flyWeightTex;

                }
            }
            if (instancingMode == InstancingMode.regular)
            {
                for (int i = 0; i < 750; i++)
                {
                    // Create a new empty gameobject
                    GameObject instance = new GameObject("non-flyweight GM");
                                    
                    // here we use the "new" keyword to create a new instance of that in memory to test 
                    // how much more memory non-flyweight uses
                    instance.AddComponent<MeshRenderer>().material = new Material(regular_mat);
                    instance.GetComponent<MeshRenderer>().material.mainTexture = new Texture2D(1024,1024);
                }
            }
        }
    }
}

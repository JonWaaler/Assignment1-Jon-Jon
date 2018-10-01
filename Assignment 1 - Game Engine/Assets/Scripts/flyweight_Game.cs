using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public class flyweight_Game : MonoBehaviour
{
    // Dll import & set-up
    const string DLL_NAME = "Assignment1_DLL";
    
    [DllImport(DLL_NAME)]
    private static extern float random();
    [DllImport(DLL_NAME)]
    private static extern float randomRange(int x, int y);


    // Flyweight set-up
    public Material mat;
    public GameObject player;
    private Texture2D flyweightTex;
    private float t_RateOfSpawn = 0;

    public enum InstancingMode { flyweight,regular};
    public InstancingMode instMode;

    private void Start()
    {
        flyweightTex = new Texture2D(1024, 1024);
    }

    void Update()
    {
        t_RateOfSpawn += Time.deltaTime;

        if (t_RateOfSpawn > .02f)
        {
            GameObject inst;
            if(instMode == InstancingMode.regular)
                inst = SpawnEnemy_Regular();
            else
                inst = SpawnEnemy_Flyweight();


            inst.transform.position = transform.position;
            t_RateOfSpawn = 0;
        }
    }

    // Function that spawns an empty GO and sets it up
    GameObject SpawnEnemy_Regular()
    {
        GameObject inst = GameObject.CreatePrimitive(PrimitiveType.Cube);
        inst.AddComponent<MeshFilter>();
        inst.AddComponent<MeshRenderer>();
        inst.GetComponent<MeshRenderer>().material = new Material(mat);
        inst.GetComponent<MeshRenderer>().material.mainTexture = new Texture2D(1024,1024);
        inst.AddComponent<EnemyAI>();
        inst.GetComponent<EnemyAI>().Player = player;
        inst.AddComponent<BoxCollider>();
        inst.AddComponent<CollisionDetectiong>();
        inst.transform.localScale.Set(2, 4, 2);
        
        return inst;
    }

    GameObject SpawnEnemy_Flyweight()
    {
        GameObject inst = GameObject.CreatePrimitive(PrimitiveType.Cube);
        inst.AddComponent<MeshFilter>();
        inst.AddComponent<MeshRenderer>();
        inst.GetComponent<MeshRenderer>().material = mat;
        inst.GetComponent<MeshRenderer>().material.mainTexture = flyweightTex;
        inst.AddComponent<EnemyAI>();
        inst.AddComponent<BoxCollider>();
        inst.AddComponent<CollisionDetectiong>();
        inst.transform.localScale.Set(2, 4, 2);

        // DLL usage
        inst.GetComponent<MeshRenderer>().material.color = new Color(randomRange(0, 255) / 255.0f, randomRange(0, 255) / 255.0f, randomRange(0, 255) / 255.0f, 1);

        return inst;
    }
}


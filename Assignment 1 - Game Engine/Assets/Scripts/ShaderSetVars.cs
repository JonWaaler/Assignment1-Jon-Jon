using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaderSetVars : MonoBehaviour
{

    public Material mat;
    //public float offset = 10f;
    public AnimationCurve t;
    private float t_EffectTimer = 0;

    // Update is called once per frame
    void Update()
    {
        t_EffectTimer += Time.deltaTime * 2.0f;
        //if (offset > 0)

        mat.SetFloat("_offset", t.Evaluate(t_EffectTimer)/500.0f);
        //print("<color=red>Eval: " + t.Evaluate(Time.time));

        if (t_EffectTimer >= 1)
        {
            mat.SetFloat("_offset", 0.001f);
        }

        if (Input.GetKeyDown(KeyCode.Space)) { t_EffectTimer = 0; } ;

    }
}
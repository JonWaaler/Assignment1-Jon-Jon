using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public GameObject player;
    public Text score;
    public Button restartButton;
    //[HideInInspector]
    public float t_score = 0;
    public List<GameObject> spawners;

	// Use this for initialization
	void Start () {
        t_score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        t_score += Time.deltaTime;

        if (player != null)
            score.text = t_score.ToString();
        else
            restartButton.gameObject.SetActive(true);


        
	}

    public void Restart()
    {
        SceneManager.LoadScene(0);
        score.text = 0.ToString();
        t_score = 0;
        foreach (var spawn in spawners)
        {
            spawn.SetActive(false);
        }
    }

}

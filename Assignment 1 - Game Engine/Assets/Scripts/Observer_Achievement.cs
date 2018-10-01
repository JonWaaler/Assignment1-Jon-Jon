using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    public class Observer_Achievement : MonoBehaviour
    {
        public Text score;

        // So the achievement is only popped up once
        private bool hasAchievement1 = false;
        private bool hasAchievement2 = false;
        private bool hasAchievement3 = false;

        // UI panels that i want to enable when score reaches
        // certain levels
        public GameObject Achievement_Panel1;
        public GameObject Achievement_Panel2;
        public GameObject Achievement_Panel3;

        // I need more than 1 subject becuase i need to notify the object
        // at differnce values of score
        Subject subject1 = new Subject();
        Subject subject2 = new Subject();
        Subject subject3 = new Subject();

        // Use this for initialization
        void Start()
        {
            Achievement_Panel1 = GameObject.Find("Canvas_Settings").transform.GetChild(2).gameObject;
            Achievement_Panel2 = GameObject.Find("Canvas_Settings").transform.GetChild(3).gameObject;
            Achievement_Panel3 = GameObject.Find("Canvas_Settings").transform.GetChild(4).gameObject;

            Score score1 = new Score(score, Achievement_Panel1);
            Score score2 = new Score(score, Achievement_Panel2);
            Score score3 = new Score(score, Achievement_Panel3);

            subject1.AddObserver(score1);
            subject2.AddObserver(score2);
            subject3.AddObserver(score3);
            //we can have all scores for 1 subject, however this will activate them all at the same time if one of them is reached
        }

        // Update is called once per frame
        void Update()
        {
            // Set first achievement panel active etc...
            if (float.Parse(score.text) > 5)
            {
                if (!hasAchievement1)
                {
                    subject1.Notify();
                    hasAchievement1 = true;
                }
                if (float.Parse(score.text) > 6.5f)
                    Achievement_Panel1.SetActive(false);

            }
            
            if (float.Parse(score.text) > 10)
            {
                if (!hasAchievement2)
                {
                    subject2.Notify();
                    hasAchievement2 = true;

                }
                if (float.Parse(score.text) > 11.5f)
                    Achievement_Panel2.SetActive(false);
            }

            if (float.Parse(score.text) > 15)
            {
                if (!hasAchievement3)
                {
                    subject3.Notify();
                    hasAchievement3 = true;
                }
                if (float.Parse(score.text) > 16.5f)
                    Achievement_Panel3.SetActive(false);
            }
        }
    }
}



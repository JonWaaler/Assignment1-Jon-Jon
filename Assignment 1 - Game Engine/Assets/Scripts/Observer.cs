using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace ObserverPattern
{
    public abstract class Observer
    {
        public abstract void OnNotify();
    }

    public class Score : Observer
    {
        Text score;
        GameObject AchievementPanel;
        public Score(Text score, GameObject AchievementPanel)
        {
            this.score = score;
            this.AchievementPanel = AchievementPanel;
        }

        public override void OnNotify()
        {
            // Show the achievement to the player
            AchievementPanel.SetActive(true);
            // if this was a legit game you'd want to save that the player got the achievement
            // so you could save that here
        }

    }
}
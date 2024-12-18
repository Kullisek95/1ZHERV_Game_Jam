using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VictoryTime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI victoryTimeText;
    // Update is called once per frame
    void Update()
    {
        // Get timer elapsedtime from TimerScript
        float elapsedTime = GameObject.FindObjectOfType<Timer>().elapsedTime;

        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        int milliseconds = Mathf.FloorToInt((elapsedTime * 1000) % 1000);

        victoryTimeText.text = string.Format("Final Time: {0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    
        if (minutes <= 2 && seconds <= 15)
        {
            victoryTimeText.text += "\nYou beat the author time! To claim your small reward, e-mail xkvapi19@stud.fit.vutbr.cz with the codephrase 'Bounce Tales'.\n\n*Only the first person to reach out gets the reward.";
        }
    }
}

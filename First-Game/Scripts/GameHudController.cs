using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHudController : MonoBehaviour
{
    //nao funcionou
    //public static GameHudController instance;

    public Text timerText;
    public  Text pointsText;
    public Text highScoreText;

    private float timeValue = 0;
    private int points = 0;
    //private static int highScore = 0;

    // Update is called once per frame
    void Update()
    {
        //Update the timer
        if (GameMenuController.isGameOver)
        {
            return;
        }
        else
        {
            timeValue += Time.deltaTime;
        }

        DisplayTimer(timeValue);
    }

    public void DisplayTimer(float timeDisplay){

        float minutes = Mathf.FloorToInt(timeDisplay / 60);
        float seconds = Mathf.FloorToInt(timeDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void DisplayPoints(){
        points++;
        pointsText.text = points.ToString();
        highScoreText.text = points.ToString();
    }
}

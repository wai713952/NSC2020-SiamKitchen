using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class food_timer : MonoBehaviour
{
    [SerializeField] private float timeCount;   //time count 
    [SerializeField] private int timeMin;       //display minute
    [SerializeField] private int timeSec;       //display second
    private TextMeshPro timeText;               //display text
    public static int timeUsed;                 //int that link to score window

    private void Start()    //function at start of scene
    {
        timeText = GetComponent<TextMeshPro>(); //access component TMPro of this object
        timeCount = 180;                        //start time value (180 seconds)
    }

    private void Update()   //functional at runtime
    {
        if(check_serve.finish == false)                 //as long as player didn't serve food, time continues to count
        {
            timeCount -= Time.deltaTime;                //time count is decrease by second
            timeUsed = Mathf.FloorToInt(timeCount);     //change time count to round number
        }

        if(timeCount > 0)                                   //as long as time is more than 0, display positve countdown
        {
            timeMin = Mathf.FloorToInt(timeCount / 60);     //change to minute
            timeSec = Mathf.FloorToInt(timeCount % 60);     //change to second
            timeText.text = (timeMin + " : " + timeSec);    //display time
        }

        if(timeCount < 0)                                           //if time is lower than 0, diplay negative countdown
        {
            timeMin = Mathf.FloorToInt(Mathf.Abs(timeCount / 60));  //change to absolute minute
            timeSec = Mathf.FloorToInt(Mathf.Abs(timeCount % 60));  //change to absolute second
            timeText.text = ("- " + timeMin + " : " + timeSec);     //display negative overtime

            if(timeCount < -60)         //if the time count is lower than -60 second
                print("game over");     //game over
        }
    }
}

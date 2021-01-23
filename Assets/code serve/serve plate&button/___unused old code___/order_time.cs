using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class order_time : MonoBehaviour
{
    TextMeshPro timeText;
    [SerializeField] private float timeCount;
    [SerializeField] private int timeMin;
    [SerializeField] private int timeSec;
    public static int timeUsed;

    private void Start() 
    {
        timeText = GetComponent<TextMeshPro>();
        timeCount = 180f;
    }

    public void time_reset()
    {
        timeCount = 180f;
    }

    private void Update() 
    {

        if(check_serve.finish == false)
        {
            timeCount -= Time.deltaTime;
            timeUsed = Mathf.FloorToInt(timeCount);
        }

        if(timeCount > 0)
        {
            timeMin = Mathf.FloorToInt(timeCount / 60);
            timeSec = Mathf.FloorToInt(timeCount % 60);
            timeText.text = (timeMin + " : " + timeSec);
        }

        if(timeCount < 0)
        {
            timeMin = Mathf.FloorToInt(Mathf.Abs(timeCount / 60));
            timeSec = Mathf.FloorToInt(Mathf.Abs(timeCount % 60));
            timeText.text = ("- " + timeMin + " : " + timeSec);

            if(timeCount < -60)
                print("game over");
        }
    }
}
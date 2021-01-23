using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_time_use : MonoBehaviour
{
    public void Start() 
    {
        TextMeshPro timeUsedText = GetComponent<TextMeshPro>();     //access component
        timeUsedText.text = ( ( 180 - Mathf.FloorToInt(food_timer.timeUsed) ) / 60 + " : " + ( (180 - Mathf.FloorToInt(food_timer.timeUsed) ) % 60) );      //display time used on score panel
    }
}
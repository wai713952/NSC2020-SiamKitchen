using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class score_food_name : MonoBehaviour
{
    public void Start() 
    {
        TextMeshPro scoreFoodName =  gameObject.GetComponent<TextMeshPro>();    //access TMPro component of this object
        scoreFoodName.text = (food_order_random.foodNameGet);                   //display food name on score panel
    }
}
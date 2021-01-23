using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class food_order_random : MonoBehaviour
{
    
    private int numberRandom;   //random block number in array
    public static string foodNameGet;   //food name from random

    private void Start()    //active function when spawn prefab
    {
        TextMeshPro foodOrderText = GetComponent<TextMeshPro>();    //access TMPro component of this object
        
        GameObject nameArray = GameObject.Find("order screen");     //reference the object that hold array of food by finding name
        string[] foodRandomList = nameArray.GetComponent<food_array>().foodArray;   //reference array of food in the other object

        numberRandom = Random.Range (0 , foodRandomList.Length);    //random index(block number) of array as int from [0] to length of food array
        foodNameGet = (foodRandomList[numberRandom]);               //get random food name as string
        foodOrderText.text = foodNameGet;                           //display the food name as TMPro.text
    }
}
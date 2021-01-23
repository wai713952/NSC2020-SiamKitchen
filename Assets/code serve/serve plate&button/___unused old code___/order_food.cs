using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class order_food : MonoBehaviour
{
    public string[] foodList;
    TextMeshPro randomTX;
    public static string randomText;
    private int arrayRandom;

    private void Start() 
    {
        randomTX = GetComponent<TextMeshPro>();
        randomText = (foodList[arrayRandom]);
        randomTX.text = randomText;
    }

    public void food_pause()
    {
        randomTX.text = ("-");
    }

    public void food_random()
    {
        arrayRandom = Random.Range (0 , foodList.Length);
        if(check_serve.finish == true)
        {
            randomTX.text = (foodList[arrayRandom]);
        }
    }
}
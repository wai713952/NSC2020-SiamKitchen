using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fired : MonoBehaviour
{
    public List<GameObject> ingredient = new List<GameObject>();
    public bool readyToCook = false;

    
    private void OnTriggerStay(Collider other) {
        if(other.GetComponent<food>() != null && readyToCook){
            other.GetComponent<food>().CookingTimeCalculate();
        
            other.GetComponent<food>().checkStage();
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<food>() != null){
            ingredient.Remove(other.gameObject);
        }
    }
}

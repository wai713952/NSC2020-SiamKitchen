using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button_press : MonoBehaviour
{
    public static bool isPress;     //bool check if press serve button

    private void Start()
    {
        isPress = false;            //pressing is false
    }

    void OnTriggerStay(Collider other)      //
    {
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0) && singlegrap.whatHoldNow == null && isPress == false)     //
        {
            isPress = true;                 //
            StartCoroutine(buttonWait());   //
        }
    }

    IEnumerator buttonWait()        //
    {
        yield return new WaitForSeconds(0.01f);     //
        isPress = false;                            //
    }
}
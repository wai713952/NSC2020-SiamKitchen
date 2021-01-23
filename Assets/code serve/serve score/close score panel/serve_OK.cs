using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serve_OK : MonoBehaviour
{
    public Animator scorePanelAnim;
    private void Awake() 
    {
        scorePanelAnim.SetBool("closePanel" , false);   //play animation "open panel"
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == ("hand") && Input.GetKeyDown(KeyCode.Mouse0))   //if hand is in trigger and press left mouse
        {
            scorePanelAnim.SetBool("closePanel" , true);    //play "close panel" animation, and destroy self
        }
    }
}
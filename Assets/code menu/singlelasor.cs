using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class singlelasor : MonoBehaviour
{
    private Ray raySelection;   //ray of hand
    private RaycastHit rayHit;  //object that ray hit
    public float rayRange;  //range of ray
    public LayerMask mask;  //mask that ray can hit

    private bool isCooldown;    //is ray cooldown
    private bool animStart;     //is can be animation active

    GameObject selectObject;    //object that ray is hitting
    
    public GameObject sureQuitObject;   //quit confirm windown

    public void Start()     //start of the scene
    {
        sureQuitObject.SetActive(false);    //hide quit window

        isCooldown = true;  //ray is not active
        animStart = false;  //no animation is play

        StartCoroutine(startCooldown());    //start counting after the scene if start
    }

    IEnumerator startCooldown() //count down method
    {
        yield return new WaitForSeconds(5f);    //wait for (?) seconds
        isCooldown = false; //after (?) seconds, ray can be use
    }

    public void FixedUpdate()   //function that always active at runtime
    {                
        raySelection = new Ray (transform.position, transform.forward);     //setting up raycast (position of ray , direction of ray)

        if(isCooldown == false) //after the cooldown is end the ray can be
        {
            if(Physics.Raycast(raySelection,out rayHit, rayRange, mask, QueryTriggerInteraction.Ignore))    //(rayname , hit what , distance , what it can interact(layer) , aim to hit collider(ignore trigger))
            {
                Debug.DrawLine(raySelection.origin, rayHit.point,Color.red);    //display red line if the ray has hit the object with specific mask

                if(rayHit.collider.GetComponent<Animator>() != null)    //check if the hit object has Animator component
                {
                    selectObject = rayHit.collider.gameObject;  //reference the hit object
                    selectObject.GetComponent<Animator>().SetBool(("isSelected") , true);   //access Animator of hit object and play "select animation"  
                    animStart = true;   //can play "deselect animation" after "select animation" is play for the first time
                }


                if(rayHit.collider.name == ("quit") && Input.GetKeyDown(KeyCode.Mouse0))    //if ray is hitting quit button and press left mouse
                {
                    sureQuitObject.SetActive(true); //display the confirm quit window
                    GameObject.Find("menu lists").SetActive(false);
                }

                if(rayHit.collider.GetComponent<Animator>() != null)
                {
                    selectObject = rayHit.collider.gameObject;
                    selectObject.GetComponent<Animator>().SetBool(("YesNoSelect") , true);
                }
            }

            else    //ray doesn't hit any mask
            {
                if(animStart == true)   //until "select animation" is play, "deselect animation" will never be played
                {
                    selectObject.GetComponent<Animator>().SetBool(("isSelected") , false);  //play "deselect animation" after ray leave the object

                    if(GameObject.Find("sure quit") != null && rayHit.collider == null)
                        selectObject.GetComponent<Animator>().SetBool(("YesNoSelect") , false);
                }

                Debug.DrawLine(raySelection.origin, raySelection.origin + raySelection.direction * rayRange, Color.green);  //show green line of ray
            }
        }
    }


}
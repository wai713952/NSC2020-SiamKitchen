using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check_serve : MonoBehaviour
{
    public static bool finish;
    private GameObject serveItem;

    public Transform scoreSpawnPoint;
    public GameObject scorePrefab;

    public Transform orderSpawnPoint;
    public GameObject orderPrefab;
    
    private GameObject windowObject;
    private GameObject panelObject;
    private GameObject orderObject;

    public void Start() 
    {
        windowObject = GameObject.FindWithTag("serve window");
        finish = false;
        GameObject orderClone = Instantiate(orderPrefab , orderSpawnPoint.transform.position , Quaternion.Euler (0, 0, 0)) as GameObject;
    }

    public void OnTriggerStay(Collider other) 
    {

        if(other.GetComponent<itemserial>().itemType == ("container") && finish == false && button_press.isPress == true)
        { 
            finish = true;
            windowObject.GetComponent<Animator>().SetBool("isServe" , false);
            serveItem = other.gameObject;

            if(GameObject.FindWithTag("score panel") != null)
            {
                panelObject = GameObject.FindWithTag("score panel");
                panelObject.GetComponent<Animator>().SetBool("closePanel" , true);
            }

            StartCoroutine(waitServe());
        }
    }

    IEnumerator waitServe()
    {
        yield return new WaitForSeconds(1f);

        orderObject = GameObject.FindWithTag("order list");
        orderObject.GetComponent<Animator>().SetBool("isListOpen" , false);

        yield return new WaitForSeconds(2f);

        GameObject scoreClone = Instantiate(scorePrefab , scoreSpawnPoint.transform.position , Quaternion.Euler(0, 0, 0)) as GameObject;


        yield return new WaitForSeconds(4f);

        Destroy(serveItem);
        GameObject orderClone = Instantiate(orderPrefab , orderSpawnPoint.transform.position , Quaternion.Euler (0, 0, 0)) as GameObject;
        windowObject.GetComponent<Animator>().SetBool("isServe" , true);

        finish = false;
    }
}
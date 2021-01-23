using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spatula : MonoBehaviour
{
    [SerializeField] Ray spaRay;
    [SerializeField] RaycastHit spaHit;
    [SerializeField] public float spaRange;
    [SerializeField] public LayerMask spaMask;
    [SerializeField] public Transform spaHolder;
    [SerializeField] public Transform spaItem;

    public void FixedUpdate() 
    {
        spaRay = new Ray (transform.position, -transform.up);
        if(Physics.Raycast(spaRay, out spaHit, spaRange, spaMask, QueryTriggerInteraction.Ignore))
        {
            Debug.DrawLine(spaRay.origin, spaHit.point,Color.red);

            if(spaHit.transform.GetComponent<itemserial>() != null)
            {
                if(Input.GetKeyDown(KeyCode.Mouse1) && singlegrap.whatHoldNow == "spatula")
                {
                    spaHit.collider.gameObject.transform.parent = spaHolder;
                    spaItem = spaHit.transform;
                    spaItem.GetComponent<Rigidbody>().useGravity = false;
                    spaItem.GetComponent<Collider>().attachedRigidbody.constraints =
                    RigidbodyConstraints.FreezeAll;
                }
            }
        }

        else
        {
            Debug.DrawLine(spaRay.origin, spaRay.origin + spaRay.direction * spaRange, Color.green);
        }

        if(spaHolder.childCount != 0)
        {
            spaItem.position = spaHolder.position;
            spaItem.rotation = spaHolder.rotation;
        }
    }
}

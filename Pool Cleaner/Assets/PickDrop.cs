using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickDrop : MonoBehaviour
{

    public GameObject cam,FlashLight;
    public Transform FLHolder,ItemHolder,InteractablesContainer;
    public float maxPickDist=4;
    bool isHolding = false;
    [HideInInspector] public bool isHoldingFlash = false;
    public LayerMask mask;
    GameObject whatIsHolding;
    Vector3 wihScale;
   

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)|| Input.GetKeyDown(KeyCode.Q)) && isHolding) Drop();

        if (Input.GetKeyDown(KeyCode.E) && !isHolding) Pick();

    }

    void Pick()
    {
        RaycastHit hit;

      

            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, maxPickDist, mask))
            {

                //Debug.Log(hit.transform.name);


                if (hit.transform.gameObject == FlashLight)
                {

                    FlashLight.transform.SetParent(FLHolder);
                    FlashLight.transform.localPosition = Vector3.zero;
                    FlashLight.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    FlashLight.transform.localScale = Vector3.one;

                int layerHand = LayerMask.NameToLayer("InHand"); 

                    FlashLight.layer = layerHand;

                isHoldingFlash = true;
                }

                 if (hit.transform.CompareTag("Interact"))
              
                {
                    GameObject obj = hit.transform.gameObject;
                    wihScale = obj.transform.localScale;

                   // Debug.Log("foi");
                    obj.transform.SetParent(ItemHolder);
                    obj.transform.localPosition = Vector3.zero;
                    obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
                    obj.transform.localScale = Vector3.one;

                int layerHand = LayerMask.NameToLayer("InHand");

                obj.layer = layerHand;

                    whatIsHolding = obj;
                    isHolding = true;
                }

            }
        }
       
    

    void Drop()
    {

        RaycastHit hitDown;
        Physics.Raycast(transform.position, Vector3.down, out hitDown);
        whatIsHolding.transform.SetParent(InteractablesContainer);
        whatIsHolding.transform.localRotation = Quaternion.Euler(new Vector3(-90, 0 ,Random.Range(0,360)));
        whatIsHolding.transform.position = hitDown.point;
        whatIsHolding.transform.localScale = wihScale;

        int layerGround = LayerMask.NameToLayer("Interagir");

        whatIsHolding.layer = layerGround;
        whatIsHolding = null;

        isHolding = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    public Light luz;
    public PickDrop PD;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F) && PD.isHoldingFlash)
        {
            luz.enabled = !luz.enabled;
        }

    }

    
}

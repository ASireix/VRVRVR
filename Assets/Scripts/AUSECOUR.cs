using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AUSECOUR : MonoBehaviour
{
    public XRIDefaultInputActions controls;
    // Start is called before the first frame update
    void Awake()
    {
        controls = new XRIDefaultInputActions();
        
        controls.XRILeftHand.Activate.performed += ctx => Grow();
    }

    void Grow()
    {
        Debug.Log("test");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable(){
        controls.XRILeftHand.Enable();
    }

    private void OnDisable(){
        controls.XRILeftHand.Disable();
    }
}

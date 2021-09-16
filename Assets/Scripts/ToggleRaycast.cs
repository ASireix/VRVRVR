using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleRaycast : MonoBehaviour
{


    // Start is called before the first frame update
    private XRRayInteractor rayInteractor;
    void Start()
    {
        rayInteractor = GetComponent<XRRayInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal GameObject GetGameObject(){
        return gameObject;
    }
}

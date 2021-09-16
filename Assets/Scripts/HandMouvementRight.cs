using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandMouvementRight : MonoBehaviour
{
    private ActionBasedController controller;

    public Hand hand;

    public ToggleRaycast ray;



    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        controller.selectAction.action.started += ctx => Activate_Action(1f);
        controller.selectAction.action.canceled += ctx => Activate_Action(0f);

        controller.activateAction.action.started += ctx => ToggleRay(false);
        controller.activateAction.action.canceled += ctx => ToggleRay(true);


    }

    private void ToggleRay(bool b)
    {
        hand.GetGameObject().SetActive(b);
        ray.GetGameObject().SetActive(!b);
    }

    private void Activate_Action(float f)
    {
        hand.SetGrip(f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}

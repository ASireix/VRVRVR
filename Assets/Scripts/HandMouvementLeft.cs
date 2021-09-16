using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(ActionBasedController))]
public class HandMouvementLeft : MonoBehaviour
{
    private ActionBasedController controller;
    public Hand hand;




    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<ActionBasedController>();

        controller.selectAction.action.started += ctx => Activate_Action(1f);
        controller.selectAction.action.canceled += ctx => Activate_Action(0f);

        controller.activateAction.action.started += ctx => Select_Action(1f);
        controller.activateAction.action.canceled += ctx => Select_Action(0f);


    }

    private void Select_Action(float f)
    {
        hand.SetTrigger(f);
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

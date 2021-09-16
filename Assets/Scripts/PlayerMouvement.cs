using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMouvement : MonoBehaviour
{

    public Camera cam;

    public float speed;

    public float speedMultiplier = 2f;

    public XRIDefaultInputActions controls;

    Vector2 move;

    //public Rigidbody body;

    float turnSmoothVelocity;

    public float turnSmoothTime = .1f;

    // Start is called before the first frame update
    void Awake()
    {
        controls = new XRIDefaultInputActions();

        controls.XRILeftHand.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.XRILeftHand.Move.canceled += ctx => move = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(move.x, 0, move.y).normalized;

        movement = Quaternion.Euler(0, cam.transform.eulerAngles.y, 0) * movement;

        speed = Mathf.Sqrt(Mathf.Pow(move.x, 2) + Mathf.Pow(move.y, 2)) * speedMultiplier;

        if (movement.magnitude >= .1f)
        {
            transform.Translate(movement * speed * Time.deltaTime);
            /*body.MovePosition(transform.position + (movement * speed * Time.deltaTime));
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            body.MoveRotation(Quaternion.Euler(0f, angle, 0f));*/

        }
    }

    private void OnEnable(){
        controls.XRILeftHand.Enable();
    }

    private void OnDisable(){
        controls.XRILeftHand.Disable();
    }
}

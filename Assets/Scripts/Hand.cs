using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Animator anim;
    private BoxCollider col;

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed = 30f;
    [SerializeField] private float rotateSpeed = 100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;

    private Transform followTarget;
    private Rigidbody body;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<BoxCollider>();

        followTarget = followObject.transform;
        body = GetComponent<Rigidbody>();
        body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        body.interpolation = RigidbodyInterpolation.Interpolate;
        body.mass = 20f;

        body.position = followTarget.position;
        body.rotation = followTarget.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        MovePhysics();
    }

    internal void SetTrigger(float f)
    {
        anim.SetFloat("Trigger", f);
    }

    internal void SetGrip(float f)
    {
        anim.SetFloat("Grip", f);
        if (f == 1){
            col.isTrigger = true;
        }else{
            col.isTrigger = false;
        }
    }

    private void MovePhysics()
    {

        var positionWithOffset = followTarget.position + positionOffset;
        var distance = Vector3.Distance(positionWithOffset, transform.position);
        body.velocity = (positionWithOffset - transform.position).normalized * (followSpeed * distance);

        var rotationWithOffset = followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        if (angle>180f){
            angle -= 360f;
            
        }
        body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);


    }

    internal GameObject GetGameObject(){
        return gameObject;
    }
}


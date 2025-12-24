using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableWire : MonoBehaviour
{
    public Transform holdPoint; // empty object in front of camera
    private Rigidbody rb;
    private bool isHeld = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (isHeld)
        {
            transform.position = holdPoint.position;
        }
    }

    public void Grab()
    {
        isHeld = true;
        rb.isKinematic = true;
    }

    public void Release()
    {
        isHeld = false;
        rb.isKinematic = false;
    }
}

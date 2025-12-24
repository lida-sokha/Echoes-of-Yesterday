using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;


public class PlugController : MonoBehaviour
{
    public Light directionalLight;
    public bool isConected = false;
    private bool powered = false;
    public UnityEvent OnWirePlugged;
    public Transform plugPosition;

    [HideInInspector]
    public Transform endAnchor;
    [HideInInspector]
    public Rigidbody endAnchorRB;
    [HideInInspector]
    public WireController wireController;
    public void OnPlugged()
    {
        OnWirePlugged.Invoke();
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.gameObject == endAnchor.gameObject)
        {
            isConected = true;
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            endAnchor.transform.rotation = transform.rotation;


            OnPlugged();
        }
        GrabbableWire wire = other.GetComponentInParent<GrabbableWire>();
        if (wire == null || powered) return;

        powered = true;
        isConected = true;

        // Lock end anchor
        if (endAnchorRB != null)
            endAnchorRB.isKinematic = true;

        if (endAnchor != null && plugPosition != null)
        {
            endAnchor.position = plugPosition.position;
            endAnchor.rotation = plugPosition.rotation;
        }

        // 💡 TURN ON LIGHT
        if (directionalLight != null)
            directionalLight.enabled = true;

        // 🔔 Events
        OnPlugged();

        Debug.Log("Wire plugged → POWER ON");

    }

    private void Update()
    {

        if (isConected)
        {
            endAnchorRB.isKinematic = true;
            endAnchor.transform.position = plugPosition.position;
            Vector3 eulerRotation = new Vector3(this.transform.eulerAngles.x + 90, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
            endAnchor.transform.rotation = Quaternion.Euler(eulerRotation);
            directionalLight.enabled = true;
        }
       

    }
}

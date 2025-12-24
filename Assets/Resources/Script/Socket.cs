using UnityEngine;

public class Socket : MonoBehaviour
{
    public Light directionalLight; // assign in Inspector

    private void OnTriggerEnter(Collider other)
    {
        GrabbableWire wire = other.GetComponent<GrabbableWire>();
        if (wire)
        {
            // Snap wire into socket
            wire.transform.position = transform.position;
            wire.transform.rotation = transform.rotation;
            wire.GetComponent<Rigidbody>().isKinematic = true;

            // 🔆 TURN ON LIGHT
            if (directionalLight != null)
            {
                directionalLight.enabled = true;
            }

            Debug.Log("Wire plugged in! Power ON");
        }
    }
}

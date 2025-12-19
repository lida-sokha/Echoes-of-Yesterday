using UnityEngine;

public class electric_open : MonoBehaviour
{
    // --- Public Parameters ---
    [Tooltip("The angle (in degrees) the door will open.")]
    public float openAngle = 90f;
    [Tooltip("The speed of the door opening (higher = faster).")]
    public float openSpeed = 2f;
    [Tooltip("If true, the door cannot be closed once opened.")]
    public bool openOnce = true;

    // --- Private State ---
    private bool isOpen = false;
    private Quaternion closedRot;
    private Quaternion openRot;

    // --- Interaction Check (Manual for testing/simplicity) ---
    [Tooltip("Key to press to attempt interaction (for testing only).")]
    public KeyCode interactionKey = KeyCode.E;
    [Tooltip("Maximum distance from the camera to interact.")]
    public float maxInteractionDistance = 2f;

    void Start()
    {
        // Store the initial rotation as the closed state
        closedRot = transform.rotation;

        // Calculate the target rotation for the open state
        // Rotates around the Y-axis (Vector3.up) by openAngle degrees
        openRot = Quaternion.Euler(
            transform.eulerAngles + Vector3.up * openAngle
        );
    }

    void Update()
    {
        // --- 1. Manual Interaction Check (Optional, usually handled by a separate script) ---
        if (Input.GetKeyDown(interactionKey))
        {
            float dist = Vector3.Distance(
                Camera.main.transform.position,
                transform.position
            );

            // Check distance AND if the door is NOT already fully open/opening
            if (dist < maxInteractionDistance && !isOpen)
            {
                // Trigger the interaction logic
                Interact();
            }
        }

        // --- 2. Door Rotation Logic ---
        if (isOpen)
        {
            // Smoothly move the door towards the open rotation (openRot)
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRot,
                // Time.deltaTime * openSpeed ensures framerate independence
                Time.deltaTime * openSpeed
            );
        }
        else if (!openOnce) // Allows closing if openOnce is false
        {
            // Smoothly move the door towards the closed rotation (closedRot)
            transform.rotation = Quaternion.Slerp(
               transform.rotation,
               closedRot,
               Time.deltaTime * openSpeed
           );
        }
    }

    // --- Public Interaction Method (Called by external scripts) ---
    public void Interact()
    {
        // If 'openOnce' is true, and it's already open, do nothing.
        if (openOnce && isOpen) return;

        // Toggle the open state
        isOpen = !isOpen;

        // Optional: Debug confirmation
        Debug.Log(gameObject.name + " is now " + (isOpen ? "opening." : "closing."));
    }
}
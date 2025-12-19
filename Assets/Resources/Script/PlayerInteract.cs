using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;

    [Tooltip("A reference to your script that handles camera looking. Must be assigned in the Inspector!")]
    public MonoBehaviour cameraLookScript;

    void Update()
    {
        // 🚨 CRITICAL CHANGE: Using the E key for interaction 🚨
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }

        // Check for an escape/cancel key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursorAndResumeLook();
        }
    }

    void TryInteract()
    {
        Ray ray = new Ray(
            Camera.main.transform.position,
            Camera.main.transform.forward
        );

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
             

            // 2. SECONDARY CHECK: SIMPLE DOOR (Your modern door script)
            

            // 3. TERTIARY CHECK: OLD DOOR (electric_open, for backward compatibility)
            electric_open oldDoor = hit.collider.GetComponent<electric_open>();
            if (oldDoor != null)
            {
                oldDoor.Interact();
                return;
            }
        }
    }

    // --- HELPER FUNCTIONS ---

    public void LockCursorAndStopLook()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraLookScript != null)
        {
            cameraLookScript.enabled = false;
        }
    }

    public void UnlockCursorAndResumeLook()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraLookScript != null)
        {
            cameraLookScript.enabled = true;
        }
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            UnlockCursorAndResumeLook();
        }
    }
}
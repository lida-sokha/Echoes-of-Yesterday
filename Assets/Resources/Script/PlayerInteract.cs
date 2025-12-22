using UnityEngine;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera playerCamera;
    public MonoBehaviour cameraLookScript;

    [Header("UI")]
    public TextMeshProUGUI interactText;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = Camera.main;

        if (interactText != null)
            interactText.gameObject.SetActive(false);
    }

    void Update()
    {
        CheckForInteractable();

        if (Input.GetKeyDown(KeyCode.E))
        {
            TryInteract();
        }
        if (Input.GetMouseButtonDown(0))
        {
            TryInteract();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnlockCursorAndResumeLook();
        }
    }

    void CheckForInteractable()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            EleInteraction interaction =
                hit.collider.GetComponentInParent<EleInteraction>();

            if (interaction != null)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = "Click to Open";
                return;
            }
        }

        interactText.gameObject.SetActive(false);
    }

    void TryInteract()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            EleInteraction interaction =
                hit.collider.GetComponentInParent<EleInteraction>();

            if (interaction != null)
            {
                interaction.Interact();
            }
        }
    }
    public void LockCursorAndStopLook()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if (cameraLookScript != null)
            cameraLookScript.enabled = false;
    }

    public void UnlockCursorAndResumeLook()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (cameraLookScript != null)
            cameraLookScript.enabled = true;
    }
}

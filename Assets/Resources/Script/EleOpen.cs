using UnityEngine;

public class EleOpen : MonoBehaviour
{
    public float openAngle = 90f;     // how much it opens
    public float openSpeed = 2f;      // how fast
    public bool openOnce = true;

    private bool isOpen = false;
    private Quaternion closedRot;
    private Quaternion openRot;

    void Start()
    {
        closedRot = transform.rotation;
        openRot = Quaternion.Euler(
            transform.eulerAngles + Vector3.up * openAngle
        );
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float dist = Vector3.Distance(
                Camera.main.transform.position,
                transform.position
            );

            if (dist < 2f && !isOpen)
            {
                OpenDoor();
            }
        }

        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRot,
                Time.deltaTime * openSpeed
            );
        }
    }

    void OpenDoor()
    {
        isOpen = true;
    }
}

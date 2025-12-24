using Unity.VisualScripting;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 2f;

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
        if (isOpen)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                openRot,
                Time.deltaTime * openSpeed
            );
        }
        

    }

    // 👉 CALLED BY PLAYER
    public void Interact()
    {
        if (isOpen) return;
        isOpen = true;
    }
    
}

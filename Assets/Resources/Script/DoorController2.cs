using UnityEngine;

public class DoorController2 : MonoBehaviour
{
    public float openSpeed = 5f;
    public float maxHeight = -0.4f;

    private bool doorIsOpening = false;

    void Update()
    {
        if (doorIsOpening)
        {
            transform.Translate(Vector3.up * openSpeed * Time.deltaTime);

            if (transform.position.y >= maxHeight)
            {
                doorIsOpening = false;
            }
        }
    }

    void OnMouseDown()
    {
        doorIsOpening = true;
    }
}

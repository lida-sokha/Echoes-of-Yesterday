using UnityEngine;

public class wire : MonoBehaviour
{
    private bool dragging = false;
    private float zDistance;

    void OnMouseDown()
    {
        dragging = true;
        zDistance = Vector3.Distance(
            Camera.main.transform.position,
            transform.position
        );
    }


    void OnMouseUp()
    {
        dragging = false;
    }

    void Update()
    {
        if (!dragging) return;

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = zDistance; // IMPORTANT

        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = worldPos;
    }
}
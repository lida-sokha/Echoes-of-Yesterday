using System.Collections;
using UnityEngine;

public class EleInteraction : MonoBehaviour
{
    [Header("Cup Settings")]
    public Transform cup; // assign Cup here
    public Vector3 openRotation = new Vector3(7.9f, 90f, 0f);
    public float rotateSpeed = 5f;

    private Quaternion closedRotation;
    private Quaternion openedRotation;
    private bool isOpen = false;
    private Coroutine currentCoroutine;

    void Start()
    {
        if (cup == null)
        {
            Debug.LogError("Cup is not assigned!");
            return;
        }

        closedRotation = cup.localRotation;
        openedRotation = Quaternion.Euler(openRotation);
    }

    public void Interact()
    {
        if (currentCoroutine != null)
            StopCoroutine(currentCoroutine);

        currentCoroutine = StartCoroutine(RotateCup());
        isOpen = !isOpen;
    }

    IEnumerator RotateCup()
    {
        Quaternion targetRotation = isOpen ? closedRotation : openedRotation;

        while (Quaternion.Angle(cup.localRotation, targetRotation) > 0.1f)
        {
            cup.localRotation = Quaternion.Lerp(
                cup.localRotation,
                targetRotation,
                Time.deltaTime * rotateSpeed
            );
            yield return null;
        }

        cup.localRotation = targetRotation;
    }
}

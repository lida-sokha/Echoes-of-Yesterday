using UnityEngine;
using TMPro;

public class Password : MonoBehaviour
{
    [SerializeField] private TMP_Text passwordText;

    void Start()
    {
        passwordText.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            passwordText.text = "Password:123";
            passwordText.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            passwordText.gameObject.SetActive(false);
        }
    }
}

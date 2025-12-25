using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingSceneController : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Endgame";
    [SerializeField] private float introDuration = 20f; // match text duration

    void Start()
    {
        StartCoroutine(LoadGameAfterIntro());
    }

    IEnumerator LoadGameAfterIntro()
    {
        yield return new WaitForSeconds(introDuration);
        SceneManager.LoadScene(gameSceneName);
    }
}

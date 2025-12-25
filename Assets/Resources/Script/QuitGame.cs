using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void Quitgame()
    {
        SceneManager.LoadSceneAsync(0);
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToStartGame : MonoBehaviour
{
    public void StartGame()
    {


        Invoke("LoadSceneWithDelay", 1f);
        SceneManager.LoadScene("Test");
    }
    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene("Test");
    }
}

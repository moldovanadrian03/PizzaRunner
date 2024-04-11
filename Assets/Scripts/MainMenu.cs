using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void OpenOptions()
    {
        // Implement your options menu opening logic here
        Debug.Log("Options menu opened");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

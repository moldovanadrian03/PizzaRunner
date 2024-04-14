using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject levelsPanel;
    public void Start()
    {
        levelsPanel = GameObject.FindGameObjectWithTag("Levels");
        levelsPanel.SetActive(false);
    }

    public void PlayGame()
    {
        this.gameObject.SetActive(false);
        levelsPanel.SetActive(true);

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

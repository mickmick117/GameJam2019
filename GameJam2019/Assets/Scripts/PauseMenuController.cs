using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
    }

    public void Quit()
    {
        Resume();
        // TODO: Return to first scene
    }
}

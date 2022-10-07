using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject pauseMenu, dialoguePanel, friendDialoguepanel, missionCompleteMenu;
    public GameObject TPCam;

    void Update()
    {
        PauseMenu();
        CursorAndCamToggle();
    }

    void CursorAndCamToggle()
    {
        if(dialoguePanel.activeInHierarchy == false && pauseMenu.activeInHierarchy == false && friendDialoguepanel.activeInHierarchy == false 
            && missionCompleteMenu.activeInHierarchy == false)
        {
            Cursor.lockState = CursorLockMode.Locked;
            TPCam.SetActive(true);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            TPCam.SetActive(false);
        }
    }

    public void PauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu.activeInHierarchy == false)
            {
                pauseMenu.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                pauseMenu.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}

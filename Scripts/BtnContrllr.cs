using UnityEngine;

public class BtnContrllr : MonoBehaviour
{
    public GameObject infoPanel, btnsPanel;

    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Info()
    {
        if(infoPanel.activeInHierarchy == false)
        {
            infoPanel.SetActive(true);
            btnsPanel.SetActive(false);
        }
        else
        {
            infoPanel.SetActive(false);
            btnsPanel.SetActive(true);
        }
    }

    public void OpenYoutube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCPV0wSJx1FxCP4POfhfFcbQ");
    }
}

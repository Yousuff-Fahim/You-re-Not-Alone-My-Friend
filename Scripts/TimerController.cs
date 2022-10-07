using System;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    public Text timerTxt, MissionCompleteTimerTxt, bestTimeTxt, MissionCompleteBestTimeTxt;
    public GameObject PauseMenu, StartDialogue, FriendDialogue, MissionCompleteMenu, timer, bestTime;

    float currentTime;

    private void Start()
    {
        currentTime = 0;
        bestTimeTxt.text = string.Format("BEST TIME: {0:00:00}", PlayerPrefs.GetFloat("HighScore", 0));
    }

    void Update()
    {
        Timer();
        MissionCompleteCheck();
    }

    public void Timer()
    {
        if (PauseMenu.activeInHierarchy == false && StartDialogue.activeInHierarchy == false 
            && FriendDialogue.activeInHierarchy == false && MissionCompleteMenu.activeInHierarchy == false)
        {
            currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            timerTxt.text = time.ToString(@"mm\:ss\:ff");
        }
    }

    public void MissionCompleteCheck()
    {
        if(MissionCompleteMenu.activeInHierarchy == true)
        {
            timer.SetActive(false);
            bestTime.SetActive(false);
            MissionCompleteTimerTxt.text = "TIME: " + timerTxt.text;
            MissionCompleteBestTimeTxt.text = string.Format("BEST TIME: {0:00:00}", PlayerPrefs.GetFloat("HighScore", 0));
            SaveHighScore();
        }
    }

    public void SaveHighScore()
    {
        if(currentTime < PlayerPrefs.GetFloat("HighScore", 99))
        {
            PlayerPrefs.SetFloat("HighScore", currentTime);
        }
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        bestTimeTxt.text = string.Format("BEST TIME: {0:00:00}", PlayerPrefs.GetFloat("HighScore", 0));
    }
}

using UnityEngine;

public class PauseButton : MonoBehaviour
{
    [Header("Pause Menu Reference")]
    [SerializeField] private GameObject pausePanel;

    public void OnPausePressed()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void OnResumePressed()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnQuitPressed()
    {
        Time.timeScale = 1f;
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}

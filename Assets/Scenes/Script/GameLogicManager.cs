using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogicManager : MonoBehaviour
{
    [SerializeField]
    GameObject pauseUI;
    [SerializeField]
    GameObject gameplayUI;
    AudioSource bgm;
    void Awake()
    {
        bgm = GameObject.FindGameObjectWithTag("BGM").GetComponent<AudioSource>();
    }
    public void PauseGame()
    {
        pauseUI.SetActive(true);
        gameplayUI.SetActive(false);
        bgm.Pause();
        Time.timeScale = 0;
    }
    public void ContinueGame()
    {
        
        StartCoroutine(Continue());
    }
    IEnumerator Continue()
    {
        pauseUI.SetActive(false);
        gameplayUI.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        Time.timeScale = 1;
        bgm.Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}

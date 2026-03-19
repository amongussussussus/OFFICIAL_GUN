using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    [SerializeField]
    SceneAsset gameplayScene;
    public void NewGame()
    {
        SceneManager.LoadSceneAsync(gameplayScene.name);
    }

    public void LoadGame()
    {
        
    }
    public void Exit()
    {
        Application.Quit();
    }
}

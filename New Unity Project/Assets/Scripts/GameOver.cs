using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

public string SceneName;
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
       
        Application.LoadLevel("BurherH4");
    }
}


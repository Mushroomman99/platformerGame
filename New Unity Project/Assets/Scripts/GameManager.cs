using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    private const bool Value = false;
    public AudioClip Sound;
    public string SceneName;
   
   [SerializeField] private GameObject PanelPause;
    // Start is called before the first frame update
      public void PauseOn()
{
  
      PanelPause.SetActive(true);
      Time.timeScale =0;
  

  }
    public void PauseOff()
{
  
      PanelPause.SetActive(false);
      Time.timeScale =1;
  

  }
   public void ExitGame()
    {
        Application.LoadLevel("MenuV.3");//Загружаем сцену
    }
    public void NewGame()
    {
       SceneManager.LoadScene(SceneName);//Загружаем сцену
       PanelPause.SetActive(false);
    }


}





using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public string SceneName;
    private Score sc;
    private ProfControl pr;
 void Start() {
    
 
    
}
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.tag == "Player") //Проверяем тэг объекта
        {
            ChangeScene();
            SaveScore();
              
        }
    }
    private void ChangeScene()
    {
         SceneManager.LoadScene(SceneName);//Загружаем сцену
       

    } 
     void SaveScore()
     {
         PlayerPrefs.SetInt("Score",Score.scoreAmount);
         PlayerPrefs.SetString("Name",My_Txt.MyText);
     }
}

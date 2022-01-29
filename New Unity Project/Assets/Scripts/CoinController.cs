using UnityEngine;

public class CoinController : MonoBehaviour
{
    private const string BURGER_KEY = "BURGER";
  // [SerializeField] private SaveManader highscoreTable;

    public AudioClip CoinSound;//звук сбора монеты
    
    public int burger;//переменная количества собранных монет
   
    void OnTriggerEnter2D(Collider2D other) //запустится если collider2D попал в триггер
    {
         //проверка, имеет ли попавший объект тэг Coin
        if (other.tag == "Burger")
        {
            AudioSource.PlayClipAtPoint(CoinSound, transform.position);
           
            Destroy(other.gameObject); //удалить монету из сцены
        }

    }
    

    // сохраняем настройки
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("Burger", burger);
        PlayerPrefs.Save();
        
    }

    
}
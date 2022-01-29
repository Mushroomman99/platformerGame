using UnityEngine;
using UnityEngine.UI;

public class LiveCount : MonoBehaviour
{
    

 
    public int defaultLives;
    public static int livesCounter;

    public Text livesText;
   // private GameManager theGM;

    void Start()
    {
        livesCounter = defaultLives;
       //theGM = findObjectOfType<GameManadger>();
      
    }

    void Update()
   {     
        livesText.text = "x " + livesCounter;
        

   }
    

}



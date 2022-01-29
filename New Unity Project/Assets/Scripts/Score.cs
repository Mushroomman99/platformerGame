using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public  class Score : MonoBehaviour
{
    public static int scoreAmount;
     static Text scoreText;

    void Start()
    {
        scoreText = GetComponent<Text>();
        scoreAmount = 0;
        if(PlayerPrefs.HasKey("Score"))
        {
            if(Application.loadedLevel == 1)
            {
               PlayerPrefs.DeleteKey("Score");
               scoreAmount=0;
            }
            else
            {
               scoreAmount =PlayerPrefs.GetInt("Score");
            }

        }
         // SaveManader.AddHighscoreEntry(scoreAmount, "Name");
    }
     void Update()
    {
        scoreText.text = "Score: " + scoreAmount;
    }
}

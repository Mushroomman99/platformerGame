using UnityEngine;


public class menu : MonoBehaviour
{
    public string text;
    public GameObject buttonsMenu;
    public GameObject buttonsExit;
    public GameObject buttonsName;
    // public string animationName;
    // UnityEvent myEvent = new UnityEvent();
    
    // void PlayAnimation()
    // {
    //     GetComponent<Animation> ().Play(animationName);
    //     Cursor.visible=false;

    // }
   public void EnterNameButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsName.SetActive(true);
    }
   
    public void ShowExitButtons()
    {
        buttonsMenu.SetActive(false);
        buttonsExit.SetActive(true);
    }
    public void BackInManu()
    {
        buttonsMenu.SetActive(true);
        buttonsExit.SetActive(false);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    public void NewGame()
    {
        Application.LoadLevel("BurherH4");
}
}


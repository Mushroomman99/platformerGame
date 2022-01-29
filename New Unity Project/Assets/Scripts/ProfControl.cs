using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class ProfControl : MonoBehaviour
{  private const string Name_KEY = "Name";
    public InputField InName;
    public Text nameText;

    void Start()
    {  
       nameText.text =My_Txt.MyText;
    }
public void Save(){
     PlayerPrefs.SetString("Name", My_Txt.MyText);
        PlayerPrefs.Save();
}
  public void Load(){
      My_Txt.MyText= InName.text;
    
      
}


}



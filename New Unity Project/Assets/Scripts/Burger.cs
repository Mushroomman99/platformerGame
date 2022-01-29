using UnityEngine;

public class Burger : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        Score.scoreAmount += 1;
        if (other.tag == "Burger")
        {
          Destroy(other.gameObject); //удалить из сцены
        }
    }
}

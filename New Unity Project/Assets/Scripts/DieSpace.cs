using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieSpace : MonoBehaviour
{

      public GameObject respawn;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawn.transform.position;
          //  PlayerCntrl.livesCounter -= 1;
            LiveCount.livesCounter -= 1;
        }
    }
}


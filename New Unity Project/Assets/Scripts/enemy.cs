using UnityEngine;
public class enemy : MonoBehaviour
{
 public AudioClip CoinSound;
    public float speed; // скорость движения
    public Transform[] points = new Transform[2];
    Rigidbody2D rb;
          void Start()
    {
        rb = GetComponent<Rigidbody2D>();     
     }
void Update()
{
    transform.Translate(Vector2.right * speed * Time.deltaTime);
     if (transform.position.x >= points[0].position.x)
        {
        transform.eulerAngles = new Vector3(0, -180, 0);
    }
    else if (transform.position.x <= points[1].position.x)
        {
        transform.eulerAngles = new Vector3(0, 0, 0);
        }
  }
    
      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
       
           LiveCount.livesCounter -= 1; 
               
           if(LiveCount.livesCounter < 1)
            {
               PlayerCntrl.anim.SetBool("Dead", true);
               AudioSource.PlayClipAtPoint(CoinSound, transform.position);
               Invoke("Die",0.8f); 
            } 
        }
    }
      void Die() 
     {
           
        Application.LoadLevel("GameOver");   
     }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerCntrl : MonoBehaviour
{

    public float maxSpeed = 20f;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
  
    public static Animator anim;  //ссылка на компонент анимаций
    private bool isGrounded = false;
    public Transform groundCheck;
    private float groundRadius = 0.2f;
    public LayerMask whatIsGround;

  //блок для мигания
    private Material matBlink;
    private Material matDefault;
     public SpriteRenderer spriteRend;
        Renderer rend;
	     Color c;

   
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //   DontDestroyOnLoad(gameObject);
       spriteRend = GetComponent<SpriteRenderer>();
       matBlink = Resources.Load("PlayerBlink", typeof(Material)) as Material;
       matDefault = spriteRend.material;
       gameObject.GetComponent<Animator>().Play("Dead");

       rend = GetComponent<Renderer> ();
		c = rend.material.color;
    }

  
    void Update()
    {

        float move = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * move * maxSpeed * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.Space))

            rb.AddForce(Vector2.up * 8000);
        //в компоненте анимаций изменяем значение параметра Speed на значение оси Х.
        //приэтом нам нужен модуль значения
       

        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);

        //если нажали клавишу для перемещения вправо, а персонаж направлен влево
       
        //определяем, на земле ли персонаж
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        //устанавливаем соответствующую переменную в аниматоре
        anim.SetBool("Ground", isGrounded);
        //устанавливаем в аниматоре значение скорости взлета/падения
        anim.SetFloat("vSpeed", rb.velocity.y);
        //если персонаж в прыжке - выход из метода, чтобы не выполнялись действия, связанные с бегом
        if (!isGrounded)  //если персонаж на земле и нажат пробел...


            return;

        anim.SetFloat("Speed", Mathf.Abs(move));
        //обращаемся к компоненту персонажа RigidBody2D. задаем ему скорость по оси Х, 
        //равную значению оси Х умноженное на значение макс. скорости
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
        if (move > 0 && !isFacingRight) //отражаем персонажа вправо

            Flip();
        
        else if (move < 0 && isFacingRight) // отражаем персонажа влево
            Flip();

            
    }

    private void Flip()
    {
        //меняем направление движения персонажа
        isFacingRight = !isFacingRight;
        //получаем размеры персонажа
        Vector3 theScale = transform.localScale;
        //зеркально отражаем персонажа по оси Х
        theScale.x *= -1;
        //задаем новый размер персонажа, равный старому, но зеркально отраженный
        transform.localScale = theScale;
    }
    private void UpdateF()
    {
        //если персонаж на земле и нажат пробел...
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            //устанавливаем в аниматоре переменную в false
            anim.SetBool("Ground", false);
            //прикладываем силу вверх, чтобы персонаж подпрыгнул
            rb.AddForce(new Vector2(0, 600));
        }
            
         
        
    }

 void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "Enemy")
        {          
            spriteRend.material = matBlink;
         
            Invoke("ResetMaterial",0.05f);
            }
           // godMode = true;
           else if (collision.gameObject.name.Equals ("Enemy") && LiveCount.livesCounter > 0)
              
			StartCoroutine ("GetInvulnerable");

        
        


          
        
       
    }
     void ResetMaterial()
        {
             spriteRend.material = matDefault;
        }
      

	IEnumerator GetInvulnerable()
	{
		Physics2D.IgnoreLayerCollision (8, 9, true);
		c.a = 0.5f;
		rend.material.color = c;
		yield return new WaitForSeconds (3f);
		Physics2D.IgnoreLayerCollision (8, 9, false);
		c.a = 1f;
		rend.material.color = c;
	}





}
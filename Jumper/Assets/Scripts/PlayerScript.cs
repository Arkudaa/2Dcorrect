using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;// loome kasti rigidbody jaoks. Kati nimi on rb
    public float speed;// loome muutuja kiiruse jaok
    private bool facingRight;
    private Animator anim;
    public float jumpforce;
    private bool isJumping;
    private AudioSource jumpmusic;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        facingRight = true;
        anim = GetComponent<Animator>();
        jumpmusic = GetComponent<AudioSource>();
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "lavablock")
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        if (collision.collider.tag == "ground")
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "ground")
        {
            isJumping = true;
        }
    }

    void Move(float horisontal)
    {
        rb.velocity = new Vector2(horisontal*speed, rb.velocity.y);
        anim.SetFloat("speed", horisontal);
        
        
    }
   /* private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "killerblock")
        {
            Debug.Log("hit");
            Application.LoadLevel(Application.loadedLevel);
            
        }
    }*/

   

    void Flip(float horizontal)
    {
        if(horizontal>0 && !facingRight || horizontal<0 && facingRight )
        {
            facingRight = !facingRight;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;


        }
    }

    // Update is called once per frame
    void Update()
    {
        float horisontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Move(horisontal);
        Flip(horisontal);

        if(Input.GetButtonDown("Jump") && isJumping == false)
        {
            rb.AddForce(new Vector2(0f, jumpforce), ForceMode2D.Impulse);
            jumpmusic.Play();

        }
        
        
    }

    

    
      
    
}

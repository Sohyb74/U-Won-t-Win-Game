using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public float speed , climbSpeed = 4.0f;
    public float jumpForce = 14.0f;
    bool climp = false,isPressed=false;
    public float direction;
    public Joystick joystick;
    public Animator anime;
    public Rigidbody2D rb;
    public BoxCollider2D collider2D;
    [SerializeField] LayerMask Ground;
    public bool isjumping = false;
    public Color targetColor = new Color(1, 1, 1, 0);
    private SpriteRenderer spriteRenderer;
    private Transform playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        playerPosition = GetComponent<Transform>();
        anime = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        collider2D = GetComponent<BoxCollider2D>();

    }
    // Update is called once per frame
    void Update()
    {
        //moving the sprite
        
        
        //transform.position += new Vector3(direction, 0, 0) * speed * Time.deltaTime;
            direction = joystick.Horizontal;
         if (joystick.Horizontal>= 0.25f)
         {

            direction = speed;
         }
         else if (joystick.Horizontal<= -0.25f)
         {
            direction = -speed;
            
         }
         else
        {
            direction = 0;
        }
        rb.velocity = new Vector2(direction , rb.velocity.y);
        //Jumping

        if (joystick.Vertical > 0.3f && !isjumping)
        {

            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isjumping = true;
          

        }
        UpdateAnimation();


        if (Input.GetKeyDown(KeyCode.Escape))
        {
        
             SceneManager.LoadScene(0);
        }

    }

   

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            Invoke("Nextlevel", 0.3f);
        }
        if (collision.gameObject.tag == "Transport")
        {
            transform.position = new Vector3(439.18f, 8.74f, 0.0f);
        }

        if (collision.gameObject.tag == "Transport1")
        {
            transform.position = new Vector3(422.36f, 25.89f, 0.0f);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //ground CHeck
        if (collision.gameObject.tag == "Ground")
        {
            isjumping = false;
            climp =false;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isjumping = true;
             climp =false;
        }
    }
    void OnTriggerStay2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "ladder")
        {
            float y = joystick.Vertical;
            Vector2 movement = new Vector3(0.0f, y, 0.0f);
            rb.velocity = movement.normalized * climbSpeed;
            climp = true;

        }
       
    }
    

    //when winning the first level transsferring the characeter to the next level
    IEnumerator TransportSprite(Color endValue, float duration)
    {
        float time = 0;
        Color startValue = spriteRenderer.color;
        while (time < duration)
        {
            spriteRenderer.color = Color.Lerp(startValue, endValue, time / duration);//lerping to the target positiong in the next map
            time += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = endValue;

        transform.position = new Vector3(48.67342f, 2.078473f, 0);

        while (time < duration)
        {
            spriteRenderer.color = Color.Lerp(endValue, startValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        spriteRenderer.color = startValue;
    }

    IEnumerator Hit2(float duration)
    {
        float time = 0;
        Vector3 target = new Vector3(transform.position.x, transform.position.y + 3, 0);
        while (time < duration)
        {
            transform.position = Vector3.Lerp(transform.position, target, 0.05f * (time / duration));
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = target;

    }


    public void Nextlevel()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void UpdateAnimation()
    {



        int state;
        if (direction < 0)
        {

            spriteRenderer.flipX = true;
            state = 1;
            

        }
        else if (direction > 0)
        {
            state = 1;
            spriteRenderer.flipX = false;

            //transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            state = 0;
        }

       

        if (rb.velocity.y > 0.01f && !climp)
        {
            state = 2;
            
        }
        else if (rb.velocity.y < -.01f && !climp)
        {
            state = 3;
        }

        else if (climp)
        {
            state = 4;
        }
        anime.SetInteger("state", state);

    }
    /* private bool IsGrounded ()
     {
       return Physics2D.BoxCast(collider2D.bounds.center,collider2D.bounds.size,0f,Vector2.down,1f,Ground);


     }*/
}

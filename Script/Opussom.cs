using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Opussom : MonoBehaviour
{
    Movement play;
    private float speed= 250.0f;
    private SpriteRenderer Ropussom;
    private Rigidbody2D Ropussom2D;
    bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        Ropussom2D = GetComponent<Rigidbody2D>();
        Ropussom = GetComponent<SpriteRenderer>();
        if (SceneManager.GetActiveScene().buildIndex == 2) {speed= 275.0f;} 
        if (SceneManager.GetActiveScene().buildIndex == 3){speed= 300.0f;} 
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(Ropussom2D.velocity.x) <= 0.01f)
        {
            isRight = !isRight;
            Ropussom.flipX = !Ropussom.flipX;
        }
        if (isRight)
        {
            Ropussom2D.velocity = new Vector2(Time.fixedDeltaTime * 1 * speed, 0);
        }
        else 
        { 
        
            Ropussom2D.velocity = new Vector2(Time.fixedDeltaTime * -1 * speed, 0);
        }
    }
}

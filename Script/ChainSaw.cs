using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainSaw : MonoBehaviour
{
    public float speed;
    private SpriteRenderer RChainSaw;
    private Rigidbody2D ChainSaw2D;
    bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        ChainSaw2D = GetComponent<Rigidbody2D>();
        RChainSaw = GetComponent<SpriteRenderer>();
        speed = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(ChainSaw2D.velocity.x) <= 0.01f)
        {
            isRight = !isRight;
            RChainSaw.flipX = !RChainSaw.flipX;
        }
        if (isRight)
        {
            ChainSaw2D.velocity = new Vector2(Time.fixedDeltaTime * 1 * speed, ChainSaw2D.velocity.y);
        }
        else
        {

            ChainSaw2D.velocity = new Vector2(Time.fixedDeltaTime * -1 * speed, ChainSaw2D.velocity.y);
        }
    }
}

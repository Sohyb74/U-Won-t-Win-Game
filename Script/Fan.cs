using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    private float fanBlow = 0.2f;
    private BoxCollider2D bc;
    void Start(){
        bc = GetComponent<BoxCollider2D>();
    }
    void update(){
    }

    void OnCollisionStay2D(Collision2D collision){
            if(collision.gameObject.tag =="Player"){
                GetComponent<BoxCollider2D>().size += new Vector2(0, fanBlow);
                Debug.Log(GetComponent<BoxCollider2D>().size);
            }
    }
    void OnCollisionExit2D(Collision2D collision){
        GetComponent<BoxCollider2D>().size = new Vector2(1.48f, 0.56f);
    }
}

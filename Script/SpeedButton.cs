using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpeedButton : MonoBehaviour
{
    bool isHeld;
    Movement movement;
   public GameObject player;
    private void Awake()
    {
        movement = player.GetComponent<Movement>();
        
    }
    void Update()
    {
        if (isHeld)
        {
            
            movement.speed = 7.5f;
            movement.anime.speed = 1.5f;
           // Debug.Log("fsd");

        }
        else if (!isHeld)
        {
            movement.anime.speed = 1f;
            movement.speed = 6f;
        }
    }
    public void Holdbutton()
    {
        isHeld = true;
    }
    public void Realesebutton()
    {
        isHeld = false;
    }
}

    

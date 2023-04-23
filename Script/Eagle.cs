using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
    [SerializeField]
    Transform Player;
    [SerializeField]
    float eagaleHeight = 5;
    [SerializeField]
    float speed = 2;
    Vector3 startPositon ;
    SpriteRenderer EagleEye;


    // Start is called before the first frame update
    void Start()
    {
        EagleEye = GetComponentInChildren<SpriteRenderer>();
        startPositon = transform.position;
        StartCoroutine(EgaleAnimation());   
    }

    // Update is called once per frame
    void Update()
    {
        //Eagle Will Be See Player Direction And go With It
        if (Player.position.x > transform.position.x)
        {
            EagleEye.flipX = true;
        }
        else
        {
            EagleEye.flipX = false;
        }
    }
    IEnumerator EgaleAnimation()
    {
        
        Vector3 endPosition = new Vector3(startPositon.x, startPositon.y + eagaleHeight , startPositon.z);
        bool isFlight = true;
        float value = 0;
        while (true)
        {
            yield return null;
            //Eagle movement up to down
            if (isFlight)
                transform.position = Vector3.Lerp(startPositon,endPosition,value);
            //Eagle movement down to up
            else
                transform.position = Vector3.Lerp(endPosition, startPositon, value);
            value = value + Time.deltaTime * speed; //سرعة الصعود و النزول 
            if (value > 1) // ل التبديل بين حركة الصعود والنزول
            { 
                value = 0;
                isFlight = !isFlight;
            }
        }
    } 
}

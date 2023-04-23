using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class CollectFruits : MonoBehaviour
{
    Health health = new Health();
    public Animator animator;
    public Material materialToChange;
    private int score;
    private TextMeshProUGUI ScoreText;
    public Transform holder;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
        score = 0;
        materialToChange = gameObject.GetComponent<Renderer>().material;
        ScoreText = holder.Find("TxtScore").GetComponent<TextMeshProUGUI>();
        ScoreText.text = "Score:" + score;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Score"){
            score += 1;
            ScoreText.text = "score:" + score;
            Destroy(collision.gameObject);

        }
       /* if(collision.gameObject.tag == "Poison") {
           health.playerHealth = health.playerHealth - 3;
         
            Destroy(collision.gameObject);
            StartCoroutine(ChangeScale(2.5f, 4.0f));
            Invoke("Death", 3f);
            Invoke("loadMyScene", 4f);
            

        } */
    }
    //public Color targetColor = new Color(255,0,0);
   
    
   
}

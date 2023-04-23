using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Health : MonoBehaviour
{
    public int playerHealth = 10;

    private bool left, right;
    private Vector3 targetPositionFromLeft = new Vector3(389.54f, 13.98f, 0.0f);
    private Vector3 targetPositionFromRight = new Vector3(389.54f, 13.98f, 0.0f);
    private Vector3 targetPositionFromTop = new Vector3(13.98f, 13.98f, 0.0f);
   public Transform holder, playerpos;
    public TextMeshProUGUI HealthText;
    private Animator anime;
    // Start is called before the first frame update
    void Start()
    {


        anime = GetComponent<Animator>();
        HealthText = holder.Find("TxtHealth").GetComponent<TextMeshProUGUI>();



        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            targetPositionFromLeft = new Vector3(384.8f, 37.83f, 0.0f);
            targetPositionFromRight = new Vector3(384.8f, 37.83f, 0.0f);
            targetPositionFromTop = new Vector3(384.8f, 37.83f, 0.0f);
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            targetPositionFromLeft = new Vector3(336.8f, 35.18842f, 0.0f);
            targetPositionFromRight = new Vector3(336.8f, 35.18842f, 0.0f);
            targetPositionFromTop = new Vector3(336.8f, 35.18842f, 0.0f);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Poison")
        {
            playerHealth = playerHealth - 3;

            Destroy(collision.gameObject);
            StartCoroutine(ChangeScale(2.7f, 2.9f));
            Invoke("ResetScale", 3f);
            Invoke("DeathAnimation",2.85f);


            if (playerHealth <= 0)
            {

                DeathAnimation();
                Invoke("Over", 0.5f);


            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Opossum" || collision.gameObject.tag == "Eagle")
        {
            playerHealth -= 1;
            HealthText.text = "Health:" + playerHealth + "/10";

            if (transform.position.x < -28)
            {
                left = true;
                right = false;
                StartCoroutine(SpriteHit(0.2f, left, right));//a coroutine that for the hit effect
            }
            else if (transform.position.x > -26)
            {
                left = false;
                right = true;
                StartCoroutine(SpriteHit(0.2f, left, right));
            }
            else if (transform.position.y > -7.048364f)
            {
                right = false;
                left = false;
                StartCoroutine(SpriteHit(0.2f, left, right));
            }

            if (playerHealth <= 0)
            {
               
                DeathAnimation();
                Invoke("Over", 0.5f);


            }
        }
    }
    IEnumerator SpriteHit(float duration, bool left, bool right)
    {
        float time = 0;
        if (left)
        {
            while (time < duration)
            {
                transform.position = Vector3.Lerp(transform.position, targetPositionFromLeft, 0.05f * (time / duration));
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPositionFromLeft;
        }
        else if (right)
        {
            while (time < duration)
            {
                transform.position = Vector3.Lerp(transform.position, targetPositionFromRight, 0.05f * (time / duration));
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPositionFromRight;
        }
        else if (!left && !right)
        {
            while (time < duration)
            {
                transform.position = Vector3.Lerp(transform.position, targetPositionFromTop, 0.05f * (time / duration));
                time += Time.deltaTime;
                yield return null;
            }
            transform.position = targetPositionFromTop;
        }

    }
    public void DeathAnimation()
    {
        anime.SetTrigger("Death");
        
        
    }

    public void Over()
    {
        SceneManager.LoadScene(5);
    }

    public void loadMyScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private float scaleModifier = 1.0f;
    float targetScale;
    IEnumerator ChangeScale(float endValue, float duration)
    {
        float time = 0;
        float startValue = scaleModifier;
        Vector3 startScale = transform.localScale;
        //materialToChange.color = targetColor;
        while (time < duration)
        {
            scaleModifier = Mathf.Lerp(startValue, endValue, time / duration);
            transform.localScale = startScale * scaleModifier;
            time += Time.deltaTime;
            yield return null;
        }
        transform.localScale = startScale * targetScale;
        scaleModifier = targetScale;
    }
    public void ResetScale()
    {
        transform.localScale = new Vector3(1, 1, 1);
        HealthText.text = "Health:" + playerHealth + "/10";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RandomMovement : MonoBehaviour
{
    public float speed;
    public Transform[] moveSpots;
    private int randomSpot;

    private float waitTime;
    public float startWaitTime;

    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    Vector2 direction;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    Vector2 moveDir;
    void FixedUpdate()
    {
        


        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);



        HandleSpriteFlip();



        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        
    }

    private void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && transform.position.x > 0)
        {
            spriteRenderer.flipX = true;
            Debug.Log("Flipped left");
        }
        else if (spriteRenderer.flipX && transform.position.x < 0)
        {            
            spriteRenderer.flipX = false;
            Debug.Log("Flipped right");
        }
    }

    


}

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
    Vector2 transformDir;
    int counter;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        spriteRenderer = GetComponent<SpriteRenderer>();
        direction = transform.position;
    }

    void Update()
    {

        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);
        
        
        if (Time.realtimeSinceStartup % 1 > 0 && Time.realtimeSinceStartup % 1 < 0.3)
        {
            direction = transform.position;
        }
        if (Time.realtimeSinceStartup % 1 >= 0.3)
        {
            transformDir = transform.position;
        }


        HandleSpriteFlip();
        
        List<Sprite> directionSprites = GetSpriteDirection();

        if (directionSprites != null)
        {
            spriteRenderer.sprite = directionSprites[0];
        }
        else
        {

        }


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
        if (!spriteRenderer.flipX && direction.x > transform.position.x)
        {
            spriteRenderer.flipX = true;
            Debug.Log("Flipped left");
        }
        else if (spriteRenderer.flipX && direction.x < transform.position.x)
        {            
            spriteRenderer.flipX = false;
            Debug.Log("Flipped right");
        }
    }
    List<Sprite> GetSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if (transformDir.x > direction.x)
        {
            if (transformDir.y > direction.y)
            {
                selectedSprites = neSprites;
            }
            else if (transformDir.y < direction.y)
            {
                selectedSprites = seSprites;
            }
            else
            {
                selectedSprites = eSprites;
            }
        }
        if (transformDir.x == direction.x)
        {
            selectedSprites = nSprites;
        }


        return selectedSprites;
    }



}

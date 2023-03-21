using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankMover : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public float maxSpeed = 10;
    public float rotationSpeed = 100;
    Vector2 movementVector;
    Vector2 direction;
    public List<Sprite> nSprites;
    public List<Sprite> neSprites;
    public List<Sprite> eSprites;
    public List<Sprite> seSprites;
    public List<Sprite> sSprites;
    public SpriteRenderer spriteRenderer;

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        direction = new Vector2(movementVector.x, movementVector.y).normalized;
        //direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        rb2d.velocity = direction * maxSpeed * Time.deltaTime;

        if (!spriteRenderer.flipX && direction.x < 0)
        {
            Debug.Log(direction.x);
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
    }
}

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

    public UnityEvent<float> OnSpeedChange = new UnityEvent<float>();
   

    private void Awake()
    {
        rb2d = GetComponentInParent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb2d.velocity = transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;
        rb2d.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime));

    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;
        OnSpeedChange?.Invoke(this.movementVector.magnitude);
    }
}

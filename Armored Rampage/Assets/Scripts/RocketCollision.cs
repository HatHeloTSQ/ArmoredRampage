using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollision : MonoBehaviour
{
    public float Speed = 4.0f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * Speed;

    }
    private void OnCollisionEnter(Collision collision)
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
        Destroy(gameObject);
    }

}
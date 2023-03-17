using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpOnObject : MonoBehaviour
{
    public PowerUpBaseScript PowerUpScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PowerUpScript.ApplyPowerUp(collision.gameObject);
        Destroy(gameObject);
    }
}

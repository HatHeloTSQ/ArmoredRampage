using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPRestore : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) ApplyPowerUp(collision);
    }

    private void ApplyPowerUp(Collider2D collisionObj)
    {
        var restored = collisionObj.GetComponentInChildren<Damagable>().MaxHealth - collisionObj.GetComponentInChildren<Damagable>().Health;
        collisionObj.GetComponentInChildren<Damagable>().Health += restored;
        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        Destroy(this.gameObject);

    }

}

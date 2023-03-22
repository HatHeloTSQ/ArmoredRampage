using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    public int buffValue;
    public float duration;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) StartCoroutine(ApplyPowerUp(collision));
    }

    private IEnumerator ApplyPowerUp(Collider2D collisionObj)
    {
        collisionObj.GetComponentInChildren<TankMover>().maxSpeed += buffValue;

        this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(duration);

        collisionObj.GetComponentInChildren<TankMover>().maxSpeed -= buffValue;
        Destroy(this.gameObject);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PowerUps/Speed")]
public class SpeedBuff : PowerUpBaseScript
{
    public float moveSpeedAmount;
    public float rotaSpeedAmount;

    public override void ApplyPowerUp(GameObject gameObject)
    {
        gameObject.GetComponent<TankMover>().maxSpeed += moveSpeedAmount;
        gameObject.GetComponent<TankMover>().rotationSpeed += rotaSpeedAmount;
    }
}
 
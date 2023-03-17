using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="PowerUps/Health")]
public class HPbuff : PowerUpBaseScript
{
    public override void ApplyPowerUp(GameObject gameObject)
    {
        var currentHealth = gameObject.GetComponent<Damagable>().Health;
        var maxHealth = gameObject.GetComponent<Damagable>().MaxHealth;
        if (currentHealth < maxHealth)
        {
            currentHealth += (maxHealth-currentHealth);
        }
    }
}

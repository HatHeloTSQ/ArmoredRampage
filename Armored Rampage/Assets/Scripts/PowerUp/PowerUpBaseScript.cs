using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBaseScript : ScriptableObject
{
    public abstract void ApplyPowerUp(GameObject gameObject);
}

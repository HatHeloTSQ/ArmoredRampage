using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SummonNextLevel : MonoBehaviour
{
    public UnityEvent OnAllEnemiesDestroyed;
    GameObject[] enemies;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        CheckIfAllDied(enemies);
    }

    public void CheckIfAllDied(GameObject[] enemies)
    {
        if(enemies.Length == 0)
        {
            OnAllEnemiesDestroyed?.Invoke();
        }
    }
}

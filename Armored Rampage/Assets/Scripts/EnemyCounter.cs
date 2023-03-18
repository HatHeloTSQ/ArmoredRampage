using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    GameObject[] enemies;
    public Text enemyCounterText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if(enemies.Length > 0)
        {
            enemyCounterText.text = "Enemies alive: " + enemies.Length.ToString();
        }
        else
        {
            enemyCounterText.text = "Well Done! Proceed to the next zone!";
        }
    }
}

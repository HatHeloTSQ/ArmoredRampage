using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyAI : MonoBehaviour
{
    [SerializeField]
    private AIBehaviour shootBehaviour, patrolBehaviour;

    [SerializeField]
    TankController tank;

    [SerializeField]
    AiDetector detector;

    private void Awake()
    {
        detector = GetComponentInChildren<AiDetector>();
        tank = GetComponentInChildren<TankController>();
    }

    private void Update()
    {
        if(tank != null || detector != null)
        {
            if (detector.TargetVisible)
            {
                shootBehaviour.PerformAction(tank, detector);
            }
            else
            {
                patrolBehaviour.PerformAction(tank, detector);
            }
        }
        
    }


}

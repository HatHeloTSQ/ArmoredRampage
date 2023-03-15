using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollowPlayerTest : MonoBehaviour
{
    public Transform objectToFollow;
    RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        
    }

    private void Update()
    {
        if (objectToFollow != null)
        {
            rectTransform.position = objectToFollow.position;
        }
    }
}

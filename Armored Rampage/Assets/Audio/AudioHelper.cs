using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;

public class AudioHelper : MonoBehaviour
{
    public UnityEvent onMute;
    public float value;

    public void AudioSlider_OnZero()
    {
        if (value <= -20)
        {
            onMute?.Invoke();
        }
    }
}

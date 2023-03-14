using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenuScript : MonoBehaviour
{
    private Resolution[] resolutions;
    public Dropdown resDropdown;

    //TODO fix resolution menu https://www.youtube.com/watch?v=YOaYQrN1oYQ

    /*private void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        var resOptions = new List<string>();
        for (int i = 0; i < resolutions.Length; i++)
        {
            resOptions.Add(resolutions[i].width + " x " + resolutions[i].height);
        }
        resDropdown.AddOptions(resOptions);
    }*/

    public void GraphQualityDropdown_SetQuality(int qualityIdx)
    {
        QualitySettings.SetQualityLevel(qualityIdx); 
    }

    public void FullscreenToggle_SetFullscreen(bool isFullscreen)
    {
        Debug.Log($"Fullscreen value is {isFullscreen}");
        Screen.fullScreen = isFullscreen;
    }
}

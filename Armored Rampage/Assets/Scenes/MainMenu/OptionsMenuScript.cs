using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class OptionsMenuScript : MonoBehaviour
{
    private Resolution[] resolutions;
    public TMP_Dropdown resDropdown;
    [SerializeField]
    private AudioMixer mixer;

    public void Start()
    {
        resolutions = Screen.resolutions;

        resDropdown.ClearOptions();

        var resOptions = new List<string>();
        int width, height, currentResIdx = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            width = resolutions[i].width;
            height = resolutions[i].height;
            string current = $"{width} x {height}";
            resOptions.Add(current);

            if (width == Screen.currentResolution.width && height == Screen.currentResolution.height) currentResIdx = i;
        }
        resDropdown.AddOptions(resOptions);
        resDropdown.value = currentResIdx;
        resDropdown.RefreshShownValue();
    }

    public void VolumeSliderMusic_SetVolume(float vol)
    {
        mixer.SetFloat("musicVol",vol);
    }

    public void VolumeSliderFX_SetVolume(float vol)
    {
        mixer.SetFloat("fxVol", vol);
    }

    public void ResolutionDropdown_SetResolution(int resIdx)
    {
        Resolution resolution = resolutions[resIdx];
        Screen.SetResolution(resolution.width,resolution.height,Screen.fullScreen);
    }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private int menuIndex;

    public int MenuIndex
    {
        get { return menuIndex; }
        set { menuIndex = SceneManager.GetActiveScene().buildIndex; }
    }

    public void PlayButton_MainMenu() 
    {
        Debug.Log($"Scene ({MenuIndex+1})  loaded");
        SceneManager.LoadScene(MenuIndex + 1);
    }

    public void ExitButton_ExitGame()
    {
        Debug.Log("Game exited (exit button pressed)");
        Application.Quit();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}

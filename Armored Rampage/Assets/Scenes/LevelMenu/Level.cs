using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private int sceneIdx;

    public int SceneIdx
    {
        get { return sceneIdx; }
        set { sceneIdx = SceneManager.GetActiveScene().buildIndex; }
    }

    public void ReturnToMainMenu()
    {
        Debug.Log($"Scene {0} selected");
        SceneManager.LoadScene(0);
    }

    public void LevelSelection_LevelSelected(string levelName)
    {
        SceneManager.LoadScene(levelName);
          
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

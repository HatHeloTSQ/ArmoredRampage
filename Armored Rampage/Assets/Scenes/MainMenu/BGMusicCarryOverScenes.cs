using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusicCarryOverScenes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private static BGMusicCarryOverScenes instance = null;
    public static BGMusicCarryOverScenes Instance
    { 
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)Destroy(this.gameObject);
        else instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

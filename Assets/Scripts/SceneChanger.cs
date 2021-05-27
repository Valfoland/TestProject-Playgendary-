using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private const string Scene1 = "Game1";
    private const string Scene2 = "Game2";

    public static Action onChangeScene;
    
    public void ChangeScene()
    {
        onChangeScene?.Invoke();
            
        switch (SceneManager.GetActiveScene().name)
        {
            case Scene1:
                SceneManager.LoadScene(Scene2);
                break;
            case Scene2: 
                SceneManager.LoadScene(Scene1);
                break;
            default: 
                SceneManager.LoadScene(Scene1);
                break;
        }
    }
}

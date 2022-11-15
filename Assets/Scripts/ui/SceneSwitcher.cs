using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public ModelLoader modelLoader;
    
    public void playTutorial()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("tutorial");
    }

    public void playEX1()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("EX1");
    }

    public void playEX2()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("EX2");
    }

    public void backToMenu()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("MainMenu");
    }
}

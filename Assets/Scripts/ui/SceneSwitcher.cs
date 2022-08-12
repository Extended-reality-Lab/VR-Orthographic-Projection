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

    public void playPractice()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("SampleScene");
    }

    public void backToMenu()
    {
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("MainMenu");
    }
}

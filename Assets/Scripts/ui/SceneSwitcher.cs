using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class SceneSwitcher : MonoBehaviour
{
    public ModelLoader modelLoader;

    public RenderTexture sim_cam1;
    public RenderTexture sim_cam2;
    public RenderTexture sim_cam3;
    public int scene;

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
        //1
        string filePath = Application.persistentDataPath;
        Texture2D image1 = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture.active = sim_cam1;
        image1.ReadPixels(new Rect(0, 0, sim_cam1.width, sim_cam1.height), 0, 0);
        image1.Apply();
        byte[] bytes1 = image1.EncodeToPNG();
        File.WriteAllBytes(filePath + "/_1task" + scene.ToString() + ".png", bytes1);

        //2
        Texture2D image2 = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture.active = sim_cam2;
        image2.ReadPixels(new Rect(0, 0, sim_cam1.width, sim_cam1.height), 0, 0);
        image2.Apply();
        byte[] bytes2 = image2.EncodeToPNG();
        File.WriteAllBytes(filePath + "/_2task" + scene.ToString() + ".png", bytes2);

        //3
        Texture2D image3 = new Texture2D(512, 512, TextureFormat.RGB24, false);
        RenderTexture.active = sim_cam3;
        image3.ReadPixels(new Rect(0, 0, sim_cam1.width, sim_cam1.height), 0, 0);
        image3.Apply();
        byte[] bytes3 = image3.EncodeToPNG();
        File.WriteAllBytes(filePath + "/_3task" + scene.ToString() + ".png", bytes3);
        //modelLoader.unloadAsset();
        SceneManager.LoadScene("MainMenu");
    }

    public void backToMenusimple()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

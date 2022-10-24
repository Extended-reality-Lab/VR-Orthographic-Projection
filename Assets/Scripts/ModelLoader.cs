using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using XAPI;

public class ModelLoader : MonoBehaviour
{
    public GameObject rightControllerReference;
    public float threshold;

    public Material highlight_mat;
    public Material default_mat;

    public AssetBundle myLoadedAssetBundle;

    public MyPlayerController controller = null;
    [SerializeField]
    private string assetBundleLink = "https://drive.google.com/uc?export=download&id=1XfNnsL7encBKaornvfNtipjTpRUgoyNE";
    // add a assetBundleLine_model for each model you want to be able to access
    private string assetBundleLink_cube = "https://drive.google.com/uc?export=download&id=1XfNnsL7encBKaornvfNtipjTpRUgoyNE";
    private bool clearCache = true;
    public AssetBundle assetBundle = null;
    private GameObject model = null;
    public GameObject parentObj;
    public GameObject foldingcube;

    public void unloadAsset(){

        if (myLoadedAssetBundle != null) {
            myLoadedAssetBundle.Unload(false); //scene is unload from here
        }
    }

    public void loadAsset(){

        unloadAsset();
        myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "default-Android"));
    }

    public void LoadCube(string name) {
        ResetModel();
        //add a switch case for each model that you want accessable
        // switch (name) 
        // {
        //     case "cup":
        //         assetBundleLink = assetBundleLink_cube;
        //         break;
        //     default:
        //         assetBundleLink = assetBundleLink_cube;
        //         break;
        // }
        // Debug.Log(assetBundleLink);

        // Caching.compressionEnabled = false;

        // if (clearCache)
        // {
        //     Caching.ClearCache();
        // }
        StartCoroutine(DownloadAndLoad(name));

        //example xAPI call to LRS.io. 
        // var actor = Actor.FromAccount("https://auth.example.com", "some-long-user-id", name: "some-user-name");
        // var verb = Verbs.Interacted;
        // var activity = new Activity("https://creedo.lrs.io/xapi/", "Model Loading Button");

        // var statement = new Statement(actor, verb, activity);

        // XAPIWrapper.SendStatement(statement, res => {
        //     Debug.Log("Sent simple statement!  LRS stored with ID: " + res.StatementID); 
        // });
    }

    private void Start() {
        //myLoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Application.streamingAssetsPath, "default-Android"));
    }


    private IEnumerator DownloadAndLoad(string name) {
        while (!Caching.ready)
        {
            yield return null;
        }
        // yield return GetBundle();
        // if (!assetBundle)
        // {
        //     Debug.Log("Bundle Failed to Load");
        //     yield break;
        // }
        // Debug.Log(myLoadedAssetBundle);
         Debug.Log(name);
        //model_cube.layer = 6;
        loadAsset();
        model = Instantiate(myLoadedAssetBundle.LoadAsset<GameObject>(name), parentObj.transform);
        model.tag = "model_item";
        
        if (name == "complex")
            model.transform.localScale = model.transform.localScale * .5f;
        if (name == "simple")
            model.transform.localScale = model.transform.localScale * .5f;
        model.transform.eulerAngles = Vector3.zero;
        Model3D mref = model.AddComponent<Model3D>();
        mref.controller = controller;
        mref.rightControllerReference = rightControllerReference;
        mref.threshold = threshold;
        mref.default_mat = default_mat;
        mref.highlight_mat = highlight_mat;
        
        GameObject myfoldingcube = Instantiate(foldingcube);
        //calcualte where I should position the model to be in the center of foldingcube
        //calculate how to sacle model to keep it in the box
        //1. models are square
        //2. will all have the same origin
        GameObject model_cube = Instantiate(myLoadedAssetBundle.LoadAsset<GameObject>(name), GameObject.Find("model_holder").transform);
        model_cube.transform.eulerAngles = Vector3.zero;
        if (name == "complex")
            model_cube.transform.localScale = model_cube.transform.localScale * .4f;
        if (name == "simple")
            model_cube.transform.localScale = model_cube.transform.localScale * .4f;
        if (name == "simple" || name == "complex")
            model_cube.transform.localPosition = new Vector3(.4f,-.3f,-.2f);
        model_cube.layer = 6;


    
        controller.model = model;
        unloadAsset();
    }

    private IEnumerator GetBundle()
    {
        WWW request = WWW.LoadFromCacheOrDownload(assetBundleLink, 0);
        while (!request.isDone)
        {
            yield return null;
        }
        if(request.error == null)
        {
            assetBundle = request.assetBundle;
            Debug.Log("Success!!!");
            Debug.Log(assetBundle);
        }
        else
        {
            Debug.Log("Error"+request.error);
        }
        yield return null;
    }

    public void ResetModel()
    {
        GameObject[] m_go =  GameObject.FindGameObjectsWithTag ("model_item");
        GameObject[] p_go =  GameObject.FindGameObjectsWithTag ("p_line");
        GameObject[] w_go =  GameObject.FindGameObjectsWithTag ("w_line");
        GameObject[] wa_go =  GameObject.FindGameObjectsWithTag ("wall_item");
        GameObject[] fc =  GameObject.FindGameObjectsWithTag("foldingcube");

        foreach (GameObject o in m_go)
        {
            Destroy(o);
        }
        foreach (GameObject o in p_go)
        {
            Destroy(o);
        }
        foreach (GameObject o in w_go)
        {
            Destroy(o);
        }
        foreach (GameObject o in wa_go)
        {
            Destroy(o);
        }
        foreach (GameObject o in fc)
        {
            Destroy(o);
        }
        controller.freeze = false;
    }
}

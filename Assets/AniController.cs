using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AniController : MonoBehaviour
{

    public Animation ani;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void OnUnfold() {
        Debug.Log("playing animation");
        ani.Play("Cube");

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageNumber : MonoBehaviour
{
    public Text ValueText;

    public TabGroup group;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ValueText.text = (group.tutorialIndex+1).ToString()+"/"+group.objectsToSwap.Count.ToString();
    }
}

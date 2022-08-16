using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable CS0436
public class TabGroup : MonoBehaviour {

    public int tutorialIndex;

    public List<TabButton> tabButtons;

    public TabButton selectedTab;

    public List<GameObject> objectsToSwap;

    public void Subscribe(TabButton button) {
        if (tabButtons == null) {
            tabButtons = new List<TabButton>();
        }

        tabButtons.Add(button);
    }

    public void OnTabSelected(TabButton button) {
        //if it is selected before, deselect first
        if (selectedTab != null) {
            selectedTab.Deselect();
        }

        selectedTab = button;
        selectedTab.Select();

        int index = button.transform.GetSiblingIndex();
        
        for (int i = 0; i < objectsToSwap.Count; i++) {
            if (i == index) {
                objectsToSwap[i].SetActive(true);
            } else {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    //For tutorial UI pages
    public void NextPageSelected(TabButton button) {
        if (selectedTab != null) {
            selectedTab.Deselect();
        }

        selectedTab = button;
        selectedTab.Select();

        if (tutorialIndex < objectsToSwap.Count-1){
            tutorialIndex++;
        }
        
        
        for (int i = 0; i < objectsToSwap.Count; i++) {
            if (i == tutorialIndex) {
                objectsToSwap[i].SetActive(true);
            } else {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    public void PrevPageSelected(TabButton button) {
        if (selectedTab != null) {
            selectedTab.Deselect();
        }

        selectedTab = button;
        selectedTab.Select();

        if (tutorialIndex > 0){
            tutorialIndex--;
        }
        
        for (int i = 0; i < objectsToSwap.Count; i++) {
            if (i == tutorialIndex) {
                objectsToSwap[i].SetActive(true);
            } else {
                objectsToSwap[i].SetActive(false);
            }
        }
    }
}

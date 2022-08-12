using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

[RequireComponent(typeof(Button))]
public class TabButton : MonoBehaviour{

    public TabGroup tabGroup;

    public UnityEvent onTabSelected;
    public UnityEvent  onTabDeselected;

    void Start() {
        tabGroup.Subscribe(this);
    }

    public void OnPointerClick() {
        tabGroup.OnTabSelected(this);
    }

    public void NextPageClick() {
        tabGroup.NextPageSelected(this);
    }

    public void PrevPageClick() {
        tabGroup.PrevPageSelected(this);
    }

    public void Select() {
        if(onTabSelected != null) { onTabSelected.Invoke(); }
    }

    public void Deselect() {
        if (onTabDeselected != null) { onTabDeselected.Invoke(); }
    }
}

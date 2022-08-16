using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class UIScript : MonoBehaviour {
    public Dropdown modeldropdown;
    public InputActionReference actRef;
    public GameObject UIObject;
    public ModelLoader ModelLoader;
    public MyPlayerController controller;
    public Toggle dotted;

    private bool isPressed;
    //two model options right now: default and steps
    private string[] modelenum = new string[] {"Default", "Steps", "Steps1"};


    void Awake() {
        actRef.action.started += ToggleMenu;
    }

    void OnDestroy() {
        actRef.action.started -= ToggleMenu;
    }

    public void OnApplyInteract() {
        string modelname = modelenum[modeldropdown.value];
        ModelLoader.LoadCube(modelname);
    }

    private void ToggleMenu(InputAction.CallbackContext context) {
        if (gameObject.activeInHierarchy) {
            UIObject.SetActive((UIObject.activeInHierarchy == true) ? false : true);
        }
    }

    public void Unfold() {
        controller.Unfold();
    }

    public void Reset() {
        ModelLoader.ResetModel();
    }

    public void clearSelected() {
        controller.Clear();
    }

    public void drawSelected() {
        controller.Draw();
    }

    public void toggledotted() {
        controller.ToggleDotted(dotted.isOn);
    }

    public void togglewlines() {
        controller.ToggleWLines();
    }

    public void toggleplines() {
        controller.TogglePLines();
    }
}

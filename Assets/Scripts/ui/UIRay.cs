using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.InputSystem;

public class UIRay : MonoBehaviour {

    [SerializeField] private GameObject UIRayObject;
    [SerializeField] private GameObject TeleportRay;

    public bool isGrabbing;

    private void FixedUpdate() {

        LayerMask layerMask = LayerMask.GetMask("UI");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5, layerMask)) {
            if (TeleportRay.GetComponent<LineRenderer>().enabled == true || isGrabbing) {
                UIRayObject.SetActive(false);
            } else {
                UIRayObject.SetActive(true);
            }
        } else {
            UIRayObject.SetActive(false);
        }
    }
}

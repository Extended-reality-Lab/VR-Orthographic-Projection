using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorColorChange : MonoBehaviour
{
    public Material selected_v;
    public Material highlight;

    void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("env")){
            this.gameObject.GetComponent<MeshRenderer> ().material = selected_v;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.layer == LayerMask.NameToLayer("env")){
            this.gameObject.GetComponent<MeshRenderer> ().material = highlight;
        }
    }
}

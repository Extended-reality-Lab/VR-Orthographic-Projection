using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelUnfolding : MonoBehaviour
{

    public Animator anmtr;
    public GameObject target_cube;

    public void Unfold()
    {
        anmtr.Play("Base Layer.Cube", 0, 0);
    }
}


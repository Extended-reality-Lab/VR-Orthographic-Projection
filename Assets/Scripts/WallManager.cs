using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using System.Diagnostics;

public class WallManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rightControllerReference;
    public float threshold;
    public bool onModel;
    public MyPlayerController controller;
    public Material highlight_mat;
    public Material default_mat;
    public float surface;

    public bool can_spawn_vertex = false;
    public Vector3 spawn_point = Vector3.zero;

    public int depth_axis;
    public List<GameObject> rendered_vertices = new List<GameObject>();
    public List<LineManager> list_of_lines = new List<LineManager>();
    // Update is called once per frame

    /*
    * When controller hit the wall:
    * Turn on can_spawn_vertex, 
    * Set spawn_point attributes on the collided wall with other.contacts[0].point, depth_axis and surface. 
    */
    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "GameController") {
            Debug.Log("Start Collision with controller");
            can_spawn_vertex = true;
            spawn_point = other.contacts[0].point;
            switch (depth_axis)
            {
                case 0:
                    spawn_point.x = surface;
                    break;
                case 1:
                    spawn_point.y = surface;
                    break;

                case 2:
                    spawn_point.z = surface;
                    break;
                default:
                    break;
            }
        } 
    }

    //Continue setting spawn_point
    void OnCollisionStay(Collision other) {
        if (other.gameObject.tag == "GameController") {
            spawn_point = other.contacts[0].point;
            // Debug.Log(spawn_point);
            switch (depth_axis)
            {
                case 0:
                    spawn_point.x = surface;
                    break;
                case 1:
                    spawn_point.y = surface;
                    break;
                case 2:
                    spawn_point.z = surface;
                    break;
                default:
                    break;
            }
        } 
    }

    //disable can_spawn_vertex when exi
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "GameController") {
            Debug.Log("End Collision with controller");
            can_spawn_vertex = false;
        } 
    }
    //generate a list, and every time MakeV is called, add the vertex to the list
    public Vector3 makeV(Vector3 pos, LineManager LM, bool snappedVertex)
    {
        Debug.Log("Spawning Vertex");
        GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        GameObject myVert = GameObject.Instantiate(temp);
        myVert.tag = "wall_item";
        //AdjacencyList AL;
        Vector3 n_pos = pos;
        myVert.transform.position = n_pos;
        myVert.transform.localScale = new Vector3(.015f,.015f,.015f);
        MyVertex mref = myVert.AddComponent<MyVertex>();
       // AL = myVert.AddComponent<AdjacencyList>(mref.key);
        mref.controller = controller;
        mref.rightControllerReference = rightControllerReference;
        Debug.Log("right controller ref in wall manager" + rightControllerReference + " confirmed");
        mref.onModel = false;
        mref.threshold = threshold;
        mref.default_mat = default_mat;
        mref.highlight_mat = highlight_mat;
        mref.snappedVertex = snappedVertex;
        mref.SetWall(gameObject.GetComponent<WallManager>());
        //mref.list_of_lines.Add(LM);
        rendered_vertices.Add(myVert);
        Destroy(temp);
        return n_pos;
    }

    

}

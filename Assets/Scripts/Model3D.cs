using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Model3D : MonoBehaviour
{
    //references for creating vertex class
    public GameObject rightControllerReference;
    public float threshold;
    public MyPlayerController controller;

    MeshRenderer r;
    public Material highlight_mat;
    public Material default_mat;

    HashSet<Vector3> v_new;
    public List<GameObject> rendered_vertices = new List<GameObject>();

    public struct Tri
    {
        public Tri(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            p1 = v1;
            p2 = v2;
            p3 = v3;

            n = Vector3.Cross(p2 - p1, p3 - p1);

        }
        public Vector3 p1;
        public Vector3 p2;
        public Vector3 p3;

        public Vector3 n;

    }

    // Start is called before the first frame update
    void Start()
    {
        MeshFilter[] filter = GetComponentsInChildren<MeshFilter>();
        Mesh mesh = filter[0].mesh;
        Vector3[] v = mesh.vertices;
        //HashSet<Vector3> final = new HashSet<Vector3>();
        //int[] t = mesh.triangles;
        v_new = new HashSet<Vector3>(v);
        Debug.Log("Rendering Vertices...");
        //Dictionary<Vector3, List<Tri>> triangleMap = new Dictionary<Vector3, List<Tri>>();

        // Debug.Log("Triangles: " + String.Join(", ", new List<int>(t).ConvertAll(i => i.ToString()).ToArray()));
        // Debug.Log("Normals: " + String.Join(", ", new List<Vector3>(mesh.normals).ConvertAll(i => i.ToString()).ToArray()));
        // Debug.Log("Triangle Count: " + t.Length);
        // Debug.Log("Normal Count: " + mesh.normals.Length);
        //int debugCount = 0;
        // foreach (Vector3 vert in v_new)
        // {
        //     triangleMap[vert] = new List<Tri>();
        // }
        // Debug.Log(t.Length % 3);
        // for (int i = 0; i <= t.Length; i+=3)
        // {
        //     if (i == t.Length || i + 1 == t.Length || i + 2 == t.Length)
        //         break;
        //     Tri myTriangle = new Tri(v[t[i]], v[t[i+1]], v[t[i+2]]);
        //     triangleMap[v[t[i]]].Add(myTriangle);
        //     triangleMap[v[t[i+1]]].Add(myTriangle);
        //     triangleMap[v[t[i+2]]].Add(myTriangle);
        //     //Debug.Log(myTriangle + " added");
        // }

        // foreach (Vector3 vert in v_new)
        // {
        //     List<Tri> plane_count = new List<Tri>();
        //     foreach (Tri tri1 in triangleMap[vert])
        //     {
        //         bool add = true;
        //         foreach (Tri tri2 in plane_count)
        //         {
        //             if (tri1.n == tri2.n)
        //                 add = false;
        //         }
        //         if(add)
        //             plane_count.Add(tri1);
        //     }
        //     //Debug.Log("Plane Count: " + plane_count.Count);
        //     //Debug.Log("Triangle Count: " + triangleMap[vert].Count);
        //     bool add2 = true;
        //     // if (plane_count.Count >= 3)
        //     // {
        //         // foreach (Vector3 vt in final)
        //         // {
        //         //     if (Vector3.Distance(vert, vt) < threshold)
        //         //     {
        //         //         add2 = false;
        //         //     }
        //         // }
        //         // if (add2)
        //     Debug.Log("plane count: " + plane_count.Count);
        //     final.Add(vert);
        //     // }
        // }    

        /*
        * reads in mesh, only keep the vertex we want, 
        * add MyVertex script yo them, 
        * and add attribute to them and the mash.
        */

        List<Vector3> compare = new List<Vector3>();

        foreach (var vert in v_new) {

  /*          bool make = true;
            foreach(Vector3 v2 in compare)
            {
                float dist = Vector3.Distance(vert, v2);
                if (dist < 0.0001)
                {
                    Debug.Log(dist);
                    make = false;
                    break;
                }
            }

            if (!make)
                continue;*/
            compare.Add(vert);
            // Debug.Log(vert);
            GameObject temp = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject myVert = GameObject.Instantiate(temp, gameObject.transform);
            myVert.tag = "model_item";
            myVert.transform.localPosition = vert;
            //myVert.transform.localScale = new Vector3(.02f,.02f,.02f);
            //Debug.Log("magnitude: " + this.transform.localScale.magnitude);
            myVert.transform.localScale = new Vector3(.02f,.02f,.02f) / this.transform.localScale.magnitude;
            
            MyVertex mref = myVert.AddComponent<MyVertex>();
            mref.controller = controller;
            mref.rightControllerReference = rightControllerReference;
            mref.threshold = threshold;
            mref.default_mat = default_mat;
            mref.highlight_mat = highlight_mat;
            mref.SetModel(this.GetComponent<Model3D>());
            rendered_vertices.Add(myVert);
            Destroy(temp);
        }
        Debug.Log("Vertices Rendered");

        //add other needed components to loaded model.
    }

}
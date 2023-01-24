using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;


public class DrawnLines : MonoBehaviour
{

    public LineRenderer lr;
    public EdgeCollider2D edgeCollider;
    public GameObject rightControllerReference;
    public bool touchingLine;
    public bool fromDraw = false;
    public RaycastHit hit;
    bool RinSelectableRange;
    public float threshold;
    public MyPlayerController controller;

    public Vector3 origin;
    public Vector3 origin_fromDraw;
    public Vector3 end_fromDraw;
    public Vector3 direction;
    public Vector3 direction_fromDraw;
    public Vector3 first_point;
    public Vector3 second_point;
    public float distance;
    public float distance_fromDraw;
    public int layerMask;

    // Start is called before the first frame updat
    void Start()
    {
        edgeCollider = this.GetComponent<EdgeCollider2D>();
        lr = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Vector3.Distance(origin_fromDraw, rightControllerReference.transform.position) < threshold)
        {
            UnityEngine.Debug.Log("Start Collision with controller REEEEEEEEEEEEEEEEEEEEEEE");
        }
        if (Vector3.Distance(end_fromDraw, rightControllerReference.transform.position) < threshold)
        {
            UnityEngine.Debug.Log("Start Collision with controller REEEEEEEEEEEEEEEEEEEEEEE");
        }*/
        Vector3[] positions = new Vector3[2];
        //lr.GetPositions(positions);
        positions[0] = origin_fromDraw;
        positions[1] = end_fromDraw;

        /*if (fromDraw == true)
        {
            UnityEngine.Debug.Log("yeeeeeeeeeeeeeeeeeeeeeeeeeee");
            positions[0] = first_point;
            positions[1] = lr.GetPosition(lr.positionCount - 1);
            UnityEngine.Debug.Log("Incorrect Pos is " + second_point);
            lr.SetPosition(1, second_point);
        }*/
        lr.positionCount = positions.Length;
        //With this lines can be deleted, but the second point is in narnia
        //Without the lines are correct, but cant be deleted
        //lr.SetPositions(positions);


        bool Rtemp = RinSelectableRange;


        layerMask = 1 << 8;
        layerMask = ~layerMask;

        for (int i = 1; i < lr.positionCount; i++)
        {
            origin = positions[i - 1];
            direction = positions[i] - origin;
            distance = origin.magnitude;



            //UnityEngine.Debug.Log("origin " + origin);
            //UnityEngine.Debug.Log("direction " + direction); 
            //UnityEngine.Debug.Log("dis " + distance);
            //UnityEngine.Debug.Log("Start Collision with controller REEEEEEEEEEEEEEEEEEEEEEE");
            //RaycastHit hit;
            if (Physics.Raycast(origin_fromDraw, transform.TransformDirection(direction * distance), out hit, Mathf.Infinity, layerMask))
            {
                UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                UnityEngine.Debug.Log("hit Data " + hit.collider.tag);
                if (hit.collider.tag == "GameController")
                {
                    UnityEngine.Debug.Log("REEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
                    touchingLine = true;
                    RinSelectableRange = true;
                    break;
                }
            }

            /*Ray theRay = new Ray(transform.position, transform.TransformDirection(direction * distance));
            UnityEngine.Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50, Color.white);
            UnityEngine.Debug.DrawLine(origin, new Vector3(5, 0, 0), Color.white, 2.5f);*/
            //UnityEngine.Debug.Log(Vector3.Distance(gameObject.transform.position, rightControllerReference.transform.position));
            if (Vector3.Distance(origin_fromDraw, rightControllerReference.transform.position) < threshold)
            {
                UnityEngine.Debug.Log("Start Collision with controller REEEEEEEEEEEEEEEEEEEEEEE");
                RinSelectableRange = true;
                //break;
            }

        }

        if (Vector3.Distance(origin_fromDraw, rightControllerReference.transform.position) < threshold)
        {
            UnityEngine.Debug.Log("Start Collision with controller REEEEEEEEEEEEEEEEEEEEEEE");
            RinSelectableRange = true;
            //break;
        }


        //depends on previous and current frame 
        if ((RinSelectableRange && !Rtemp))
        {
            //highlightOn();
            controller.setSelectedLineDrawn(gameObject, true);
            RinSelectableRange = false;
        }
        else if ((!RinSelectableRange && Rtemp))
        {
            //highlightOff();
            controller.setSelectedLineDrawn(gameObject, false);
        }
    }



}

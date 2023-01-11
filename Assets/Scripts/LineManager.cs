using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{

    public LineRenderer lr;
    public GameObject rightControllerReference;
    bool RinSelectableRange;
    public float threshold;
    public MyPlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] positions = new Vector3[2];
        lr.GetPositions(positions);
        positions[0] = gameObject.transform.position;
        lr.positionCount = positions.Length;
        lr.SetPositions(positions);

        bool Rtemp = RinSelectableRange;



        for (int point = 0; point < positions.Length; point++)
        {
            if(Vector3.Distance(gameObject.transform.position, rightControllerReference.transform.position) < threshold)
            {
                RinSelectableRange = true;
                break;
            }

        }

        //depends on previous and current frame 
        if ((RinSelectableRange && !Rtemp))
        {
            //highlightOn();
            controller.setSelectedLine(gameObject, true);
        }
        else if ((!RinSelectableRange && Rtemp))
        {
            //highlightOff();
            controller.setSelectedLine(gameObject, false);
        }
    }

}

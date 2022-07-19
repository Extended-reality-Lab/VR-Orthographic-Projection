using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineManager : MonoBehaviour
{

    public LineRenderer lr;
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
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGO : MonoBehaviour
{
    public Transform aimStart;

    public LineRenderer lineRenderer;
    public List<Vector3> points;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        points = new List<Vector3>();
        points.Add(aimStart.position);
        RaycastHit[] hits = Physics.RaycastAll(aimStart.position, aimStart.transform.forward * 20);
        Vector3 fartest = aimStart.position + Vector3.one * 255;
        float farDistance = Mathf.Infinity;
        if (hits.Length == 0)
        {
            AddPoint(transform.forward * 20);
        }
        else
        {
            foreach (RaycastHit hit in hits)
            {
                AddPoint(hit.point);
                //if (Vector3.Distance(hit.point, fartest) < farDistance)
                //{
                //    EndPoint(hit.point);
                //}
            }
        }
    }

    public void AddPoint(Vector3 point2)
    {
        if (points.Contains(point2) == false)
        {
            points.Add(point2);
        }
        lineRenderer.SetPositions(points.ToArray());
    }

    public void EndPoint(Vector3 point2)
    {
        points = new List<Vector3>();
        points.Add(aimStart.position);
        lineRenderer.SetPositions(points.ToArray());
    }
}
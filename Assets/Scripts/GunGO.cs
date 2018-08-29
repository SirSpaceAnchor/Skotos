using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGO : MonoBehaviour
{
    public Transform aimStart;

    public LineRenderer lineRenderer0;
    public LineRenderer lineRenderer1;
    public List<Vector3> points;

    public int Damage = 5; // (100 health values)
    public int Range = 5; // 5 Game unit Values.

    public static bool akimbo = true;
    public static bool isStaticRight = true;

    public bool gunRight = true;

    // Use this for initialization
    void Start()
    {
        akimbo = true;
    }

    private void Update()
    {
        //if (Input.GetKeyDown("Fire1") && isKickingBack == false)
        if (akimbo)
        {
            if (isStaticRight)
            {
                if (gunRight)
                {
                    TryFire();
                }
            }
            else if (isStaticRight == false)
            {
                if (gunRight == false)
                {
                    TryFire();
                }
            }
        }
        else
        {
            TryFire();
        }
    }

    private void TryFire()
    {
        if (Input.GetButtonDown("Fire1") && isKickingBack == false)
        {
            AudioManager.instance.Play(StatusType.GunPew);
            //UnityEngine.Debug.Log("Fire!!");
            StartCoroutine(KickbackGun());
            // We want to fire our left one now, but doesn't matter if single gun
            // Add in more checks later on.
        }
    }

    private float kickSpeed = 50f;
    private float kickBack = 3f;
    public bool isKickingBack = false;
    public IEnumerator KickbackGun()
    {
        isKickingBack = true;
        //Vector3 startY = Vector3.zero;
        float x = 0;
        //Vector3 startY = transform.eulerAngles;
        //Vector3 kickY = new Vector3(0, kickBack, 0);
        while (x > -kickBack)
        {
            Vector3 eulerX = transform.eulerAngles;
            x -= Time.deltaTime * kickSpeed;
            eulerX.x = x;
            transform.eulerAngles = eulerX;
            transform.Translate(new Vector3(0, 0, 0.001f));
            yield return null;
        }
        isStaticRight = !isStaticRight;
        while (x > kickBack)
        {
            Vector3 eulerX = transform.eulerAngles;
            x -= Time.deltaTime * kickSpeed;
            eulerX.x = x;
            transform.eulerAngles = eulerX;
            transform.Translate(new Vector3(0, 0, 0.001f));
            yield return null;
        }
        
        x = 0f;
        Vector3 eulerX2 = transform.eulerAngles;
        eulerX2.x = x;
        transform.eulerAngles = eulerX2;
        isKickingBack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        points = new List<Vector3>();
        for (int i = 0; i < Range; i++)
        {
            //AddPoint(aimStart.position * (i + 5));
            points.Add(transform.forward * (i + 5));
        }
        lineRenderer0.positionCount = points.Count;
        lineRenderer1.positionCount = points.Count;
        lineRenderer0.SetPositions(points.ToArray());
        lineRenderer1.SetPositions(points.ToArray());
        //RaycastHit[] hits = Physics.RaycastAll(aimStart.position, aimStart.transform.forward * 20);
        //Vector3 fartest = aimStart.position + Vector3.one * 255;
        //float farDistance = Mathf.Infinity;
        //if (hits.Length == 0)
        //{
        //    AddPoint(transform.forward * 20);
        //}
        //else
        //{
        //    foreach (RaycastHit hit in hits)
        //    {
        //        AddPoint(hit.point);
        //        //if (Vector3.Distance(hit.point, fartest) < farDistance)
        //        //{
        //        //    EndPoint(hit.point);
        //        //}
        //    }
        //}
    }

    public void AddPoint(Vector3 point2)
    {
        //if (points.Contains(point2) == false)
        {
            points.Add(point2);
        }

    }

    //public void EndPoint(Vector3 point2)
    //{
    //    points = new List<Vector3>();
    //    points.Add(aimStart.position);
    //    lineRenderer0.SetPositions(points.ToArray());
    //    lineRenderer1.SetPositions(points.ToArray());
    //}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunGO : MonoBehaviour
{
    public Transform parentController;
    public Transform aimStart;
    public Transform target;

    //public LineRenderer lineRenderer0;
    //public LineRenderer lineRenderer1;
    //public List<Vector3> points;

    public ProjectileGO bulletPrefab;
    public int Damage = 5; // (100 health values)
    public float BulletSpeed = 75f;
    //public int Range = 5; // 5 Game unit Values.

    public bool akimbo = true;
    public static bool isStaticRight = true;

    public bool gunRight = true;
    public bool isPlayer = true;

    // Use this for initialization
    void Start()
    {
        //akimbo = true;
    }

    public bool Fire()
    {
        if (isKickingBack == false)
        {
            if (isPlayer)
            {
                AudioManager.instance.Play(StatusType.GunPew);
            }
            else
            {
                AudioManager.instance.Play(StatusType.GunVrom);
            }
            var bullet = (ProjectileGO)Instantiate(
                bulletPrefab,
                aimStart.position + aimStart.forward * 0.25f,
                aimStart.rotation);
            bullet.transform.localScale = Vector3.one;
            bullet.Damage = Damage;
            bullet.speed = BulletSpeed;
            if (isPlayer == false && target != null)
            {
                bullet.transform.LookAt(target.position + Vector3.up);
            }
            //UnityEngine.Debug.Log("Fire!!");
            StartCoroutine(KickbackGun());
            // We want to fire our left one now, but doesn't matter if single gun
            // Add in more checks later on.
            return true;
        }
        return false;
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

    //// Update is called once per frame
    //void FixedUpdate()
    //{
    //    points = new List<Vector3>();
    //    for (int i = 0; i < Range; i++)
    //    {
    //        //AddPoint(aimStart.position * (i + 5));
    //        points.Add(transform.forward * (i + 5));
    //    }
    //    lineRenderer0.positionCount = points.Count;
    //    lineRenderer1.positionCount = points.Count;
    //    lineRenderer0.SetPositions(points.ToArray());
    //    lineRenderer1.SetPositions(points.ToArray());
    //    //RaycastHit[] hits = Physics.RaycastAll(aimStart.position, aimStart.transform.forward * 20);
    //    //Vector3 fartest = aimStart.position + Vector3.one * 255;
    //    //float farDistance = Mathf.Infinity;
    //    //if (hits.Length == 0)
    //    //{
    //    //    AddPoint(transform.forward * 20);
    //    //}
    //    //else
    //    //{
    //    //    foreach (RaycastHit hit in hits)
    //    //    {
    //    //        AddPoint(hit.point);
    //    //        //if (Vector3.Distance(hit.point, fartest) < farDistance)
    //    //        //{
    //    //        //    EndPoint(hit.point);
    //    //        //}
    //    //    }
    //    //}
    //}

    //public void AddPoint(Vector3 point2)
    //{
    //    //if (points.Contains(point2) == false)
    //    {
    //        points.Add(point2);
    //    }

    //}

    //public void EndPoint(Vector3 point2)
    //{
    //    points = new List<Vector3>();
    //    points.Add(aimStart.position);
    //    lineRenderer0.SetPositions(points.ToArray());
    //    lineRenderer1.SetPositions(points.ToArray());
    //}
}
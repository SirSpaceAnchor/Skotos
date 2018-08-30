using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileGO : MonoBehaviour
{
    public float speed = 75f;
    private float range = 5000f;
    public float Range = 0f;
    public float Damage = 5f;
    public GameObject decalPrefab;

    public GameObject bulletGO;

    public BoxCollider boxCollider;

    public ParticleSystem bulletPop;

    // Use this for initialization
    void Start()
    {
        Range = 0f;
    }

    private bool bulletPopped = false;
    // Update is called once per frame
    void Update()
    {
        if (Range >= range && bulletPopped == false)
        {
            PopBullet();
        }
        else
        {
            Vector3 pos = transform.position;
            Vector3 distance = Vector3.forward * 0.1f * speed * Time.deltaTime;
            transform.Translate(distance);
            Range += Vector3.Distance(pos, distance);
        }
    }

    public void PopBullet()
    {
        bulletPopped = true;
        //boxCollider.isTrigger = true;
        Destroy(bulletGO);
        //ParticleSystem go = GameObject.Instantiate(bulletPop);
        bulletPop.gameObject.SetActive(true);
        bulletPop.Play();
        //Destroy(go, 0.3f);
        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //EnemyGO enemy = other.gameObject.GetComponent<EnemyGO>();
        //if (enemy != null)
        //{
        //    enemy.TakeDamage(Damage);
        //    PopBullet();
        //    UnityEngine.Debug.Log("Collided with: " + other.gameObject.name);
        //    GameObject sprite = GameObject.Instantiate(decalPrefab);
        //    sprite.transform.position = this.transform.position;
        //    bulletPop.startColor = Color.grey;
        //}
    }

    PlayerBaseGO playerHit;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "BeamGO")
            return;

        PlayerBaseGO enemy = collision.gameObject.GetComponent<PlayerBaseGO>();
        if (enemy != null && enemy != playerHit)
        {
            playerHit = enemy;
            enemy.TakeDamage(Damage);
            PopBullet();
            UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);
            GameObject sprite = GameObject.Instantiate(decalPrefab);
            sprite.transform.position = this.transform.position;
            bulletPop.startColor = Color.grey;
        }
        else if (playerHit != null)
        {
            UnityEngine.Debug.Log("Collided with: " + collision.gameObject.name);
            GameObject sprite = GameObject.Instantiate(decalPrefab);
            sprite.transform.position = this.transform.position;
            bulletPop.startColor = Color.grey;
            //bulletPop.main.startColor = Color.grey;
            PopBullet();
        }

    }
}
